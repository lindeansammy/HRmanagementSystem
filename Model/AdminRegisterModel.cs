using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTeamProject.Model
{
    class AdminRegisterModel
    {
        #region input value type
        private string _adminUN;
        private string _adminPW;
        private string _adminEM;
        
        #endregion

        #region getter and setter
        public string AdminUN
        {
            get { return _adminUN; }
            set { _adminUN = value; OnPropertyChanged("AdminUN"); }
        }

        public string AdminPW
        {
            get { return _adminPW; }
            set { _adminPW = value; OnPropertyChanged("AdminPW"); }
        }

        public string AdminEM
        {
            get { return _adminEM; }
            set { _adminEM = value; OnPropertyChanged("AdminEM"); }
        }

        public bool AdminTYpe { get; set; } = false;

        private void OnPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
