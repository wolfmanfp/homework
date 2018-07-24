using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace numgame
{
    class RegistrationResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
