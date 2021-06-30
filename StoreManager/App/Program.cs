using System;
using StoreModels;

namespace App
{
    class Program
    {
        static Dictionary<Customer> Customers { get; set; }
        static Dictionary<StoreFront> StoreFronts { get; set; }
        static void Main(string[] args)
        {
            int flag = 0;
            do{
                
                Console.WriteLine("Enter [1] to Manage Customers.");
                Console.WriteLine("Enter [2] to Manage StoreFronts.");
                Console.WriteLine("Enter [0] to Exit.");

                string input =  Console.ReadLine();
                //flag = 0 if conversion to int fails
                bool parsed = int.TryParse(input, out flag);


                switch(flag){
                        case 1:
                            ManageCustomers();
                        break;
                        case 2:
                            ManageStoreFronts();
                        break;
                }
            }while(flag != 0);
        }
        void ManageCustomers()
        {
            int flag = 0;
            do{
                Console.WriteLine("Enter [1] to Add A New Customers.");
                Console.WriteLine("Enter [2] to List All Customers.");
                Console.WriteLine("Enter [3] to Show A Specific Customer's Information.");
                Console.WriteLine("Enter [4] to Edit An Existing Customer's Address.");
                Console.WriteLine("Enter [0] to Exit.");
                switch(flag){
                    case 1:

                    break;
                    case 2:

                    break;
                    case 3:

                    break;
                    case 4:

                    break;
                }


            }while(flag != 0);
            int id = Customers.Count();
            Console.WriteLine("Enter the New Customer's First Name.");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the New Customer's Last Name.");
            string lastName = Console.ReadLine();            
            Customer customer = new Customer(id, firstName, lastName);
            Customers.Add(customer);            
            Console.WriteLine($"The ID of {customer.ToString()} is {id}.");
        }
        void ListCustomers()
        {

        }
        void AddNewCustomer()
        {

        }

        void EditCustomer()
        {

        }
        void ManageStoreFronts()
        {
            int id = StoreFronts.Count();
            Console.WriteLine("Enter the New Store's Name.");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the New Customer's Last Name.");
            string lastName = Console.ReadLine();            
            Customer customer = new Customer(id, firstName, lastName);
            Customers.Add(customer);            
            Console.WriteLine($"The ID of {customer.ToString()} is {id}.");
            
        }
    }
}
