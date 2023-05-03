using Domain.Entities.Setup;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Setup;

internal class ItemInfoConfiguration : IEntityTypeConfiguration<ItemInfo>
{
    public void Configure(EntityTypeBuilder<ItemInfo> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(p => p.Name)
            .IsRequired();

        builder.Property(p => p.Description)
            .IsUnicode()
            .IsRequired(false)
            .HasMaxLength(250);

        builder.HasOne(p => p.Parent)
            .WithMany(x => x.ChildItem)
            .HasForeignKey(x => x.ParentId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(b=>b.CompanyInfo)
            .WithMany()
            .IsRequired()
            .HasForeignKey(f=>f.CompanyId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
