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
using System.Windows.Shapes;

namespace zam
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            this.UserChoice.ItemsSource = Enum.GetValues(typeof(User));        //obsługa list rozwijanych
            this.UserChoice.SelectedIndex = 0;
        }
        
        private void LogingButton_Click(object sender, RoutedEventArgs e)
        {
            if ((UserChoice.SelectedIndex == 0)  )
            {
                new MainWindow().Show();
                this.Close();
            }
            if ((this.UserChoice.SelectedIndex == 1)  )
            {
                new ProdWindow().Show();
                this.Close();
            }
            if ((this.UserChoice.SelectedIndex ==2)  )
            {
                new ProdWindow().Show();
                this.Close();
            }
        }

        private void UserChoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
