using Domain.Entities.Setup;
using Domain.Entities.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Transactions
{
    internal sealed class BillPaymentConfiguration : IEntityTypeConfiguration<BillPayment>
    {
        public void Configure(EntityTypeBuilder<BillPayment> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.PaymentHints)
                .HasMaxLength(50);

            builder.Property(p => p.Remarks)
             .IsUnicode()
             .HasMaxLength(100);

            builder.HasOne<PaymentType>()
                .WithMany()
                .HasForeignKey(p => p.PaymentTypeId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
