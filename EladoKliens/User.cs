using System;
using System.Runtime.Serialization;

namespace EladoKliens
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string Location { get; set; }

        public User()
        {
        }
    }
}
