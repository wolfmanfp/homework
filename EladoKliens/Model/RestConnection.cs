using Newtonsoft.Json;
using RestService.Model;
using RestSharp;
using System.Configuration;
using System.Threading.Tasks;

namespace EladoKliens.Model
{
    public class RestConnection
    {
        private static RestClient client = 
            new RestClient(ConfigurationManager.AppSettings["ServiceURL"]);

        public static async Task<LoginResponse> Authentication(string username, string password)
        {
            var request = new RestRequest("login", Method.POST);
            request.AddParameter("user", username);
            request.AddParameter("password", password);
            request.AddParameter("jobID", 1);

            return await Send<LoginResponse>(request);
        }

        private static async Task<T> Send<T>(RestRequest request)
        {
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = await client.ExecuteTaskAsync(request);
            return JsonConvert.DeserializeObject<T>(response.Content);
        }
    }
}