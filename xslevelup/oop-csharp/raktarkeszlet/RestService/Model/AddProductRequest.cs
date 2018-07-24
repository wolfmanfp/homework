using System.Runtime.Serialization;

namespace RestService.Model
{
    [DataContract]
    public class AddProductRequest : Request
    {
        [DataMember(Name = "productName")]
        public string ProductName { get; set; }

        [DataMember(Name = "locationID")]
        public int LocationID { get; set; }

        public AddProductRequest()
        {
        }

        public AddProductRequest(string token, string productName, int locationID)
            : base(token)
        {
            ProductName = productName;
            LocationID = locationID;
        }
    }
}