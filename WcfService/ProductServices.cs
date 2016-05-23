using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows;

namespace WcfService
{
    public class ProductServices : IProductServices
    {
        private DataSet dataSet;
        private SqlDataAdapter dataAdapter;
        private DataTable productsTable;

        public bool AuthenticateUser(string name, string password)
        {
            SqlCommand comm = new SqlCommand();
            comm.CommandText = "SELECT Name, Password FROM Users;";
            comm.Connection = DALConnection.GetConnection();
            comm.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
            try
            {
                comm.Connection.Open();
                string passw = (string)comm.ExecuteScalar();

                if (passw == password)
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
                
                throw;
            }
            finally
            {
                comm.Connection.Close();
            }
        }
    
        public int GetProductAmountByID(int id)
        {
            SqlCommand comm = new SqlCommand();
            comm.Connection = DALConnection.GetConnection();
            comm.CommandText = "SELECT Amount FROM Products WHERE ID = @ID;";
            comm.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            try
            {
                comm.Connection.Open();
                int amount = (int)comm.ExecuteScalar();

                return amount;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                comm.Connection.Close();
            }
        }

        public void ModifyProductAmount(int id, int amount)
        {
            SqlCommand comm = new SqlCommand();
            comm.Connection = DALConnection.GetConnection();
            comm.CommandText = "UPDATE Products SET Amount = @Amount WHERE ID = @ID";
            comm.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            comm.Parameters.Add("@Amount", SqlDbType.Int).Value = amount;
            try
            {
                comm.Connection.Open();
                int res = comm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                comm.Connection.Close();
            }
        }

        public void ModifyProductLocation(int id, int newLocId)
        {
            SqlCommand comm = new SqlCommand();
            comm.Connection = DALConnection.GetConnection();
            comm.CommandText = "UPDATE Products SET LocationID = @NewLocID WHERE ID = @ID";
            comm.Parameters.Add("@NewLocID", SqlDbType.Int).Value = newLocId;
            comm.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            try
            {
                comm.Connection.Open();
                int res = comm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                comm.Connection.Close();
            }
        }
    }
}