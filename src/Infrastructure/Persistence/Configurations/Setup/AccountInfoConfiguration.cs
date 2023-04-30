using Domain.Entities.Setup;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Setup
{
    internal sealed class AccountInfoConfiguration : IEntityTypeConfiguration<AccountInfo>
    {
        public void Configure(EntityTypeBuilder<AccountInfo> builder)
        {
            builder.Property(p => p.Id);

            builder.Property(p => p.IdentificationNo)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsUnicode();

            builder.Property(p => p.MobileNo)
                .HasMaxLength(15);

            builder.Property(p => p.Email)
                .HasMaxLength(15);

            builder.HasOne(p=>p.Parent)
                .WithMany(x=>x.ChildAccount)
                .HasForeignKey(x=>x.ParentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p=>p.CompanyInfo)
                .WithMany()
                .HasForeignKey(b=>b.CompanyId)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
