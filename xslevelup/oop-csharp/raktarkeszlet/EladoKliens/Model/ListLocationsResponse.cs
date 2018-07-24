using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RestService.Model
{
    [DataContract]
    public class ListLocationsResponse : Response
    {
        [DataMember(Name = "locations")]
        public List<Location> Locations { get; set; }

        public ListLocationsResponse()
        {
        }

        public ListLocationsResponse(string status, List<Location> locations)
            : base(status)
        {
            Locations = locations;
        }
    }
}