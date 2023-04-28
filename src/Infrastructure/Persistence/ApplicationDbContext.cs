using Application.Abstractions.Data;
using Domain.Entities.Setup;
using Domain.Entities.Transactions;
using Domain.Primitives.Common.Abstractions;
using Duende.IdentityServer.EntityFramework.Options;
using Infrastructure.Identity;
using Infrastructure.Persistence.Interceptors;
using MediatR;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;
using System.Reflection;

namespace Infrastructure.Persistence;

public class ApplicationDbContext : ApiAuthorizationDbContext<AppUser>, IDbContext
{
    private readonly IMediator _mediator;
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
        IOptions<OperationalStoreOptions> operationalStoreOption,
        IMediator mediator,
        AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) : base(options, operationalStoreOption)
    {
        _mediator = mediator;
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }

    #region Setup
    public DbSet<AccountInfo> AccountInfo => Set<AccountInfo>();
    public DbSet<ItemInfo> ItemInfo => Set<ItemInfo>();
    public DbSet<PaymentType> PaymentType => Set<PaymentType>();
    public DbSet<Subscription> Subscription => Set<Subscription>();
    public DbSet<TransactionType> TransactionType => Set<TransactionType>();
    public DbSet<UserCompany> UserCompany => Set<UserCompany>();

    #endregion


    #region  Transactions
    public DbSet<InvoiceMaster> InvoiceMaster => Set<InvoiceMaster>();
    public DbSet<InvoiceDetail> InvoiceDetail => Set<InvoiceDetail>();
    #endregion


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        AddingSofDeletes(builder);
        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
        base.OnConfiguring(optionsBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }



    #region AddingSofDeletes

    private static void AddingSofDeletes(ModelBuilder builder)
    {
        var types = builder.Model.GetEntityTypes().Where(x => x.ClrType.IsAssignableTo(typeof(IHaveSoftDelete)));
        foreach (var entityType in types)
        {
            var parameter = Expression.Parameter(entityType.ClrType);

            var propertyMethodInfo = typeof(EF).GetMethod("Property")?.MakeGenericMethod(typeof(bool));

            var isDeletedProperty = Expression.Call(propertyMethodInfo, parameter, Expression.Constant(nameof(IHaveSoftDelete.IsDeleted)));


            BinaryExpression compareExpression = Expression.MakeBinary(
                ExpressionType.Equal, isDeletedProperty, Expression.Constant(false));


            var lamda = Expression.Lambda(compareExpression, parameter);

            builder.Entity(entityType.ClrType).HasQueryFilter(lamda);
        }

    }

    #endregion

}
