using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    [DataContract]
    class Location
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string LocationName { get; set; }
    }
}
