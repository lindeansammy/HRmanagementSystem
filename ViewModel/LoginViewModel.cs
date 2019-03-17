using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfTeamProject.Helpers;
using WpfTeamProject.View;
using WpfTeamProject.Datas;
using WpfTeamProject.Model;

namespace WpfTeamProject.ViewModel
{
    class LoginViewModel : ModelBase
    {
        #region Credentials
        private string _userName;
        private Window LoginView;
        #endregion

        #region Getters Setters
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; OnPropertyChanged("UserName"); }
        }

        #endregion

        #region Command
        /// <summary>
        /// Defines Parameter Command
        /// </summary>
        public RelayCommand LoginCommand { get; set; }
        /// <summary>
        /// Go to User Registration Page
        /// </summary>
        public RelayCommand GoToUserRegistrationCommand { get; set; }
        #endregion

        #region Constructor
        public LoginViewModel(Window window)
        {
            LoginCommand = new RelayCommand(Login);
            GoToUserRegistrationCommand = new RelayCommand(GoToRegistration);
            this.LoginView = window;
        }
        #endregion

        #region methods
        /// <summary>
        /// Direct Users to registration page
        /// </summary>
        public void GoToRegistration(){
            var registration = new UserRegistration();
            registration.Show();
            LoginView.Hide();
        }

        /// <summary>
        /// Log ing Users
        /// </summary>
        /// <param name="parameter"></param>
        void Login(object parameter)
        {
            //  Get password input
            string inputPassword = "";
            var passwordContainer = parameter as IHavePassword;
            if (passwordContainer != null)
            {
                var secureString = passwordContainer.Password;
                inputPassword = ConvertToUnsecureString(secureString);
            }


            // Instantiate database entities
            wpf_databaseEntities context = new wpf_databaseEntities();

            bool result = context.users.Any(x => x.userName == UserName && x.password == inputPassword);
            var userEntity = new user();

            if (result)
            {
                // retrieve the username and password from user table
                userEntity = context.users.First(x => x.userName == UserName && x.password == inputPassword);
                // Verify that user exists and if user is admin or client  
                if (string.IsNullOrEmpty(userEntity.userID.ToString()))
                {
                    MessageBox.Show("Invalid User. Pls try again.");
                }
                else
                {
                    Properties.Settings.Default.userID = userEntity.userID;// save userID to public property

                    if (userEntity.type)
                    {
                        var admin = new AdminList(); // pass user id to the constructor to log in user                       
                        admin.Show(); 
                        LoginView.Hide();
                    }
                    else
                    {
                        var client = new JobList(); // pass user id to the constructor to log in user                        
                        client.Show();  
                        LoginView.Hide();
                    }
                }
            }
            else
            {
                MessageBox.Show("User does not exists. Please Try again.");            
            }
            
        }
        
        #endregion
    }
}
