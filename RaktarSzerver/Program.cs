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
                Console.WriteLine("Starting...");
                Console.WriteLine("Connecting SQL server...");
                DBConnection dbConnection = DBConnection.Instance;
                SqlConnection connection = dbConnection.GetConnection();
                connection.Open();
                Console.WriteLine("Connecting SQL server... Success.");
                ProductTasks productTasks = new ProductTasks();

                Console.WriteLine("Test methods:");
                Login("peter", "1234");

                #region modify location

                Console.WriteLine("Modify Location ID:");
                int result = productTasks.ModifLocation(2, 1);
                Console.WriteLine("Server returns with:" + result.ToString());
                Console.ReadKey();

                #endregion

                #region product amount

                Console.WriteLine("Get product amount by product ID:");
                int amount = productTasks.GetProductAmount(3);
                Console.WriteLine("Amount: " + amount.ToString());
                Console.ReadKey();

                #endregion

                #region modify product amount

                Console.WriteLine("Modify product amount by ID");
                int res = (int)productTasks.ModifProductAmount(1, 10);
                Console.WriteLine("Server returns with: " + res.ToString());
                Console.ReadKey();

                #endregion

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                Console.ReadKey();
            }
        }

        private static void Login(string user, string pass)
        {
            Authentication auth = Authentication.Instance;
            Console.WriteLine("Login with username: " + user + " password:" + pass );
            bool res = auth.Authenticate(user, pass);
            Console.WriteLine("Success: " + res.ToString());
            Console.ReadKey();
        }
    }
}
