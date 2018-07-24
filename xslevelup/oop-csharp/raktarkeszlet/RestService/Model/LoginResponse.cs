using System.Runtime.Serialization;

namespace RestService.Model
{
    [DataContract]
    public class LoginResponse : Response
    {
        [DataMember(Name = "token")]
        public string Token { get; set; }

        public LoginResponse()
        {
        }

        public LoginResponse(string status, string token) : base(status)
        {
            Token = token;
        }
    }
}