using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RestService.Model
{
    [DataContract]
    public class ListProductsResponse : Response
    {
        [DataMember(Name = "products")]
        public List<Product> Products { get; set; }

        public ListProductsResponse()
        {
        }

        public ListProductsResponse(string status, List<Product> products) : base(status)
        {
            Products = products;
        }
    }
}