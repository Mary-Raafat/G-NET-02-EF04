using G_NET_02_EF04.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_02_EF04.CRUD_operations
{
    public class CustomerAddition
    {
        BankDbContext dbContext = new BankDbContext();

        public void AddCustomer()
        {
            Console.WriteLine("--- Add New Customer ---");

            Console.Write(" Full Name: ");
             string name=Console.ReadLine();

            Console.Write(" National ID: ");
            string Nid=Console.ReadLine();
            if(!(Nid.Length==14&&Nid.All(char.IsDigit)&&(Nid.StartsWith("2")|| Nid.StartsWith("3"))))
            {
                Console.WriteLine(" InValid National ID . Try again");
                return;
            }


            Console.Write("Date of Birth :(yyyy-MM-dd)  ");
            DateTime dob = DateTime.Parse(Console.ReadLine());

            Console.Write(" Email Address :");
            string Email=Console.ReadLine();

            Console.Write(" Phone : ");
            string Phone= Console.ReadLine();
            if (!(Phone.Length == 11))
            {
                Console.WriteLine(" InValid Phone Number . Try again");
                return;
            }

            Console.Write("Address: ");
            string address = Console.ReadLine();
            string[] parts = address.Split('-');
            if (!(parts.Length == 4 && int.TryParse(parts[0], out int num)))
            {
                Console.WriteLine("Invalid Address");
                return;
            }


            Console.WriteLine("Customer Type:");
            Console.WriteLine("1) Individual");
            Console.WriteLine("2) Business");
            Console.Write("Choice: ");


            string type= Console.ReadLine();
            
                if (!(type == "1" || type == "2"))
                {
                    Console.WriteLine("Enter 1 or 2 only");
                return;
                }
            string customerType = "";

            switch (type)
            {
                case "1":
                    customerType = "Individual";
                    break;

                case "2":
                    customerType = "Business";
                    break;

              
            }



            Customer customer =new Customer
            {
                FullName=name,
                NationalId=Nid,
                DateOfBirth=dob,
                Email=Email,
                PhoneNumber=Phone,
                Address=address,
                CustomerType=type
            };

           dbContext.Customers.Add(customer);
            dbContext.SaveChanges();
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nCustomer created successfully. CustomerId = {customer.Id}");
            Console.ResetColor();

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
            Console.Clear();
        }


    }
}