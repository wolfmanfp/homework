using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestService.Model;

namespace RestService.DBTasks
{
    interface IDatabase
    {
        bool Authenticate(string user, string pass);
        List<Location> Locations();
        List<Product> Products();
        List<Product> ProductsByLocation(int locID);
        bool AddProduct(string productName, int locID);
        bool DeleteProduct(int productID);
        bool TransferProduct(int productID, int newLocationID);
        bool checkProduct(string productName);
    }
}
