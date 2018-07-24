using System.Runtime.Serialization;

namespace RestService.Model
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public int JobID { get; set; }

        [DataMember]
        public int LocationID { get; set; }
    }
}