using System.Runtime.Serialization;

namespace RestService.Model
{
    [DataContract]
    public class DeleteProductRequest : Request
    {
        [DataMember(Name = "productID")]
        public int ProductID { get; set; }

        public DeleteProductRequest()
        {
        }

        public DeleteProductRequest(string token, int productID) : base(token)
        {
            ProductID = productID;
        }
    }
}