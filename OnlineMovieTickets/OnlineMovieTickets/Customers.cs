using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMovieTickets
{
    internal class Customers
    {
        public int customerId;
        string customerName, movieName, location;
      
        Admin admin = new Admin();
        public void BookMovieTicket()
        {
            Console.WriteLine("Enter Your  customer Id");
            customerId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Your name");
            customerName = Console.ReadLine();

            

            Console.WriteLine("Enter movie name to book.");
            movieName = Console.ReadLine();

            Console.WriteLine("Enter the location");
            movieName = Console.ReadLine();


            admin.CustomerDetails(customerId, customerName, movieName, location);
            Console.WriteLine("Thanks for booking, Enjoy The Movie");
            


        }
    }
}
