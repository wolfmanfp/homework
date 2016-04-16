using Newtonsoft.Json;
using RestSharp;
using System.ComponentModel;
using System.Threading;
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

        private async void Registration()
        {
            var request = new RestRequest("register", Method.GET);
            var cancellationTokenSource = new CancellationTokenSource();
            IRestResponse response =
                await client.ExecuteTaskAsync(request, cancellationTokenSource.Token);

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
            var request = new RestRequest("guess", Method.POST);
            request.AddParameter("token", token);
            request.AddParameter("value", value);

            int iValue;
            bool guessIsNumber = int.TryParse(value, out iValue);

            if (guessIsNumber && iValue > 0 && iValue < 100)
            {
                var cancellationTokenSource = new CancellationTokenSource();
                IRestResponse response =
                    await client.ExecuteTaskAsync(request, cancellationTokenSource.Token);

                GuessResponse gResponse =
                    JsonConvert.DeserializeObject<GuessResponse>(response.Content);

                string status = gResponse.Status;
                switch (status)
                {
                    case "ok":
                        string answer = gResponse.Answer;
                        switch (answer)
                        {
                            case "toolow":
                                Result = "Too low!";
                                break;
                            case "toohigh":
                                Result = "Too high!";
                                break;
                            case "win":
                                var guesses = gResponse.Guesses;
                                Result = "You win! Number of guesses: " + guesses;
                                break;
                        }
                        break;
                    case "invalid token":
                        Result = "Invalid token!";
                        break;
                }
            }
            else
            {
                Result = "Invalid number!";
            }
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
