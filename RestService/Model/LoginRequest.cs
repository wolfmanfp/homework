using System.Runtime.Serialization;

namespace RestService.Model
{
    [DataContract]
    public class LoginRequest
    {
        [DataMember(Name = "user")]
        public string User { get; set; }

        [DataMember(Name = "password")]
        public string Password { get; set; }

        [DataMember(Name = "jobID")]
        public int JobID { get; set; }

        public LoginRequest()
        { }

        public LoginRequest(string user, string password, int jobID)
        {
            User = user;
            Password = password;
            JobID = jobID;
        }
    }
}