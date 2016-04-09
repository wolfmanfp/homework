using System.ComponentModel;
using System.Windows.Input;

namespace numgame
{
    class MainViewModel : INotifyPropertyChanged
    {
        private const string Url = "http://api.gamer365.hu/numgame";

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
            client = new RestSharp.RestClient(Url);
        }

        public void Send()
        {
            if (token == null)
            {
                SendRegistration();
            }
            else
            {

            }
        }

        private void SendRegistration()
        {
            var request = new RestSharp.RestRequest("register", RestSharp.Method.GET);

            RestSharp.IRestResponse response = client.Execute(request);

            Result = response.Content;
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
