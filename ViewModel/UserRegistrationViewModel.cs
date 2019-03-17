using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTeamProject.Model;
using WpfTeamProject.Helpers;
using System.Security;
using System.Runtime.InteropServices;
using WpfTeamProject.View;
using System.Windows;
using WpfTeamProject.Datas;

namespace WpfTeamProject.ViewModel
{
    public class UserRegistrationViewModel : ModelBase
    {
        #region User Infos
        private string _userName;
        private string _firstName;
        private string _lastName;
        private int _phoneNumber;
        private string _address;
        private string _email;
        private int _experience;
        private string _skill;
        private string _position;
        private Window UserRegistration;
        private string inputPassword;
        #endregion

        #region Getters Setters
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; OnPropertyChanged("UserName"); }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; OnPropertyChanged("FirstName"); }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged("LastName"); }
        }

        public int PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; OnPropertyChanged("PhoneNumber"); }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; OnPropertyChanged("Address"); }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged("Email"); }
        }

        public int Experience
        {
            get { return _experience; }
            set { _experience = value; OnPropertyChanged("Experience"); }
        }

        public string Skill
        {
            get { return _skill; }
            set { _skill = value; OnPropertyChanged("Skill"); }
        }

        public string Position
        {
            get { return _position; }
            set { _position = value; OnPropertyChanged("Position"); }
        }
        #endregion

        #region Commands
        /// <summary>
        /// Register user to database
        /// </summary>
        public RelayCommand RegisterCommand { get; set; }

        /// <summary>
        /// Back to login page
        /// </summary>
        public RelayCommand CancelCommand { get; set; }
        #endregion

        #region Constructor
        public UserRegistrationViewModel()
        {
            RegisterCommand = new RelayCommand(Register);
            CancelCommand = new RelayCommand(Cancel);
        }

        public UserRegistrationViewModel(Window window)
        {
           RegisterCommand = new RelayCommand(Register);
           CancelCommand = new RelayCommand(Cancel);
            this.UserRegistration = window;
        }
        #endregion

        #region Methods
        public void Cancel()
        {
            var log = new Login();
            log.Show();
            UserRegistration.Hide();
        }

        /// <summary>
        /// Check if input is numeric
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool IsNumericInput(int num)
        {
            int check;
            int.TryParse(num.ToString(), out check);

            return (num == 0 || num < 0 || check == 0);
        }

        /// <summary>
        /// Checks inputPassword
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool IsPasswordValid(object parameter)
        {
            var passwordContainer = parameter as IHavePassword;
            if (passwordContainer != null)
            {
                var secureString = passwordContainer.Password;
                inputPassword = ConvertToUnsecureString(secureString);
            }

            return (inputPassword == "");
        }

        /// <summary>
        /// Check if input is empty
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            if (UserName == null ||
                FirstName == null ||
                LastName == null ||
                Address == null ||
                Email == null ||
                Skill == null ||
                Position == null
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Register Users
        /// </summary>
        /// <param name="parameter"></param>
        public void Register(object parameter)
        {
            //  Get password input
            if (IsEmpty())
            {               
                MessageBox.Show("Please fill up all fields.");
            }
            else if (IsPasswordValid(parameter))
            {
                MessageBox.Show("Invalid Password");
            }
            else if (IsNumericInput(PhoneNumber))
            {
                MessageBox.Show("Invalid Phone number.");
            }
            else if ( IsNumericInput(Experience))
            {
                MessageBox.Show("Experience (in years) must be 0 or above.");
            }
            else
            {
                using (var db = new wpf_databaseEntities())
                {
                    var userInfos = db.Set<userInfo>();
                    userInfo newUser = new userInfo
                    {
                        firstName = this.FirstName,
                        lastName = this.LastName,
                        phone = this.PhoneNumber,
                        address = this.Address,
                        email = this.Email,
                        experience = this.Experience,
                        skill = this.Skill,
                        position = this.Position
                    };
                    userInfos.Add(newUser);

                    var users = db.Set<user>();
                    users.Add(new user { userID = newUser.userID, userName = this.UserName, password = this.inputPassword, type = false });
                    db.SaveChanges();
                    MessageBox.Show("Registration Complete.");
                    var log = new Login();
                    log.Show();
                    UserRegistration.Hide();
                }
            }
        }
        #endregion
    }
}
