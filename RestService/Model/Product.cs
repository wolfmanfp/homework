using System.Runtime.Serialization;

namespace RestService.Model
{
    [DataContract]
    public class Product
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int LocationID { get; set; }
    }
}
