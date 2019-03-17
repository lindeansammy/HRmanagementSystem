using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using WpfTeamProject.Datas.

namespace WpfTeamProject.Model
{
    class JobListModel
    {
        private string _searchInput;
        private int _jobID;
        

        public string SearchInput {
            get { return _searchInput; }
            set { _searchInput = value; OnPropertyChanged("SearchInput"); }
        }

        private void OnPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }
    }
}
