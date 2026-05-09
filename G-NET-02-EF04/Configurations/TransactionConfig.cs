using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G_NET_02_EF04.Models;
using System.Transactions;

namespace G_NET_02_EF04.Configurations
{
    public class TransactionConfig : IEntityTypeConfiguration<Models.Transaction>
    {
        public void Configure(EntityTypeBuilder<Models.Transaction> builder)
        {

                builder.ToTable("Transactions");
                builder.HasKey(i => i.Id);
                builder.Property(i => i.TransactionType).IsRequired();
                builder.Property(i => i.Note).IsRequired();

            builder.HasOne(t => t.Account).WithMany(a => a.Transactions)
                .HasForeignKey(t => t.AccountId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
