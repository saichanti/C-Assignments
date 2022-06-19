using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;

namespace SaiTask
{
    class Program
    {
        static string connectionString = @"Data Source=DESKTOP-70LPGGG\MSSQLSERVER01;Initial Catalog=SAIDB;Integrated Security=True";
        static SqlConnection con = new SqlConnection(connectionString);
        static SqlCommand command;



        void AddItem()
        {
            string itemName = null, check; ;
            decimal rate = 0;
            int quantity;

         itemLabel:   Console.Write("Enter item name:");
            itemName = Console.ReadLine();
            while (!(Regex.IsMatch(itemName,"^[a-zA-Z. ]{3,20}$")))
            {
                Console.Write("Item Name Cannot be Empty..Enter item Name: ");
                itemName = Console.ReadLine();


            }


            if (ItemAlreadyExistOrNot(itemName))
            {
                Console.WriteLine("Item already Exists...please enter another item Name");
                goto itemLabel;
            }
            


            Console.Write("Enter item rate:");
        rateLabel: check = Console.ReadLine();
            while (!(Decimal.TryParse(check, out rate)))
            {
                Console.Write("Item rate Cannot be Empty or Invalid..Enter item rate: ");
                check = Console.ReadLine();
            }

            if (rate < 0)
            {
                Console.Write("rate Cannot be less than Zero. Enter rate:");
                goto rateLabel;
            }



            Console.Write("Enter item quantity:");
        quanitiyLabel: check = Console.ReadLine();
            while (!(int.TryParse(check, out quantity)))
            {
                Console.Write("Item quantity  Cannot be Empty or Invalid..Enter quantity: ");
                check = Console.ReadLine();

            }
            if (quantity <= 0)
            {
                Console.Write("Quantity Cannot be Zero or less than Zero. Enter quantiy:");
                goto quanitiyLabel;
            }



            command = new SqlCommand("Usp_AddItem", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@itemName", itemName);
            command.Parameters.AddWithValue("@rate", rate);
            command.Parameters.AddWithValue("@quantity", quantity);

            con.Open();
            int rowsAffected = command.ExecuteNonQuery();


            if (rowsAffected > 0)
                Console.WriteLine("\nItem Added Successfully.");
            else
                Console.WriteLine("Something Went Wrong.Please Try Again");

            con.Close();
            command.Dispose();

        }

        void ListItem()
        {
            command = new SqlCommand("Usp_ListItem", con);
            con.Open();
            SqlDataReader dr = command.ExecuteReader();
            Console.WriteLine("Item Name" + "Rate".PadLeft(25) + "Quantity".PadLeft(12));
            Console.WriteLine("".PadLeft(50, '-'));

            while (dr.Read())
            {
                Console.WriteLine(dr[0].ToString() + dr[1].ToString().PadLeft(18) + dr[2].ToString().PadLeft(12));
            }
            Console.WriteLine("\n");
            con.Close();
            command.Dispose();

        }

        void UpdateItem()
        {
            string itemName, variable;
            decimal rate=0;
            int quantity=0;
            Console.Write("Enter item name to update:");
            itemName = Console.ReadLine();
            string selectCommand = "select * from ItemMaster where itemname = '" + itemName+"'";

            command = new SqlCommand(selectCommand, con);
            con.Open();

            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                Console.WriteLine("Item Name: {0}\n Rate: {1}\n Quantity: {2}",dr[0],dr[1],dr[2]);
                rate = Convert.ToDecimal(dr[1].ToString());
                quantity = Convert.ToInt32(dr[2].ToString());

                ratelabel: Console.Write("Enter Item Rate To Update(Press Enter if you don't want to update):");
                variable = Console.ReadLine();
                if (variable != "")
                {
                    if(Convert.ToDecimal(variable) < 0)
                    {
                        Console.WriteLine("Item Rate Is Invalid Cannot be In negative Value");
                        goto ratelabel;
                    }

                    rate = Convert.ToDecimal(variable);



                }
                
                 
                quantityLabel: Console.WriteLine("Enter Quantity To Update(Press Enter if you don't want to update):");
                variable = Console.ReadLine();
                if (variable != "")
                {
                    if (Convert.ToInt32(variable) < 1)
                    {
                        Console.Write("Item Quantity Is Invalid Cannot be In negative Value or Zero"); 
                        goto quantityLabel;
                    }
                    quantity = Convert.ToInt32(variable);

                }
                

                command.Dispose();
                dr.Close();
               
                command = new SqlCommand("Usp_UpdateItem",con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@itemName", itemName);
                command.Parameters.AddWithValue("@rate", Convert.ToDecimal(rate));
                command.Parameters.AddWithValue("@quantity", Convert.ToInt32(quantity));
                int rowsAffexted = command.ExecuteNonQuery();
                if (rowsAffexted > 0)
                    Console.WriteLine("Item Details Updated Successfully");
                else
                {
                    Console.WriteLine("Oops! Something Went Wrong..PLease Try Again.");
                }
                
                command.Dispose();
            }
            else
            {
                Console.WriteLine("Sorry Item Doesn't Exists ");
            }
            con.Close();
        }


        void DeleteItem()
        {
            string itemName;
            char choice;

            Console.Write("Enter item name to Delete:");
            itemName = Console.ReadLine();
            string selectCommand = "select * from ItemMaster where itemname = '" + itemName + "'";

            command = new SqlCommand(selectCommand, con);
            con.Open();

            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                Console.WriteLine("Item Name: {0}\n Rate: {1}\n Quantity: {2}", dr[0], dr[1], dr[2]);
                Console.Write("Do You Want To Delete The Item(Y/N)");
                choice = Convert.ToChar(Console.ReadLine());

                command.Dispose();
                dr.Close();
                if(choice == 'Y' || choice == 'y')
                {

                    string deleteCommand = "Delete from ItemMaster where Itemname = '" + itemName +"'";
                    command = new SqlCommand(deleteCommand, con);
                    
                    int rowsAffected = command.ExecuteNonQuery();   
                    if(rowsAffected > 0)
                        Console.WriteLine("Item Deleted Successfully");
                    else
                        Console.WriteLine("Something Went Wrong");

                    command.Dispose();
                }
                else
                {
                    Console.WriteLine("Item Not Deleted..");
                }

            }
            else
            {
                Console.WriteLine("Item Not found");
            }
           
            con.Close();
        }


        internal bool ItemAlreadyExistOrNot(string ItemName)
        {
            DataTable dataTable = new DataTable();
            string query = "select * from itemmaster where ItemName='" + ItemName + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }




        static void Main(string[] args)
        {

            int choice;
            Program p = new Program();
            //forever loop to display the menu until the user press exit option.
            while (true)
            {
                //Menu Option
                Console.WriteLine("--------------Item Master----------------");
                Console.WriteLine("1.Add\n2.Update\n3.List\n4.Delete\n5.Exit");
                Console.Write("please choose an option: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1://To add the item master
                        p.AddItem();
                        break;

                    case 2:
                        p.UpdateItem();
                        break;

                    case 3:
                        p.ListItem();

                        break;

                    case 4:
                        p.DeleteItem();
                        break;

                    case 5:
                        Console.WriteLine("Exiting......");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please choose the valid Option");
                        break;
                }

            }



        }
    }
}
