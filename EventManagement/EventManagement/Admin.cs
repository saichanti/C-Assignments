using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace EventManagement
{
    internal class Admin
    {

        public static string dataConstr = @"Data Source=DESKTOP-70LPGGG\MSSQLSERVER01;Initial Catalog=EventManagemnt;Integrated Security=True";
        public void Menu()
        {
            while (true)
            {

                Console.WriteLine("Enter 1 View All Events In Msk EventStudio");
                Console.WriteLine("Enter 2 Add Events");
                Console.WriteLine("Enter 3 Add Decoration Items");
                Console.WriteLine("Enter 4 Add Food Items");

                Console.WriteLine("Enter 5 Add Extra Items");

                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1: ViewEvents(); break;

                    case 2: AddEvent(); break;

                    case 3: AddDecorationItems(); break;

                    case 4: AddFoodItems(); break;

                    case 5: AddExtraItems(); break;

                   

                }
            }
        }

        public void ViewEvents()
        {
            DataTable datatable = new DataTable();
            SqlConnection sqlconnection = new SqlConnection(dataConstr);
            SqlCommand cmd = new SqlCommand("select * from Event", sqlconnection);
            sqlconnection.Open();
            SqlDataReader datareader = cmd.ExecuteReader();
            datatable.Load(datareader);
            sqlconnection.Close();
            Console.WriteLine("Available Events Are");
            Console.WriteLine("Events\t\tPrices");
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                for (int j = 0; j < datatable.Columns.Count; j++)
                {

                    Console.Write(datatable.Rows[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }
        public void AddEvent()
            {

                Console.WriteLine("Enter Event To Add");
                string EventName = Console.ReadLine();
                Console.WriteLine("Price For Event ");
                int price = Convert.ToInt32(Console.ReadLine());

                SqlConnection sqlconnection = new SqlConnection(dataConstr);
                SqlCommand cmd = new SqlCommand("insert into Event values('" + EventName + "','" + price + "')", sqlconnection);
                sqlconnection.Open();
                int result= cmd.ExecuteNonQuery();
                sqlconnection.Close();
                if (result > 0)
                {
                    Console.WriteLine("Event Added ");
                }
            }

        public void AddDecorationItems()
        {
            Console.WriteLine("Enter  Decoration Item");
            string Items = Console.ReadLine();
            Console.WriteLine("Enter  Price ");
            int Prices =Convert.ToInt32( Console.ReadLine());

            SqlConnection sqlConnection = new SqlConnection(dataConstr);
            SqlCommand cmd = new SqlCommand("insert into DecorationItems values('" + Items + "','" + Prices+ "')", sqlConnection);
            sqlConnection.Open();
            int result = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            if (result > 0)
            {
                Console.WriteLine("Items Added ");
            }
        }

        public void AddFoodItems()
        {
            Console.WriteLine("Enter Food To Add");
            string FoodItems = Console.ReadLine();
            Console.WriteLine("Enter Price For Food");
           
            int Prices = Convert.ToInt32(Console.ReadLine());

            SqlConnection sqlconnection = new SqlConnection(dataConstr);
            SqlCommand cmd = new SqlCommand("Insert into FoodItems values('" + FoodItems + "','" + Prices + "')", sqlconnection);
            sqlconnection.Open();
            int result = cmd.ExecuteNonQuery();
            sqlconnection.Close();
            if (result > 0)
            {
                Console.WriteLine("Food Added ");
            }
        }
        public void AddExtraItems()
        {
            Console.WriteLine("Enter ExtraItem to  Add");
            string Items = Console.ReadLine();
            Console.WriteLine("Enter For Price");
            string Discription = Console.ReadLine();
            SqlConnection sq = new SqlConnection(dataConstr);
            SqlCommand cmd = new SqlCommand("insert into ExtraItems values('" + Items+ "','" + Discription + "')", sq);
            sq.Open();
            int result = cmd.ExecuteNonQuery();
            sq.Close();
            if (result > 0)
            {
                Console.WriteLine("Items Added ");
            }
        }

    }
    }

