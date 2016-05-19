using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace RaktarSzerver
{
    public class Authentication
    {
        private SqlConnection connection;
        private string commandText =
            "SELECT Password FROM Users WHERE Name = @Name";
        private SqlCommand command;
        private static Authentication instance;
        public static Authentication Instance{
            get{
                if (instance == null){
                    instance = new Authentication();
                }return instance;
            }
        }

        private Authentication() { }

        public bool Authenticate(string UserName, string Password)
        {
            this.connection = DBConnection.Instance.GetConnection();
            this.command = new SqlCommand();
            this.command.CommandText = commandText;
            this.command.Connection = connection;
            this.command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = UserName;
            try
            {
                connection.Open();
                string passw = (string)command.ExecuteScalar();
                connection.Close();

                if (passw == Password)
                {
                    return true;
                }else {
                    return false;
                }
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
        }
    }
}
