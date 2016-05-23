using System;
using System.Collections.Generic;
using RestService.Model;
using System.Data;
using System.Data.SqlClient;

namespace RestService.DBTasks
{
    public class MSSQLDatabase : IDatabase
    {
        private SqlConnection connection;

        public MSSQLDatabase()
        {
            this.connection = (SqlConnection)MSSQLConnection.Instance.GetConnection();
        }

        public bool AddProduct(string productName, int locID)
        {
            throw new NotImplementedException();
        }

        public bool Authenticate(string user, string pass)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT Password FROM Users WHERE Name = @Name";
            command.Connection = connection;
            command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = user;
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
            throw new NotImplementedException();
        }

        public bool DeleteProduct(int productID)
        {
            throw new NotImplementedException();
        }

        public List<Location> Locations()
        {
            throw new NotImplementedException();
        }

        public List<Product> Products()
        {
            throw new NotImplementedException();
        }

        public List<Product> ProductsByLocation(int locID)
        {
            throw new NotImplementedException();
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
                } else
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