using System.Data.SqlClient;

namespace RestService.DBTasks
{
    public class MSSQLConnection
    {
        string connectionString =
            "Data Source=localhost\\SQLEXPRESS;Initial Catalog = RaktarKeszlet; Integrated Security=True";
        SqlConnection connection;

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

        private MSSQLConnection() {}

        public SqlConnection GetConnection()
        {
            connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            return connection;
        }
    }
}