using Domain.Entities.Setup;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations.Setup;

internal sealed class CompanyInfoConfiguration : IEntityTypeConfiguration<CompanyInfo>
{
    public void Configure(EntityTypeBuilder<CompanyInfo> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(p=>p.CompanyName)
            .IsUnicode()
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(p => p.CompanyLogo)
            .HasMaxLength(200)
            .IsUnicode(true);


        builder.HasOne(p => p.Subscription)
            .WithMany()
            .HasForeignKey(b => b.SubscriptionId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
