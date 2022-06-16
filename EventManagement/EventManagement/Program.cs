using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SuperAdmin superadmin = new SuperAdmin();
           

            Admin admin = new Admin();
            Customer customer = new Customer();
            Console.WriteLine("********************* WELCOME TO MSK EVENT STUDIO *******************");
            while (true)
            {


                Console.WriteLine("Customer press 1");
                Console.WriteLine("Admin press 2");
                Console.WriteLine("SuperAdmin press 3");
                int choice = Convert.ToInt32(Console.ReadLine());


                if (choice == 1)
                {
                    customer.Method();
                }
                else if (choice == 2)
                {
                    admin.Menu();
                }
                
                else if (choice == 3)
                {
                    superadmin.AddAdmin();
                }
                else
                {
                    Console.WriteLine("enter a valid input");
                }

            }
        }
    }
}
