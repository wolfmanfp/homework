using System.Data.SQLite;

namespace RestService.DBTasks
{
    public class SQLiteConn
    {
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
            string relativePath = @"Database\raktar.sqlite";
            string currentPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            string absolutePath = System.IO.Path.Combine(currentPath, relativePath).Remove(0, 6);

            connection = new SQLiteConnection();
            connection.ConnectionString = string.Format("Data Source={0}; Version = 3;", absolutePath);
            return connection;
        }
    }
}