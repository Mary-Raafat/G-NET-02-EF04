using G_NET_02_EF04.Configurations;
using G_NET_02_EF04.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_02_EF04
{
    public class BankDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=EFCore4;Trusted_Connection=True;TrustServerCertificate=True;");

        }


         public DbSet<Manager> Managers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customers");
                entity.HasKey(i=>i.Id);
                entity.Property(i=>i.CustomerType).IsRequired();
                entity.Property(i=>i.FullName).IsRequired();
                entity.Property(i=>i.Address).IsRequired();

            }

            );


            modelBuilder.Entity<Manager>(entity =>
            {
                entity.ToTable("Managers");

                entity.HasKey(m => m.Id);

                entity.Property(m => m.FullName)
                      .IsRequired();

                entity.Property(m => m.EmailAddress)
                      .IsRequired();

                entity.Property(m => m.PhoneNumber)
                    .IsRequired();

                entity.HasData(
                    new Manager
                    {
                        Id = 1,
                        FullName = "Ahmed Ali",
                        EmailAddress = "ahmed.ali@bank.com",
                        PhoneNumber = "01012345678",
                        HireDate = new DateTime(2020, 1, 1)
                    },
                    new Manager
                    {
                        Id = 2,
                        FullName = "Sara Hassan",
                        EmailAddress = "sara.hassan@bank.com",
                        PhoneNumber = "01187654321",
                        HireDate = new DateTime(2021, 5, 15)
                    }
                );

                        });


            modelBuilder.ApplyConfiguration<Branch>(new BranchConfig());
            modelBuilder.ApplyConfiguration<Account>(new AccountConfig());
            modelBuilder.ApplyConfiguration<Transaction>(new TransactionConfig());
            modelBuilder.ApplyConfiguration<CustomerAccount>(new CustomerAccountsConfig());

        }

    }
}
