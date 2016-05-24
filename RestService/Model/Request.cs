using System.Runtime.Serialization;

namespace RestService.Model
{
    [DataContract]
    public class Request
    {
        [DataMember(Name = "token")]
        public string Token { get; set; }

        public Request()
        {
        }

        public Request(string token)
        {
            Token = token;
        }
    }
}