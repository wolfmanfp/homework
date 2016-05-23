using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RaktarosKliens
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtUserName.Text == "" || txtPassWord.Text == "") {
                MessageBox.Show("Minden mezőt ki kell tölteni!");
            }
            else
            {
                sp1.Visibility = Visibility.Visible;
                sp2.Visibility = Visibility.Visible;
                MessageBox.Show(txtUserName.Text + " " + txtPassWord.Text);
            }
            
        }

        private void btnGetProducts_Click(object sender, RoutedEventArgs e)
        {
            if (txtProductIdLeft.Text == "" || txtProductPiecesLeft.Text == "" || txtLocationLeft.Text == "")
            {
                MessageBox.Show("Minden mezőt ki kell tölteni!");
            }
            else
            {
                MessageBox.Show(txtProductIdLeft.Text + " " + txtProductPiecesLeft.Text + " " + txtLocationLeft.Text);
            }
        }

        private void btnAddProducts_Click(object sender, RoutedEventArgs e)
        {
            if (txtProductIdLeft.Text == "" || txtProductPiecesLeft.Text == "" || txtLocationLeft.Text == "")
            {
                MessageBox.Show("Minden mezőt ki kell tölteni!");
            }
            else
            {
                int valami = int.Parse(txtProductIdLeft.Text);
                
                MessageBox.Show(txtProductIdLeft.Text + " " + txtProductPiecesLeft.Text + " " + txtLocationLeft.Text);
            }
        }

        private void btnTransferProducts_Click(object sender, RoutedEventArgs e)
        {
            if (txtProductIdRight.Text == "" || txtNewLocationRight.Text == "")
            {
                MessageBox.Show("Minden mezőt ki kell tölteni!");
            }
            else
            {
                MessageBox.Show(txtProductIdRight.Text + " " + txtNewLocationRight.Text);
            }
        }
    }
}
