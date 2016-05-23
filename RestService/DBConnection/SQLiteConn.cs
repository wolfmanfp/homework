using System.Data.SQLite;

namespace RestService.DBTasks
{
    public class SQLiteConn: IConnection
    {
        string connectionString =
            "Data Source = @\"Database\\raktar.sqlite\"; Version = 3;";
        SQLiteConnection connection;

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

        private SQLiteConn() { }

        public object GetConnection()
        {
            connection = new SQLiteConnection();
            connection.ConnectionString = connectionString;
            return connection;
        }
    }
}