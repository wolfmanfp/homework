using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfService
{
    public static class DALConnection
    {
        private static string connString = @"Data Source = localhost; Initial Catalog = RaktarKeszlet; Integrated Security = true;";
        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }
    }
}