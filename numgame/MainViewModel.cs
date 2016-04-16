using Newtonsoft.Json;
using RestSharp;
using System.ComponentModel;
using System.Windows.Input;

namespace numgame
{
    class MainViewModel : INotifyPropertyChanged
    {
        private const string URL = "http://api.gamer365.hu/numgame";

        private string token;
        private RestSharp.RestClient client;
        public ICommand SendCommand { get; set; }

        private string value;
        public string Value
        {
            get { return value; }
            set
            {
                this.value = value;
                OnPropertyChange("Value");
            }
        }

        private string result;
        public string Result
        {
            get { return result; }
            set
            {
                result = value;
                OnPropertyChange("Result");
            }
        }

        public MainViewModel()
        {
            Value = "";
            Result = "I picked a number between 1 and 100. Enter your guess above.";
            client = new RestClient(URL);
        }

        public void Send()
        {
            if (token == null)
            {
                Registration();
            }
            else
            {
                Guess();
            }
        }

        private void Registration()
        {
            var request = new RestRequest("register", Method.GET);
            IRestResponse response = client.Execute(request);
            RegistrationResponse rResponse = 
                JsonConvert.DeserializeObject<RegistrationResponse>(response.Content);
            string status = rResponse.Status;
            if (status == "ok")
            {
                token = rResponse.Token;
                Guess();
            }
        }

        private async void Guess()
        {
            Result = token;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
