using G_NET_02_EF04.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_02_EF04.CRUD_operations
{
    public class OpeningAccount
    {
        BankDbContext dbContext=new BankDbContext();
        public void OpenAcc()
        {
            Console.WriteLine("--- Open New Account --- ");

            Console.WriteLine("Account Number: ");
            if (!int.TryParse(Console.ReadLine(), out int number))
            {
                Console.WriteLine(" Invalid Account Number");
                return;
            }


            Console.WriteLine("Account Type:");
            Console.WriteLine("1) Savings");
            Console.WriteLine("2) Current");
            Console.WriteLine("3) Business");
            Console.Write("Choice: ");

            string type = Console.ReadLine();

            if (!(type == "1" || type == "2" || type=="3"))
            {
                Console.WriteLine("Enter 1 or 2 or 3 only");
                return;
            }
            string accountType = "";

            switch (type)
            {
                case "1":
                    accountType = "Savings";
                    break;

                case "2":
                    accountType = "Current";
                    break;

                case "3":
                    accountType = "Business";
                    break;
            }



            Console.Write("Branch Code : ");
            string branchCode = Console.ReadLine();
            string[] parts = branchCode.Split('-');

            if(!(parts.Length==2&&
                parts[0].All(char.IsLetter)&&
                parts[1].All(char.IsDigit) ) )
            {
                Console.WriteLine("Invalid Branch Code . Try Again"); 
                return;
            }
            Branch branch = dbContext.Branches.FirstOrDefault(b => b.Code==branchCode);
            if (branch == null)
            {
                Console.WriteLine("Branch not found");
                return;
            }

            Console.WriteLine("Customer Id: ");
            if (!int.TryParse(Console.ReadLine(), out int customerId))
            {
                Console.WriteLine("Invalid Id");
                return;
            }


            Console.WriteLine("Ownership Role:");
            Console.WriteLine("1) Primary");
            Console.WriteLine("2) Secondary");
            Console.Write("Choice: ");

            string role = Console.ReadLine();

            if (!(role == "1" || role == "2" ))
            {
                Console.WriteLine("Enter 1 or 2 only");
                return;
            }




            Account account = new Account
            {
               AccountType=accountType,
               BranchId=branchCode,
               OpeningDate=DateTime.Now,
               CurrentBalance=0
            };

            dbContext.Accounts.Add(account);
            dbContext.SaveChanges();


            CustomerAccount customerAccount = new CustomerAccount
            {
                CustomerId = customerId,
                AccountId = account.Id,
                OwnershipType = role == "1" ? "Primary" : "Secondary"
            };
            dbContext.CustomerAccounts.Add(customerAccount);
            dbContext.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nValidating branch '{branchCode} and customer #{customerId}' ");
            Console.ResetColor();

            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine($"Account {number} created and linked to customer {customerId} as Primary owner. ");
            Console.ResetColor();

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
            Console.Clear();


        }


    }
}
