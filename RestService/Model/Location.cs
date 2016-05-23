using System.Runtime.Serialization;

namespace RestService.Model
{
    [DataContract]
    public class Location
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string LocationName { get; set; }
    }
}
