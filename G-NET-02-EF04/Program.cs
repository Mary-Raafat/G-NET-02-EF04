using G_NET_02_EF04;
using G_NET_02_EF04.CRUD_operations;






bool exit = false;
do
{
    Console.WriteLine("=== National Bank - Management ===");
    Console.WriteLine("1) Add a new Customer");
    Console.WriteLine("2) Open a new Account");
    Console.WriteLine("3) Update Account Status (Active / Closed)");
    Console.WriteLine("4) Remove an Account from  a Customer ");
    Console.WriteLine(" 5) List all Customers (With accounts) ");
    Console.WriteLine("0) Exit ");
    Console.WriteLine("---------------------------------");
    Console.WriteLine(" Enter Choice: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
                CustomerAddition customerAddition = new CustomerAddition();
            customerAddition.AddCustomer();
            break;
            case "2":
            OpeningAccount openingAccount = new OpeningAccount();
            openingAccount.OpenAcc();
            break;

        case "0":
            exit = true;
            Console.WriteLine("Goodbye!");
            break;

        default:
            Console.WriteLine("Invalid choice. Try again.");
            break;
    }



} while (!exit);

