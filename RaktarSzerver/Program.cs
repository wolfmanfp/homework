using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RaktarSzerver
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Starting server...");
                Console.WriteLine("Connecting SQL server...");
                DBConnection dbConnection = DBConnection.Instance;
                SqlConnection connection = dbConnection.GetConnection();
                connection.Open();
                Console.WriteLine("Connecting SQL server... Success.");
                Console.Read();

            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.Message);
                Console.Read();
            }
        }
    }
}
