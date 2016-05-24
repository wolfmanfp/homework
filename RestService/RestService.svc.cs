using RestService.DBTasks;
using RestService.Model;
using System.Collections.Generic;

namespace RestService
{
    public class RestService : IRestService
    {
        private IDatabase database;

        public RestService()
        {
            database = new MSSQLDatabase();
        }

        public Response AddProduct(AddProductRequest request)
        {
            string status;
            if (Token.IsValid(request.Token))
            {
                if (database.AddProduct(request.ProductName, request.LocationID))
                {
                    status = "ok";
                }
                else
                {
                    status = "error";
                }
            }
            else
            {
                status = "invalid token";
            }

            return new Response(status);
        }

        public Response CheckProduct(CheckProductRequest request)
        {
            string status;
            if (Token.IsValid(request.Token))
            {
                if (database.CheckProduct(request.ProductName))
                {
                    status = "ok";
                }
                else
                {
                    status = "error";
                }
            }
            else
            {
                status = "invalid token";
            }

            return new Response(status);
        }

        public Response DeleteProduct(DeleteProductRequest request)
        {
            string status;
            if (Token.IsValid(request.Token))
            {
                if (database.DeleteProduct(request.ProductID))
                {
                    status = "ok";
                }
                else
                {
                    status = "error";
                }
            }
            else
            {
                status = "invalid token";
            }

            return new Response(status);
        }

        public ListLocationsResponse ListLocations(Request request)
        {
            string status;
            List<Location> locations = null;
            if (Token.IsValid(request.Token))
            {
                locations = database.Locations();
                status = "ok";
            }
            else
            {
                status = "error";
            }
            return new ListLocationsResponse(status, locations);
        }

        public ListProductsResponse ListProducts(Request request)
        {
            string status;
            List<Product> products = null;
            if (Token.IsValid(request.Token))
            {
                products = database.Products();
                status = "ok";
            }
            else
            {
                status = "error";
            }
            return new ListProductsResponse(status, products);
        }

        public ListProductsResponse ListProductsByLocation(ListProductsByLocationRequest request)
        {
            string status;
            List<Product> products = null;
            if (Token.IsValid(request.Token))
            {
                products = database.ProductsByLocation(request.LocationID);
                status = "ok";
            }
            else
            {
                status = "error";
            }
            return new ListProductsResponse(status, products);
        }

        public LoginResponse Login(LoginRequest request)
        {
            string status;
            string token = "";

            if (database.Authenticate(request.User, request.Password, request.JobID))
            {
                token = Token.Create();
                status = "ok";
            }
            else
            {
                status = "error";
            }

            return new LoginResponse(status, token);
        }

        public Response TransferProduct(TransferProductRequest request)
        {
            string status;
            if (Token.IsValid(request.Token))
            {
                if (database.TransferProduct(request.ProductID, request.NewLocationID))
                {
                    status = "ok";
                }
                else
                {
                    status = "error";
                }
            }
            else
            {
                status = "invalid token";
            }

            return new Response(status);
        }
    }
}