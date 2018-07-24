using System.Runtime.Serialization;

namespace RestService.Model
{
    [DataContract]
    public class CheckProductRequest : Request
    {
        [DataMember(Name = "productName")]
        public string ProductName { get; set; }

        public CheckProductRequest()
        {
        }

        public CheckProductRequest(string token, string productName) : base(token)
        {
            ProductName = productName;
        }
    }
}