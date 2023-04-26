using Domain.Entities.Setup;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstractions.Data;

public interface IDbContext
{
    public DbSet<AccountInfo> PersonalInfo { get; }
    public DbSet<Subscription> Subscription { get; } 
    public DbSet<UserCompany> UserCompany { get; }
    public DbSet<TransactionType> TransactionType { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
