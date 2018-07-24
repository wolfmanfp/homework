using RestService.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RestService.DBTasks
{
    public class MSSQLDatabase : IDatabase
    {
        private SqlConnection connection;

        public MSSQLDatabase()
        {
            connection = MSSQLConnection.Instance.GetConnection();
        }

        public bool AddProduct(string productName, int locID)
        {
            SqlCommand command = new SqlCommand(
                "INSERT INTO Products(Name, LocationID) VALUES (@PName, @LocID);",
                connection);
            command.Parameters.Add("@PName", SqlDbType.VarChar).Value = productName;
            command.Parameters.Add("@LocID", SqlDbType.Int).Value = locID;

            try
            {
                command.Connection.Open();
                int res = command.ExecuteNonQuery();
                if (res == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public bool Authenticate(string user, string pass, int jobID)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT Password FROM Users WHERE Name = @Name AND JobID = @JobID;";
            command.Connection = connection;
            command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = user;
            command.Parameters.Add("@JobID", SqlDbType.Int).Value = jobID;

            try
            {
                connection.Open();
                string passw = (string)command.ExecuteScalar();

                if (passw == pass)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool CheckProduct(string productName)
        {
            SqlCommand command = new SqlCommand(
                "SELECT Name FROM Products WHERE Name = @Name",
                connection);
            command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = productName;

            try
            {
                connection.Open();
                string pname = (string)command.ExecuteScalar();

                if (pname == productName)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public bool DeleteProduct(int productID)
        {
            SqlCommand command = new SqlCommand(
                "DELETE FROM Products WHERE ID = @ProductID;",
                connection);
            command.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;

            try
            {
                command.Connection.Open();
                int res = command.ExecuteNonQuery();
                if (res == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public List<Location> Locations()
        {
            List<Location> locations = new List<Location>();
            SqlCommand command = new SqlCommand(
                "SELECT * FROM Locations;",
                connection);

            try
            {
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Location location = new Location();
                    location.ID = (int)reader["ID"];
                    location.LocationName = (string)reader["LocationName"];
                    locations.Add(location);
                }
                return locations;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public List<Product> Products()
        {
            List<Product> products = new List<Product>();
            SqlCommand command = new SqlCommand(
                "SELECT * FROM Products;",
                connection);

            try
            {
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.ID = (int)reader["ID"];
                    product.Name = (string)reader["Name"];
                    product.LocationID = (int)reader["LocationID"];
                    products.Add(product);
                }
                return products;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public List<Product> ProductsByLocation(int locID)
        {
            List<Product> products = new List<Product>();
            SqlCommand command = new SqlCommand(
                "SELECT * FROM Products WHERE LocationID = @LocID;",
                connection);
            command.Parameters.Add("@LocID", SqlDbType.Int).Value = locID;

            try
            {
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.ID = (int)reader["ID"];
                    product.Name = (string)reader["Name"];
                    product.LocationID = (int)reader["LocationID"];
                    products.Add(product);
                }
                return products;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public bool TransferProduct(int productID, int newLocationID)
        {
            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            comm.CommandText = "UPDATE Products SET LocationID = @NewLocID WHERE ID = @ID";
            comm.Parameters.Add("@NewLocID", SqlDbType.Int).Value = newLocationID;
            comm.Parameters.Add("@ID", SqlDbType.Int).Value = productID;
            try
            {
                comm.Connection.Open();
                int res = comm.ExecuteNonQuery();
                if (res == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                comm.Connection.Close();
            }
        }
    }
}