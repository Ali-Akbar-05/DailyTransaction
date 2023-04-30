using Domain.Entities.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Transactions;

internal sealed class InvoiceDetailConfiguration : IEntityTypeConfiguration<InvoiceDetail>
{
    public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<InvoiceMaster>()
            .WithMany()
            .HasForeignKey(x => x.InvoiceMaster)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ItemInfo)
            .WithMany()
            .HasForeignKey(x => x.ItemId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
