using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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
using WpfTeamProject.Helpers;
using WpfTeamProject.ViewModel;

namespace WpfTeamProject.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window, IHavePassword
    {
        public Login()
        {
            InitializeComponent();
            DataContext = new LoginViewModel(this);
        }

        public System.Security.SecureString Password
        {
            get
            {
                return PassLoginBox.SecurePassword;
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
