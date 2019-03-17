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
using WpfTeamProject.Helpers;
using WpfTeamProject.ViewModel;

namespace WpfTeamProject.View
{
    /// <summary>
    /// Interaction logic for UserRegistration.xaml
    /// </summary>
    public partial class UserRegistration : Window, IHavePassword
    {
        public UserRegistration()
        {
            InitializeComponent();
            DataContext = new UserRegistrationViewModel(this);
        }

        // Returns the value of the pbPassword textbox
        public System.Security.SecureString Password
        {
            get
            {
                return pbPassword.SecurePassword;
            }
        }
    }
}
