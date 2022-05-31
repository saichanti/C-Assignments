using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OnlineMovieTickets
{
    public class Admin
    {
        int movieId;
        string MovieName, HeroName;
        string bookingDate, location;
        public void AddMovies()
        {
            FileStream fileStreamObj = new FileStream(@"C:\Users\Sai Kumar\Desktop\C# Trining\OnlineMovieTickets\OnlineMovieTickets\movieDetails.txt", FileMode.Append, FileAccess.Write);
            StreamWriter streamWriterObj = new StreamWriter(fileStreamObj);

            int counter = 1, Movies;
            Console.WriteLine("Enter number Of Movies you Add");
            Movies = Convert.ToInt32(Console.ReadLine());


            while (counter <= Movies)
            {

                Console.WriteLine("Enter HeroName.");
                HeroName = Console.ReadLine();
                streamWriterObj.WriteLine(HeroName);

                Console.WriteLine("Enter Movie ID");
                movieId = Convert.ToInt32(Console.ReadLine());
                streamWriterObj.Write(movieId + ",");

                Console.WriteLine("Enter Movie name.");
                MovieName = Console.ReadLine();
                streamWriterObj.Write(MovieName + ",");

                Console.WriteLine("Enter Location");
                location = Console.ReadLine();
                streamWriterObj.Write(location + ",");



                counter++;
            }
            streamWriterObj.Close();
            fileStreamObj.Close();


        }
        public void CustomerDetails(int customerId, String customerName,  string movieName, string location)
        {
            FileStream fileStreamObj = new FileStream(@"C:\Users\Sai Kumar\Desktop\C# Trining\OnlineMovieTickets\OnlineMovieTickets\CustomersDetails.txt", FileMode.Append, FileAccess.Write);
            StreamWriter streamWriterObj = new StreamWriter(fileStreamObj);

            streamWriterObj.Write(customerId + ",");
            streamWriterObj.Write(customerName + ",");
            streamWriterObj.Write(movieName + ",");
            streamWriterObj.Write(location);


            bookingDate = DateTime.Now.ToShortDateString();
            streamWriterObj.WriteLine(bookingDate);

            streamWriterObj.Close();
            fileStreamObj.Close();

           


        }
        public void AvailableMovies()
        {

            try
            {


                if (!File.Exists(@"C:\Users\Sai Kumar\Desktop\C# Trining\OnlineMovieTickets\OnlineMovieTickets\movieDetails.txt"))
                {
                    Console.WriteLine("Movie Not Available");
                }
                else
                {

                    FileStream fileStreamObj = new FileStream(@"C:\Users\Sai Kumar\Desktop\C# Trining\OnlineMovieTickets\OnlineMovieTickets\movieDetails.txt", FileMode.Open, FileAccess.Read);
                    StreamReader streamReaderObj = new StreamReader(fileStreamObj);
                    Console.WriteLine("HeroName\t\tMovieId\t\tMovieName\t\tlocation");
                    while (streamReaderObj.Peek() > 0)
                    {
                        string line = streamReaderObj.ReadLine();
                        string[] moviesArr = line.Split(',');

                        for (int i = 0; i < moviesArr.Length; i++)
                        {
                            Console.Write(moviesArr[i] + "\t\t");
                            if (i == 1)
                            {
                                Console.Write("");
                            }
                        }
                        Console.WriteLine("");
                    }
                    streamReaderObj.Close();
                    fileStreamObj.Close();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR 404");
               
            }

        }

    }
}