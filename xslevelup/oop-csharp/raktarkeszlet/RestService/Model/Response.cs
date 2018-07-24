using System.Runtime.Serialization;

namespace RestService.Model
{
    [DataContract]
    public class Response
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }

        public Response()
        {
        }

        public Response(string status)
        {
            Status = status;
        }
    }
}