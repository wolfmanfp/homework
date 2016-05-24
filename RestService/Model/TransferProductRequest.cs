using System.Runtime.Serialization;

namespace RestService.Model
{
    [DataContract]
    public class TransferProductRequest : Request
    {
        [DataMember(Name = "productID")]
        public int ProductID { get; set; }

        [DataMember(Name = "newLocationID")]
        public int NewLocationID { get; set; }

        public TransferProductRequest()
        {
        }

        public TransferProductRequest(string token, int productID, int newLocationID)
            : base(token)
        {
            ProductID = productID;
            NewLocationID = newLocationID;
        }
    }
}