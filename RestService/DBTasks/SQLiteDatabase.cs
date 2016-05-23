using System;
using System.Collections.Generic;
using RestService.Model;
using System.Data;
using System.Data.SQLite;

namespace RestService.DBTasks
{
    public class SQLiteDatabase : IDatabase
    {
        private SQLiteConnection connection;

        public SQLiteDatabase()
        {
            connection = SQLiteConn.Instance.GetConnection();
        }

        public bool AddProduct(string productName, int locID)
        {
            SQLiteCommand command = new SQLiteCommand(
                "INSERT INTO Products(Name, LocationID) VALUES (@PName, @LocID);",
                connection);
            command.Parameters.Add("@PName", DbType.String).Value = productName;
            command.Parameters.Add("@LocID", DbType.Int32).Value = locID;

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

        public bool Authenticate(string user, string pass)
        {
            SQLiteCommand command = new SQLiteCommand(
                "SELECT Password FROM Users WHERE Name = @Name;",
                connection);
            command.Parameters.Add("@Name", DbType.String).Value = user;

            try
            {
                command.Connection.Open();
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
                command.Connection.Close();
            }
        }

        public bool CheckProduct(string productName)
        {
            SQLiteCommand command = new SQLiteCommand(
                "SELECT Name FROM Products WHERE Name = @Name",
                connection);
            command.Parameters.Add("@Name", DbType.String).Value = productName;

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
            SQLiteCommand command = new SQLiteCommand(
               "DELETE FROM Products WHERE ID = @ProductID;",
               connection);
            command.Parameters.Add("@ProductID", DbType.Int32).Value = productID;

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
            SQLiteCommand command = new SQLiteCommand(
                "SELECT * FROM Locations;",
                connection);

            try
            {
                command.Connection.Open();
                SQLiteDataReader reader = command.ExecuteReader();
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
            SQLiteCommand command = new SQLiteCommand(
                "SELECT * FROM Products;",
                connection);

            try
            {
                command.Connection.Open();
                SQLiteDataReader reader = command.ExecuteReader();
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
            SQLiteCommand command = new SQLiteCommand(
                "SELECT * FROM Products WHERE LocationID = @LocID;",
                connection);
            command.Parameters.Add("@LocID", DbType.Int32).Value = locID;

            try
            {
                command.Connection.Open();
                SQLiteDataReader reader = command.ExecuteReader();
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
            SQLiteCommand comm = new SQLiteCommand(
                "UPDATE Products SET LocationID = @NewLocID WHERE ID = @ID;",
                connection);
            comm.Parameters.Add("@NewLocID", DbType.Int32).Value = newLocationID;
            comm.Parameters.Add("@ID", DbType.Int32).Value = productID;
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