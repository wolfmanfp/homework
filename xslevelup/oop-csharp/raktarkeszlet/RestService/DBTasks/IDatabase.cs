using RestService.Model;
using System.Collections.Generic;

namespace RestService.DBTasks
{
    internal interface IDatabase
    {
        bool Authenticate(string user, string pass, int jobID);

        List<Location> Locations();

        List<Product> Products();

        List<Product> ProductsByLocation(int locID);

        bool AddProduct(string productName, int locID);

        bool DeleteProduct(int productID);

        bool TransferProduct(int productID, int newLocationID);

        bool CheckProduct(string productName);
    }
}