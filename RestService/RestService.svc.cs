using RestService.DBTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RestService
{
    public class RestService : IRestService
    {
        private IDatabase database;

        public RestService()
        {
            database = new MSSQLDatabase();
        }

        public string AddProduct(string token, string productName, int locID)
        {
            throw new NotImplementedException();
        }

        public string DeleteProduct(string token, int productID)
        {
            throw new NotImplementedException();
        }

        public string CheckProduct(string token, string productName)
        {
            throw new NotImplementedException();
        }

        public string ListLocations(string token)
        {
            throw new NotImplementedException();
        }

        public string ListProducts(string token)
        {
            throw new NotImplementedException();
        }

        public string ListProductsByLocation(string token, int locID)
        {
            throw new NotImplementedException();
        }

        public string Login(string user, string pass)
        {
            bool result = database.Authenticate(user, pass);
        }

        public string TransferProduct(string token, int productID, int locID)
        {
            bool result = database.TransferProduct(productID, locID);
        }
    }
}
