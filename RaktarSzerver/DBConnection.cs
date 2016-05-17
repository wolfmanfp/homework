using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RaktarSzerver
{
    public class DBConnection
    {
        string connectionString =
            "Data Source=localhost\\SQLEXPRESS;Initial Catalog = RaktarKeszlet; Integrated Security=True";
        SqlConnection connection;
        private static DBConnection instance;

        public static DBConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DBConnection();
                }
                return instance;
            }
        }

        private DBConnection() { }

        public  SqlConnection GetConnection()
        {
            connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            return connection;
        }

    }
}
