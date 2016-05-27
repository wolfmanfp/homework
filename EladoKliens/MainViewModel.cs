using EladoKliens.Model;
using RestService.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace EladoKliens
{
    class MainViewModel
    {
        private string token;
        public RelayCommand LoginCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }
        public RelayCommand TransferCommand { get; set; }

        #region Tulajdonságok

        private string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        private bool visible;
        public bool Visible
        {
            get { return visible; }
            set {
                visible = value;
                OnPropertyChanged("Visible");
                OnPropertyChanged("Enabled");
            }
        }
        public bool Enabled
        {
            get { return !visible; }
        }

        #endregion

        public MainViewModel()
        {
            Visible = false;
            LoginCommand = new RelayCommand(new Action<object>(Login));
        }

        public async void Login(object parameter)
        {
            PasswordBox pbox = (PasswordBox)parameter;
            string password = pbox.Password;
            LoginResponse response = await RestConnection.Authentication(userName, password);

            if (response.Status == "ok")
            {
                token = response.Token;
                Visible = true;
            }
            else
            {
                MessageBox.Show(
                    Properties.Resources.LoginError,
                    Properties.Resources.Error,
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
