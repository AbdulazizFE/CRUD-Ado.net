using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Mydata
{
    class Program
    {
        static void Main(string[] args)
        {

                string ConnectionString =
             @"Data Source=DESKTOP-50TBLQQ;Initial Catalog=TelerikAcademy98;Integrated Security=True";
            bool option = true;
            do
            {
                try
                {

                    SqlConnection conn = new SqlConnection(ConnectionString);
                    conn.Open();
                    //Console.WriteLine("Established connection");
                Console.WriteLine("Select from the options bbelow\n1.Add customer.\n2.Retrieve" +
                    " \n3.Update\n4.Delete by id\n5.Add a new order\n6.To Show Country Sales" +
                    "\n7.To delete customer by id\n0.Exit");
                int choice = int.Parse(Console.ReadLine());
                    Console.Clear();
                    switch (choice)
                {

                        case 1:

                            //Create
                            Console.WriteLine("Enter customer id: ");
                            string customerID = Console.ReadLine();
                            Console.WriteLine("Enter company name: ");
                            string companyName = Console.ReadLine();
                            Console.WriteLine("Enter contact name: ");
                            string contactName = Console.ReadLine();
                            Console.WriteLine("Enter contact title: ");
                            string contactTitle = Console.ReadLine();
                            Console.WriteLine("Enter address: ");
                            string address = Console.ReadLine();
                            Console.WriteLine("Enter city: ");
                            string city = Console.ReadLine();
                            Console.WriteLine("Enter region: ");
                            string region = Console.ReadLine();
                            Console.WriteLine("Enter postal code: ");
                            string postalCode = Console.ReadLine();
                            Console.WriteLine("Enter country: ");
                            string country = Console.ReadLine();
                            Console.WriteLine("Enter phone: ");
                            string phone = Console.ReadLine();
                            Console.WriteLine("Enter fax: ");
                            string fax = Console.ReadLine();

                            string query = "insert into Customers" +
                            " (CustomerID,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax) " +
                            "values('" + customerID + "','" + companyName + "'" +
                             ",'" + contactName + "','" + contactTitle + "' ,'" + address + "'," +
                             "'" + city + "','" + region + "','" + postalCode + "','" + country + "','" + phone + "','" + fax + "')";
                            SqlCommand insertCommand = new SqlCommand(query, conn);
                            insertCommand.ExecuteNonQuery();
                            Console.WriteLine("-----Data is successfully inserted into table!");

                            break;

                        case 2:
                            //Retrieve 
                            string displayQuery = "select * from Customers";

                            SqlCommand displayCommand = new SqlCommand(displayQuery, conn);
                            SqlDataReader dataReader = displayCommand.ExecuteReader();
                            while (dataReader.Read())
                            {
                                 
                                Console.WriteLine("Customer ID :   ---> " + dataReader.GetValue(0).ToString());
                                Console.WriteLine("CompanyName : ---> " + dataReader.GetValue(1).ToString());
                                Console.WriteLine("ContactName :  ---> " + dataReader.GetValue(2).ToString());
                                Console.WriteLine("ContactTitle :  ---> " + dataReader.GetValue(3).ToString());
                                Console.WriteLine("Address :  ---> " + dataReader.GetValue(4).ToString());
                                Console.WriteLine("City :  ---> " + dataReader.GetValue(5).ToString());
                                Console.WriteLine("Region :  ---> " + dataReader.GetValue(6).ToString());
                                Console.WriteLine("PostalCode :  ---> " + dataReader.GetValue(7).ToString());
                                Console.WriteLine("Country :  ---> " + dataReader.GetValue(8).ToString());
                                Console.WriteLine("Phone :  ---> " + dataReader.GetValue(9).ToString());
                                Console.WriteLine("Fax :  ---> " + dataReader.GetValue(10).ToString());
                               

                            }
                            dataReader.Close();
                            break;

                        case 3:
                            //Update

                            int u_id;
                            
                            Console.WriteLine("Enter your id that you would like to update");
                            u_id = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the address of the user to update");
                            string u_address = (Console.ReadLine());
                            string updateQuery = "update Customers Set Address = '" + u_address + "' WHERE CustomerID = '" + u_id + "'";
                            SqlCommand updateCommand = new SqlCommand(updateQuery, conn);
                            updateCommand.ExecuteNonQuery();
                            Console.WriteLine("Data updated successfully");
                           
                            break;

                        case 4:

                            //Delete 
                            
                            Console.WriteLine("Enter the id of the customer that is to be deleted");
                           string d_id = (Console.ReadLine());
                            string deletQuery = "delete from Customers where CustomerID = '" + d_id + "'";
                            SqlCommand deletCommand = new SqlCommand(deletQuery, conn);
                            deletCommand.ExecuteNonQuery();
                            Console.WriteLine("Deleted successfully"); 

                            break;

                        case 5:

                            //New order
                            Console.WriteLine("Enter Customer ID: ");
                            string customerid = Console.ReadLine();
                            Console.WriteLine("Enter  Employee ID: ");
                            int employeeID = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Order Date: ");
                            string orderDate = Console.ReadLine();
                            Console.WriteLine("Enter Required Date: ");
                            int requiredDate = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Shipped Date: ");
                            string shippedDate = Console.ReadLine();
                            Console.WriteLine("Enter Ship Via: ");
                            int shipVia = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Freight: ");
                            int freight = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter ship name: ");
                            string shipName = Console.ReadLine();
                            Console.WriteLine("Enter ship address: ");
                            string shipAddress = Console.ReadLine();
                            Console.WriteLine("Enter ship city: ");
                            string shipCity = Console.ReadLine();
                            Console.WriteLine("Enter ship region: ");
                            string shipRegion = Console.ReadLine();
                            Console.WriteLine("Enter ship postal code: ");
                            string shipPostalCode = Console.ReadLine();
                            Console.WriteLine("Enter ship country: ");
                            string shipCountry = Console.ReadLine();

                            string query2 = "insert into Orders (CustomerID,EmployeeID,OrderDate,RequiredDate,ShippedDate,ShipVia," +
                                "Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry) " +
                                "values('" + customerid + "','" + employeeID + "', '" + orderDate + "','" + requiredDate + "' ," +
                                "'" + shippedDate + "','" + shipVia + "','" + freight + "','" + shipName + "','" + shipAddress + "'," +
                                "'" + shipCity + "','" + shipRegion + "','" + shipPostalCode + "','" + shipCountry + "')";

                            SqlCommand insertCommand2 = new SqlCommand(query2, conn);
                            insertCommand2.ExecuteNonQuery();
                            Console.WriteLine("-----Data is successfully inserted into table!------");
                            break;

                        case 6:

                            //Show Country Sales
                            string displayQuery2 = "select * from Customers c INNER JOIN Orders o ON o.CustomerID = c.CustomerID  " +
                                "INNER JOIN [Order Details] od  ON od.OrderID = o.OrderID";
                            SqlCommand displayCommand2 = new SqlCommand(displayQuery2, conn);
                            SqlDataReader dataReader2 = displayCommand2.ExecuteReader();
                            while (dataReader2.Read())
                            {
                                Console.WriteLine("Customer id :    ---> " + dataReader2.GetValue(0).ToString());
                                Console.WriteLine("Company Name:    ---> " + dataReader2.GetValue(1).ToString());
                                Console.WriteLine("Contact Name :   ---> " + dataReader2.GetValue(2).ToString());
                                Console.WriteLine("Contact title :  ---> " + dataReader2.GetValue(3).ToString());
                                Console.WriteLine("Address :     ---> " + dataReader2.GetValue(4).ToString());
                                Console.WriteLine("City :  ---> " + dataReader2.GetValue(5).ToString());
                                Console.WriteLine("Postal code:    ---> " + dataReader2.GetValue(6).ToString());
                                Console.WriteLine("Country:    ---> " + dataReader2.GetValue(6).ToString());
                                Console.WriteLine("Phone:    ---> " + dataReader2.GetValue(6).ToString());
                                Console.WriteLine("Fax:    ---> " + dataReader2.GetValue(6).ToString());
                                Console.WriteLine("Order id:    ---> " + dataReader2.GetValue(6).ToString());
                                Console.WriteLine("Customer id :    ---> " + dataReader2.GetValue(6).ToString());
                                Console.WriteLine("Employee id :    ---> " + dataReader2.GetValue(6).ToString());
                                Console.WriteLine("Order date :    ---> " + dataReader2.GetValue(6).ToString());
                                Console.WriteLine("Required date :    ---> " + dataReader2.GetValue(6).ToString());
                                Console.WriteLine("Shipped date :    ---> " + dataReader2.GetValue(6).ToString());
                                Console.WriteLine("Ship via :    ---> " + dataReader2.GetValue(6).ToString());
                                Console.WriteLine("Freight :    ---> " + dataReader2.GetValue(6).ToString());
                                Console.WriteLine("Ship name :    ---> " + dataReader2.GetValue(6).ToString());
                                Console.WriteLine("Ship address :    ---> " + dataReader2.GetValue(6).ToString());
                                Console.WriteLine("Ship city :    ---> " + dataReader2.GetValue(6).ToString());
                                Console.WriteLine("Ship region :    ---> " + dataReader2.GetValue(6).ToString());
                                Console.WriteLine("Ship postal code :    ---> " + dataReader2.GetValue(6).ToString());
                                Console.WriteLine("Ship country :    ---> " + dataReader2.GetValue(6).ToString());
                                Console.WriteLine("order id :    ---> " + dataReader2.GetValue(6).ToString());
                                Console.WriteLine("Product id :    ---> " + dataReader2.GetValue(6).ToString());
                                Console.WriteLine("Unit price :    ---> " + dataReader2.GetValue(6).ToString());
                                Console.WriteLine("Quantity :    ---> " + dataReader2.GetValue(6).ToString());
                                Console.WriteLine("Discount :    ---> " + dataReader2.GetValue(6).ToString());

                            }
                            dataReader2.Close();
                            break;


                        case 7:
                            //Delete order
                            Console.Clear();
                            Console.WriteLine("Enter the id of the customer that is to be deleted");
                            int C_id =Convert.ToInt32(Console.ReadLine());
                            string deletquery2 = "delete from Orders where CustomerID =  '" + C_id + "'";
                            SqlCommand deletcommand = new SqlCommand(deletquery2, conn);
                            deletcommand.ExecuteNonQuery();
                            Console.WriteLine("-----Deleted successfully------");

                            break;


                        case 0:
                            Console.WriteLine("You've decided to quit.");
                            option = false;
                            break;


                        default:
                            Console.WriteLine("Please insert either 1,2,3,4,5,6,7 or 0.");
                            break;
                }
                conn.Close();
            }

            

                catch (Exception e)
                {
                    Console.WriteLine(e);

                }
                Console.ReadKey();
            } while (option);


           
        }

       

        }
}


