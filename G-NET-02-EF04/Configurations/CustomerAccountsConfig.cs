using G_NET_02_EF04.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_02_EF04.Configurations
{
    public class CustomerAccountsConfig : IEntityTypeConfiguration<CustomerAccount>
    {
        public void Configure(EntityTypeBuilder<CustomerAccount> builder)
        {

            builder.ToTable("CustomerAccounts");
            builder.HasKey(ca => new
            {
                ca.AccountId,
                ca.CustomerId
            });

            builder.HasOne(ca => ca.Account).
                WithMany(a => a.CustomerAccounts)
                .HasForeignKey(ca => ca.AccountId);

            builder.HasOne(ca=>ca.Customer)
                .WithMany(c => c.CustomerAccounts)
                .HasForeignKey(ca=>ca.CustomerId);

        }
    }
}
