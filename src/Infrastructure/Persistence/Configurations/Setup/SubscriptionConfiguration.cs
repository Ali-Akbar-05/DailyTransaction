using Domain.Entities.Setup;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Setup
{
    internal sealed class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Code)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Description)
                .IsUnicode(true)
                .HasMaxLength(250);


            builder.Property(p => p.ConditinalDayes)
                .IsRequired();
            
        }
    }
}
