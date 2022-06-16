using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace EventManagement
{
    internal class Customer
    {
        public static string dataConstr = @"Data Source=DESKTOP-70LPGGG\MSSQLSERVER01;Initial Catalog=EventManagemnt;Integrated Security=True";
        int CusId;
        public void Method()
        {
            Console.WriteLine("Enter 1  Registration");
            Console.WriteLine("Enter 2  Login");

            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                Register();

            }
            else if (choice == 2)
            {
                Login();
            }
            else
            {

            }


        }
        public void Register()
        {
            Console.WriteLine("Enter CustId");
            int CustId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name");
            string Name = Console.ReadLine();

            Console.WriteLine("Enter Address");
            string Address = Console.ReadLine();
            Console.WriteLine("Enter Mobile");
            int Mobile = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("password");
            string password = Console.ReadLine();

            string quary = ("insert into customerss values(" + CustId + ",'" + Name + "'," + Mobile + ",'" + Address + "', '" + password + "')");
            SqlConnection sqlconnection = new SqlConnection(dataConstr);
            SqlCommand cmd = new SqlCommand(quary, sqlconnection);
            sqlconnection.Open();
           

            sqlconnection.Close();
            int res = cmd.ExecuteNonQuery();
            sqlconnection.Close();
            if (res > 0)
            {
                Console.WriteLine("successfully registered");
            }
        }
        public void Login()
        {
            DataTable dt = new DataTable();
            Console.WriteLine("Enter Your Name");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter password");
            string password = Console.ReadLine();

            SqlConnection sqlconnection = new SqlConnection(dataConstr);
            SqlCommand cmd = new SqlCommand("select * from customer where Name='" + Name + "' and password='" + password + "'", sqlconnection);
            sqlconnection.Open();
            SqlDataReader datareader = cmd.ExecuteReader();
            dt.Load(datareader);
            sqlconnection.Close();
            if (dt.Rows.Count > 0)
            {
                Console.WriteLine("Welcome  " + dt.Rows[0][1]);
                CusId = (int)dt.Rows[0][0];
                Menu();

            }
            else
            {
                Console.WriteLine("either username or password is wrong");
                return;
            }



        }

        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("enter 1  View All Events");
               
                Console.WriteLine("Enter 2  Choose Event");

                Console.WriteLine("Enter 3 View All Food Items");

                Console.WriteLine("Enter 4  Choose FoodItems");

                Console.WriteLine("enter 5  View All DecorationItems ");

                Console.WriteLine("Enter 6  Choose DecorationItems");


                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1: ViewEvents(); break;
                   
                    case 2: ChooseEvent(); break;
                    case 3: ViewFoodItems(); break;
                    case 4: ChooseFoodItems(); break;
                    case 5: ViewDecorationItems(); break;
                    case 6: ChooseDecorationItems(); break;
                   
                    default: Console.WriteLine("enter a valid input"); break;

                }
            }

        }

        public void ViewEvents()
        {
           
            SqlConnection sqlconnection = new SqlConnection(dataConstr);
            SqlDataAdapter adp = new SqlDataAdapter("select * from Event", sqlconnection);
            DataTable datatable = new DataTable();

          
            adp.Fill(datatable);
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
        public void ChooseEvent()
        {
            int cid = CusId;
            ViewEvents();

            try
            {
                Console.WriteLine("Enter Event number");
                int Eventid = Convert.ToInt32(Console.ReadLine());
                SqlConnection sq = new SqlConnection(dataConstr);
                SqlCommand cmd = new SqlCommand("insert into EventChoose values(" + cid + ",'" + Eventid + "')", sq);
                sq.Open();
                int res = cmd.ExecuteNonQuery();
                sq.Close();
                if (res > 0)
                {
                    Console.WriteLine("Event choosed");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Enter  valid Event ");
            }

        }
        public void ViewFoodItems()
        {

            SqlConnection sqlconnection = new SqlConnection(dataConstr);
            SqlDataAdapter adp = new SqlDataAdapter("select * from FoodItems", sqlconnection);
            DataTable datatable = new DataTable();


            adp.Fill(datatable);
            Console.WriteLine("Available FoodItems Are");
            Console.WriteLine("FoodItems\t\tPrices");
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                for (int j = 0; j < datatable.Columns.Count; j++)
                {

                    Console.Write(datatable.Rows[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }
        public void ChooseFoodItems()
        {
            int cid = CusId;
            ViewFoodItems();

            try
            {
                Console.WriteLine("Enter FoodItem number");
                int Foodid = Convert.ToInt32(Console.ReadLine());
                SqlConnection sq = new SqlConnection(dataConstr);
                SqlCommand cmd = new SqlCommand("insert into FoodChoose values(" + cid + ",'" + Foodid + "')", sq);
                sq.Open();
                int res = cmd.ExecuteNonQuery();
                sq.Close();
                if (res > 0)
                {
                    Console.WriteLine("Food choosed");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Enter  valid Food ");
            }

        }
        public void ViewDecorationItems()
        {

            SqlConnection sqlconnection = new SqlConnection(dataConstr);
            SqlDataAdapter adp = new SqlDataAdapter("select * from DecorationItems", sqlconnection);
            DataTable datatable = new DataTable();


            adp.Fill(datatable);
            Console.WriteLine("Available DecorationItems Are");
            Console.WriteLine("DecorationItems\t\tPrices");
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                for (int j = 0; j < datatable.Columns.Count; j++)
                {

                    Console.Write(datatable.Rows[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }
        public void ChooseDecorationItems()
        {
            int cid = CusId;
            ViewEvents();

            try
            {
                Console.WriteLine("Enter Event number");
                int Decid = Convert.ToInt32(Console.ReadLine());
                SqlConnection sq = new SqlConnection(dataConstr);
                SqlCommand cmd = new SqlCommand("insert into ChooseDecorationItems values(" + cid + ",'" + Decid + "')", sq);
                sq.Open();
                int res = cmd.ExecuteNonQuery();
                sq.Close();
                if (res > 0)
                {
                    Console.WriteLine("DecorationItems choosed");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Enter  valid DecorationItem ");
            }

        }
    }
}
