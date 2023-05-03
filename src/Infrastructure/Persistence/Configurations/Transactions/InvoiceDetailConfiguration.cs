using Domain.Entities.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Transactions;

internal sealed class InvoiceDetailConfiguration : IEntityTypeConfiguration<InvoiceDetail>
{
    public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(b => b.Rate)
            .HasPrecision(18, 5);
        builder.Property(b => b.Quantity)
           .HasPrecision(18, 3);
        builder.Property(b => b.Amount)
           .HasPrecision(18, 2);
        builder.HasOne(b=>b.InvoiceMaster)
            .WithMany()
            .HasForeignKey(x => x.MasterId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ItemInfo)
            .WithMany()
            .HasForeignKey(x => x.ItemId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
