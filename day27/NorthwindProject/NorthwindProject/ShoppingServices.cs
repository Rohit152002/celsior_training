using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindProject
{
    internal class ShoppingServices : IServices
    {
        SqlConnection connection = new SqlConnection("Server=5CD413DKPB\\ROHITLAISHRAM;Integrated Security=true;Initial Catalog=NorthWind;TrustServerCertificate=True");

        public void UpdatePassword(string username)
        {
            string password,newPassword;
            Console.WriteLine("Login Process");
           
            Console.Write("Enter your password: - ");
            password = Console.ReadLine();
            string updateQuery = $"update users set password = @newPassword where username=@username and password=@password";
            try
            {

            if (CheckUser(username,password))
            {
                    Console.WriteLine("Please Enter your new Passwords");
                newPassword=Console.ReadLine();
                SqlCommand sqlCommand = new SqlCommand(updateQuery, connection);
                connection.Open();
                sqlCommand.Parameters.AddWithValue("@newPassword", newPassword);
                sqlCommand.Parameters.AddWithValue("@password", password);
                sqlCommand.Parameters.AddWithValue("@username", username);
                    int rowsAffected = sqlCommand.ExecuteNonQuery();
                    if(rowsAffected > 0)
                    {
                        Console.WriteLine("Password Updated Successfully");
                    }else
                    {
                        Console.WriteLine("Operation failed");
                    }
            }
                else
                {
                    Console.WriteLine("Incorrect Password");
                    ServicesInteraction(username);
                }
            }catch (Exception ex)
            {
                throw ex;
            }finally
            {
                connection.Close();
            }

        }

        public void ServicesMenu()
        {
            Console.WriteLine("Please Enter your choice : ");
            Console.WriteLine("1. View Previous Order");
            Console.WriteLine("2. View Order Summary");
            Console.WriteLine("3. Shipper details for given order number");
            Console.WriteLine("4. Update Password");
            Console.WriteLine("0. Exit");
        }

        public void ServicesInteraction(string username)
        {
            int choice = -1;
            try
            {

            do
            {
                ServicesMenu();
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        string customerId = AskCustomerID();
                        ViewPreviousOrder(customerId);
                        break;
                    case 2:
                        ViewOrderSummary();
                        break;
                    case 3:
                        GetShipperDetails();
                        break;
                    case 4:
                        UpdatePassword(username);
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }

            } while (choice != 0);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public string AskCustomerID()
        {
            string customerId=string.Empty;
            Console.Write("Please enter your customer ID:- ");
            customerId = Console.ReadLine();
            return customerId;
        }

        public bool CheckUser(string username,string password)
        {
            string query = $"Select * from Users where username='{username}' and password='{password}'";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                //sqlCommand.Parameters.AddWithValue("@username", username);
                //sqlCommand.Parameters.AddWithValue("@password", password);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public void Login()
        {
            string username, password;
            

            Console.WriteLine("Login Process");
            Console.Write("Enter your username : - ");
            username = Console.ReadLine();
            Console.Write("Enter your password: - ");
            password = Console.ReadLine();

        
            if(CheckUser(username,password))
            {
                Console.WriteLine("Login Successfull");
                ServicesInteraction(username);
            }else
            {
                Console.WriteLine("Login Failed");
            }


        }

        public void Register()
        {
            string username, email, password, phone,customerID;
            Console.WriteLine("Registering Process");

            Console.Write("Please enter your Name : ");
            username = Console.ReadLine();
            Console.Write("Please enter your Email: ");
            email = Console.ReadLine(); 
            Console.Write("Please enter your Phone Number : ");
            phone = Console.ReadLine();

            Console.Write("Please enter your Password: ");
            password= Console.ReadLine();

            string insertQuery = $"Insert into Users (username,email,phone,password) values (@username,@email,@phone,@password)";
            SqlCommand sqlCommand= new SqlCommand(insertQuery,connection);
      
            try
            {
                connection.Open();
                sqlCommand.Parameters.AddWithValue("@username", username);
                sqlCommand.Parameters.AddWithValue("@email", email);
                sqlCommand.Parameters.AddWithValue("@phone", phone);
                sqlCommand.Parameters.AddWithValue("@password", password);
                int rowsAffected = sqlCommand.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Register Succesfully");
                    ServicesInteraction(username);

                }
                else
                {
                    Console.WriteLine("Register failed");
                }

            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }finally
            {
                connection.Close();
            }
        }

        public void ViewOrderSummary()
        {
            int orderId;
            Console.Write("Enter order Id:- ");
            orderId=Convert.ToInt32(Console.ReadLine());

            string viewOrderQuery = $"select od.OrderID as OrderNumber, c.ContactName CustomerName, p.ProductName ProductsOrder  from [Order Details] od join Orders o on  od.OrderID=o.OrderId join Customers c on c.CustomerID=o.CustomerID join Products p on p.ProductID=od.ProductID where o.OrderID=@orderId";

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(viewOrderQuery, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@orderId",orderId);
            DataSet dataSet = new DataSet();
            try
            {
                adapter.Fill(dataSet);
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    Console.WriteLine($"Order Number : {row["OrderNumber"]}");
                    Console.WriteLine($"Customer Name  : {row["CustomerName"]}");
                    Console.WriteLine($"Products Name  : {row["ProductsOrder"]}");
                    Console.WriteLine("===================");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ViewPreviousOrder(string id)
        {
            string previousOrderQuery = $"select* from orders where CustomerID = @id order by OrderDate desc";

            //SqlCommand sqlCommand = new SqlCommand(previousOrderQuery, connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand= new SqlCommand(previousOrderQuery,connection);
            adapter.SelectCommand.Parameters.AddWithValue("@id", id);
            DataSet dataSet = new DataSet();
            try
            {
                adapter.Fill(dataSet);
                foreach( DataRow row in dataSet.Tables[0].Rows )
                {
                    Console.WriteLine($"Order ID: {row["OrderID"]}");
                    Console.WriteLine($"Order Date : {row["OrderDate"]}");
                    Console.WriteLine("===================");
                }
                
            }catch (Exception ex)
            {
                throw ex;
            }

        }

        public void GetShipperDetails()
        {
            int orderId;
            Console.Write("Enter order Id:- ");
            orderId = Convert.ToInt32(Console.ReadLine());
            string getShipperQuery = $"select * from Shippers where ShipperID = (Select shipVia from Orders where OrderID=@orderId)";

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand= new SqlCommand(getShipperQuery,connection);
            adapter.SelectCommand.Parameters.AddWithValue("@orderId", orderId);
            DataSet dataSet = new DataSet();
            try
            {
                adapter.Fill(dataSet);
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    Console.WriteLine("===================");
                    Console.WriteLine($"Shipper Details : {row["ShipperID"]}");
                    Console.WriteLine($"Company Name  : {row["CompanyName"]}");
                    Console.WriteLine($"Phone Number  : {row["Phone"]}");
                    Console.WriteLine("===================");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
