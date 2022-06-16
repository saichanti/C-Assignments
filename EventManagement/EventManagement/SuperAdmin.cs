using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace EventManagement
{
    internal class SuperAdmin
    {
        
        public static string dataConstr = @"Data Source=DESKTOP-70LPGGG\MSSQLSERVER01;Initial Catalog=EventManagemnt;Integrated Security=True";
        public void method()
        {

        }
        public void AddAdmin()
        {
            Console.WriteLine("Enter Name Of Admin");
            string AdminName = Console.ReadLine();
            Console.WriteLine("Enter Password");
            string password = Console.ReadLine();
           
            SqlConnection sqlconnection = new SqlConnection(dataConstr);
            SqlCommand cmd = new SqlCommand("insert into admin values('" + AdminName + "','" + password + "')", sqlconnection);
            sqlconnection.Open();
            int result = cmd.ExecuteNonQuery();
            sqlconnection.Close();
            if (result > 0)
            {
                Console.WriteLine("successfully registered");
            }


        }
    }
}
