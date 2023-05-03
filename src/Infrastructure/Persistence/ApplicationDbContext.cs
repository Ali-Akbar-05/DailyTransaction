﻿using Application.Abstractions.Data;
using Domain.Entities.Setup;
using Domain.Entities.Transactions;
using Domain.Primitives.Common.Abstractions;
using Infrastructure.Identity;
using Infrastructure.Persistence.Interceptors;
using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace Infrastructure.Persistence;

public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, string,
                              AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>, IDbContext
{
    private readonly IMediator _mediator;
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
       IMediator mediator,
        AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) : base(options)
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
    public DbSet<CompanyInfo> CompanyInfo => Set<CompanyInfo>();
    public DbSet<UserCompany> UserCompany => Set<UserCompany>();

    #endregion


    #region  Transactions
    public DbSet<InvoiceMaster> InvoiceMaster => Set<InvoiceMaster>();
    public DbSet<InvoiceDetail> InvoiceDetail => Set<InvoiceDetail>();
    public DbSet<BillPayment> BillPayment => Set<BillPayment>();
    #endregion


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        IdentityModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        AddingSofDeletes(builder);

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);


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


    public void IdentityModelCreating(ModelBuilder builder)
    {
        builder.Entity<AppUser>(t =>
        {
            t.ToTable("AppUser");

        });

        builder.Entity<AppUserRole>(t =>
        {
            t.ToTable("AppUserRole");

            t.HasOne(b => b.User)
            .WithMany()
            .HasForeignKey(b => b.UserId)
            .IsRequired();

            t.HasOne(b=>b.Role)
            .WithMany()
            .HasForeignKey(b=>b.RoleId)
            .IsRequired();
        });

        builder.Entity<AppUserClaim>(t =>
        {
            t.HasOne(b => b.User)
            .WithMany()
            .HasForeignKey(b => b.UserId)
            .IsRequired();
        });

        builder.Entity<AppUserLogin>(t =>
        {
            t.HasOne(b => b.User)
            .WithMany()
            .HasForeignKey(b => b.UserId)
            .IsRequired();
        });

        builder.Entity<AppUserToken>(t =>
        {
            t.ToTable("AppUserToken");
            t.HasOne(b => b.User)
            .WithMany()
            .HasForeignKey(b => b.UserId)
            .IsRequired();
        });

        builder.Entity<AppRole>(t =>
        {
            t.ToTable("AppRole");
        });

        builder.Entity<AppRoleClaim>(t =>
        {
            t.ToTable("AppRoleClaim");

            t.HasOne(b=>b.Role)
            .WithMany()
            .HasForeignKey(b => b.RoleId)
            .IsRequired();
        });
    }

}
