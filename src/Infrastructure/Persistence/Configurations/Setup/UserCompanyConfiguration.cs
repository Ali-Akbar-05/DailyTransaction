using Domain.Entities.Setup;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Setup;

internal class UserCompanyConfiguration : IEntityTypeConfiguration<UserCompany>
{
    public void Configure(EntityTypeBuilder<UserCompany> builder)
    {
        builder.HasKey(b => new { b.CompanyId, b.UserId });


        builder.HasOne(b=>b.Company)
            .WithMany()
            .HasForeignKey(b=>b.CompanyId)
            .IsRequired();

        builder.HasOne(b=>b.User)
            .WithMany()
            .HasForeignKey(b => b.UserId)
            .IsRequired();

    }
}
