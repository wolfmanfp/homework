using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace RaktarSzerver
{
    class ProductTasks
    {
        private SqlConnection connection;
        private SqlCommand modifLocation;
        private SqlCommand getProductAmount;
        private SqlCommand modifProductAmount;

        private string modifLocationText =
             "UPDATE Products SET LocationID = @NewLocID WHERE ID = @ID";
        private string getProductAmountText =
            "Select Amount FROM Products WHERE ID = @ID";
        private string modifProductAmountText =
            "UPDATE Products SET Amount = @Amount WHERE ID = @ID";


        public ProductTasks()
        {
            this.connection = DBConnection.Instance.GetConnection();
        }

        public int ModifLocation(int LocID, int ID)
        {
            this.modifLocation = new SqlCommand();
            this.modifLocation.Connection = connection;
            this.modifLocation.CommandText = modifLocationText;
            this.modifLocation.Parameters.Add("@NewLocID", SqlDbType.Int).Value = LocID;
            this.modifLocation.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            try
            {
                connection.Open();
                int res = modifLocation.ExecuteNonQuery();
                connection.Close();
                return res;

            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
        }

        public int GetProductAmount(int ID)
        {
            this.getProductAmount = new SqlCommand();
            this.getProductAmount.Connection = connection;
            this.getProductAmount.CommandText = getProductAmountText;
            this.getProductAmount.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            try
            {
                connection.Open();
                int amount = (int)getProductAmount.ExecuteScalar();
                connection.Close();
                return amount;

            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
        }
        public int ModifProductAmount(int ID, int Amount)
        {
            this.modifProductAmount = new SqlCommand();
            this.modifProductAmount.Connection = connection;
            this.modifProductAmount.CommandText = modifProductAmountText;
            this.modifProductAmount.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            this.modifProductAmount.Parameters.Add("@Amount", SqlDbType.Int).Value = Amount;
            try
            {
                connection.Open();
                int res = modifProductAmount.ExecuteNonQuery();
                connection.Close();
                return res;

            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }


        }
    }
}
