using G_NET_02_EF04.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_02_EF04.Configurations
{
    internal class BranchConfig : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {

            builder.ToTable("Branches");
            builder.HasKey(b => b.Code);
            builder.Property(b=>b.Name).IsRequired();
            builder.Property(b=>b.PhoneNumber).IsRequired();

            builder.HasOne(b => b.Manager)
                           .WithOne(m => m.Branch)
                           .HasForeignKey<Branch>(b => b.ManagerId);

            builder.HasData(
        new Branch
        {
            Code = "CAI-105",
            Name = "Main Branch - Cairo",
            Address = "123 Tahrir St, Cairo",
            PhoneNumber = "022555666",
            ManagerId = 1 
        },
        new Branch
        {
            Code = "ALX-102",
            Name = "Alexandria Branch",
            Address = "45 Corniche, Alex",
            PhoneNumber = "033999888",
            ManagerId = 2 
        }
    );

        }

    }
}
