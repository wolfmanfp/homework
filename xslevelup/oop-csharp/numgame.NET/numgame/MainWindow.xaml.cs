using System.Windows;

namespace numgame
{
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();

            viewModel = new MainViewModel();
            DataContext = viewModel;
        }

        private void send_Click(object sender, RoutedEventArgs e)
        {
            value.Focus();
        }

    }
}
