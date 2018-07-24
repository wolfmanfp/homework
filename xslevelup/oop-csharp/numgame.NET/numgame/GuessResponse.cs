using Newtonsoft.Json;

namespace numgame
{
    class GuessResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("answer")]
        public string Answer { get; set; }
        [JsonProperty("guesses")]
        public string Guesses { get; set; }
    }
}
