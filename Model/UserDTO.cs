using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using WpfTeamProject.Datas;

namespace WpfTeamProject.Model
{
    public class UserDTO : ModelBase
    {

        #region UserID Property
        /// <summary>
        /// userId
        /// </summary>
        int _userId;

        
        /// <summary>
        /// getter and setter
        /// </summary>
        public int UserID
        {
            get { return _userId; }
            set
            {
                if (_userId != value)
                {
                    _userId = value;
                    OnPropertyChanged("UserID");
                }
            }
        }
        #endregion

        #region UserName Property
        /// <summary>
        /// _userName
        /// </summary>
        string _userName;


        /// <summary>
        /// getter and setter
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged("UserName");
                }

            }
        }
        #endregion

        #region Password Property

        /// <summary>
        /// _password
        /// </summary>
        string _password;


        /// <summary>
        /// getter and setter
        /// </summary>
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged("Password");
                }
            }
        }
        #endregion

        #region Type Property

        /// <summary>
        /// Client Type: True: Administrator, False: User;
        /// </summary>
        bool _type;

        /// <summary>
        /// getter and setter
        /// </summary>
        public bool Type
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    OnPropertyChanged("Type");
                }
            }
        }
        #endregion

        /*************** METHODS *****************/

       
    }
}
