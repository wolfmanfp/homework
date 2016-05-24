using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RestService.Model
{
    [DataContract]
    public class ListProductsByLocationRequest : Request
    {
        [DataMember(Name = "products")]
        public List<Product> Products { get; set; }

        [DataMember(Name = "locationID")]
        public int LocationID { get; set; }

        public ListProductsByLocationRequest()
        {
        }

        public ListProductsByLocationRequest(string status, List<Product> products, int locationID)
            : base(status)
        {
            Products = products;
            LocationID = locationID;
        }
    }
}