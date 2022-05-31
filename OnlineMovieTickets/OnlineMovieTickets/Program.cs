using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMovieTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*********************** ONLINE MOVIE TICKET BOOKING SYSTEM ***************************");
            Admin admin = new Admin();
            admin.AvailableMovies();
            Console.WriteLine("IF u r User Press 1");
            Console.WriteLine("IF u r Admin Press 2");
            Console.WriteLine("1. Users");
            Console.WriteLine("2. Admin");
            Console.WriteLine("");

            int choise = Convert.ToInt32(Console.ReadLine());
            Admin admin1 = new Admin();
            Customers customers = new Customers();

            
            switch (choise)
            {
                case 1:
                    Console.WriteLine("************************* WELCOME USER **************************");
                    Console.WriteLine("");
                    Console.WriteLine("a. Available movies");
                    Console.WriteLine("b. Book a movie");


                    char choise1 = Convert.ToChar(Console.ReadLine());
                    switch (choise1)
                    {
                        case 'a':
                            Console.WriteLine("");
                            admin1.AvailableMovies();
                           
                            Console.ReadLine();


                            break;
                        case 'b':

                            Console.WriteLine("");
                            customers.BookMovieTicket();
                            Console.ReadLine();
                            break;
                    }
                    break;
            
            case 2:
                Console.WriteLine("*************************** WELCOME  ADMIN ***************************");
                Console.WriteLine("");
                Console.WriteLine("a. Available Movies");
                Console.WriteLine("b. Add a Movie");


                char choise2 = Convert.ToChar(Console.ReadLine());
                switch (choise2)
                {
                    case 'a':
                        Console.WriteLine("");
                            admin1.AvailableMovies();

                            break;
                    case 'b':
                       
                            admin1.AddMovies();
                           
                        Console.ReadLine();

                        break;

                }
                break;

            }

        }
    }
}
