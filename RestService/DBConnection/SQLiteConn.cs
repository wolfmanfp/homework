using System.Data.SQLite;

namespace RestService.DBTasks
{
    public class SQLiteConn
    {
        private string connectionString =
            "Data Source = @\"Database\\raktar.sqlite\"; Version = 3;";

        private SQLiteConnection connection;

        private static SQLiteConn instance;

        public static SQLiteConn Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SQLiteConn();
                }
                return instance;
            }
        }

        private SQLiteConn()
        {
        }

        public SQLiteConnection GetConnection()
        {
            connection = new SQLiteConnection();
            connection.ConnectionString = connectionString;
            return connection;
        }
    }
}