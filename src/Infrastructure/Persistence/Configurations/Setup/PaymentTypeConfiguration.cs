using Domain.Entities.Setup;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Setup
{
    internal sealed class PaymentTypeConfiguration : IEntityTypeConfiguration<PaymentType>
    {
        public void Configure(EntityTypeBuilder<PaymentType> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(50);

            builder.HasOne<CompanyInfo>()
                .WithMany()
                .HasForeignKey(b=>b.CompanyId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
