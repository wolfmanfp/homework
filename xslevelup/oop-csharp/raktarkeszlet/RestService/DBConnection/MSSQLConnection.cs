using System.Data.SqlClient;

namespace RestService.DBTasks
{
    public class MSSQLConnection
    {
        private string connectionString =
            "Data Source=localhost\\SQLEXPRESS;Initial Catalog = RaktarKeszlet; Integrated Security=True";

        private SqlConnection connection;

        private static MSSQLConnection instance;

        public static MSSQLConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MSSQLConnection();
                }
                return instance;
            }
        }

        private MSSQLConnection()
        {
        }

        public SqlConnection GetConnection()
        {
            connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            return connection;
        }
    }
}