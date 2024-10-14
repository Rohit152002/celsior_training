using Microsoft.Data.SqlClient;
using System.Data;

namespace DatabaseConnection
{
    internal class Program
    {
        SqlConnection connection= new SqlConnection("Server=5CD413DKPB\\ROHITLAISHRAM;Initial Catalog=Northwind;Integrated Security=True;TrustServerCertificate=True");

        //public Program()
        //{
        //    connection.Open();
        //    Console.WriteLine("Database Connected");
        //}

        void GetProductDetailsFromDatabase()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM Products";
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Name: \t{reader["ProductName"]}");
                    Console.WriteLine($"Price: \t{reader["UnitPrice"]}");
                    Console.WriteLine("======================");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        void CreateUser()
        {
            string username, password;
            Console.Write("Enter user name :- ");
            username = Console.ReadLine();
            Console.Write("Enter password: - ");
            password = Console.ReadLine();

            string insertQuery = $"Insert into Users values ('{username}','{password}')";
            SqlCommand cmd = new SqlCommand(insertQuery,connection);
            try
            {
                connection.Open() ;
                int rowsAffected = cmd.ExecuteNonQuery();
                if(rowsAffected > 0)
                {
                    Console.WriteLine("User Created Successfully");
                }
                else
                {
                    Console.WriteLine("User Creation failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
        }

        void UpdatePassword()
        {
            string username, password, newPassword;
            Console.WriteLine("Enter the username : ");
            username = Console.ReadLine();
            Console.WriteLine("Enter the current password");
            password = Console.ReadLine();
            try
            {
                if(CheckUser(username,password))
                {
                    Console.WriteLine("Please enter your new password");
                    newPassword= Console.ReadLine();   
                    SqlCommand sqlCommand = new SqlCommand($"UPDATE Users SET password=@newpass where username=@un",connection);
                    sqlCommand.Parameters.AddWithValue("@newpass", newPassword);
                    sqlCommand.Parameters.AddWithValue("@un", username);

                    try
                    {
                        connection.Open();
                        int rowsAffected = sqlCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Password Updated Successfully");
                        }
                        else
                        {
                            Console.WriteLine("User Creation failed");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally { connection.Close(); }
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
        }

        bool CheckUser(string username, string password)
        {
            SqlCommand sqlCommand = new SqlCommand($"SELECT * From Users Where Username=@un and Password=@pass", connection);
            try
            {
                connection.Open();
                sqlCommand.Parameters.AddWithValue("@un", username);
                sqlCommand.Parameters.AddWithValue("@pass", password);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    return true;
                } else return false;
            } catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
            finally { connection.Close(); } 
        }

        void UnderstandingDisconnectedArchitecture()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand("Select * from Products", connection);
                Console.WriteLine($"The current connection state is {connection.State}");
            DataSet dataSet = new DataSet();
            try
            {

                adapter.Fill(dataSet);
                Console.WriteLine($"The current connection state is {connection.State}");
                foreach(DataRow row in dataSet.Tables[0].Rows)
                {
                    Console.WriteLine($"Name : {row["ProductName"]}");
                    Console.WriteLine($"Price: {row["UnitPrice"]}");
                    Console.WriteLine("===============================");
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        void GetAllCategories()
        {
            SqlDataAdapter adapter= new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand("Select * from categories",connection);
            DataSet dataSet= new DataSet();
            try
            {

                adapter.Fill(dataSet);
                Console.WriteLine($"The current connection state is {connection.State}");
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    Console.WriteLine($"CategoryId : {row["CategoryID"]}");
                    Console.WriteLine($"Category Name: {row["CategoryName"]}");
                    Console.WriteLine($"Description: {row["Description"]}");
                    Console.WriteLine("===============================");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        void DeleteUser()
        {
            string username;
            Console.WriteLine("Delete the users ");
            Console.Write("Enter user name :- ");
            username = Console.ReadLine();
                SqlCommand sqlCommand = new SqlCommand($"DELETE FROM Users Where username=@user",connection);
            try
            {
                connection.Open();
                sqlCommand.Parameters.AddWithValue("@user", username);
                //SqlDataReader reader = sqlCommand.ExecuteReader();
                int rows= sqlCommand.ExecuteNonQuery();
                if(rows>0)
                {
                    Console.WriteLine("Deleted successfully");
                }
                else
                {
                    Console.WriteLine("failed");
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                connection.Close();
            }

        }
        static void Main(string[] args)
        {
            Program program = new Program();
            //program.GetProductDetailsFromDatabase();
            program.CreateUser();
            //program.UpdatePassword();   
            //program.UnderstandingDisconnectedArchitecture();
            //program.GetAllCategories();
            program.DeleteUser();
            Console.WriteLine("Hello, World!");
        }
    }
}

