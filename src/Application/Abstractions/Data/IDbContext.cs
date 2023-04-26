using Domain.Entities.Setup;
using Domain.Entities.Transactions;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstractions.Data;

public interface IDbContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    #region Setup
    public DbSet<AccountInfo> AccountInfo { get; }
    public DbSet<ItemInfo> ItemInfo { get; }
    public DbSet<PaymentType> PaymentType { get; }
    public DbSet<Subscription> Subscription { get; }
    public DbSet<TransactionType> TransactionType { get; }
    public DbSet<UserCompany> UserCompany { get; }
    #endregion Setup

    #region Transaction

    public DbSet<InvoiceMaster> InvoiceMaster { get; }
    public DbSet<InvoiceDetail> InvoiceDetail { get; }


    #endregion


    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
