using Domain.Entities.Setup;
using Domain.Entities.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations.Transactions
{
    internal sealed class InvoiceMasterConfiguration : IEntityTypeConfiguration<InvoiceMaster>
    {
        public void Configure(EntityTypeBuilder<InvoiceMaster> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(o => o.Remarks)
                .HasMaxLength(100)
                .IsUnicode();

            builder.HasOne<TransactionType>()
                .WithMany()
                .HasForeignKey(b => b.TransactionTypeId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne<AccountInfo>()
                .WithMany()
                .HasForeignKey(x => x.AccountId)
                .OnDelete(DeleteBehavior.NoAction);


             
        }
    }
}
