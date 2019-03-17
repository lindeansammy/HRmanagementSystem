using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTeamProject.Datas;


namespace WpfTeamProject.Model
{
    public class JobDTO : ModelBase
    {
        #region Porperties
        /// <summary>
        /// JobId property
        /// </summary>
        private int _jobId;
        /// <summary>
        /// getter & setter
        /// </summary>
        public int JobId
        {
            get => _jobId;
            set
            {
                _jobId = value;
                OnPropertyChanged("JobId");
            }
        }

        /// <summary>
        /// JobName property
        /// </summary>
        private string _jobName;
        /// <summary>
        /// getter & setter
        /// </summary>
        public string JobName
        {
            get => _jobName;
            set
            {
                _jobName = value;
                OnPropertyChanged("JobName");
            }
        }

        /// <summary>
        /// JobDescription property
        /// </summary>
        private string _jobDescription;
        /// <summary>
        /// getter & setter
        /// </summary>
        public string JobDescription
        {
            get => _jobDescription;
            set
            {
                _jobDescription = value;
                OnPropertyChanged("JobDescription");
            }
        }

        /// <summary>
        /// JobSalary property
        /// </summary>
        private decimal _jobSalary;
        /// <summary>
        /// getter & setter
        /// </summary>
        public decimal JobSalary
        {
            get => _jobSalary;
            set { _jobSalary = value; OnPropertyChanged("JobSalary"); }
        }

        /// <summary>
        /// Employer property
        /// </summary>
        private string _employer;
        /// <summary>
        /// getter & setter
        /// </summary>
        public string Employer
        {
            get => _employer;
            set { _employer = value; OnPropertyChanged("Employer"); }
        }

        /// <summary>
        /// DatePosted property (default value = Now)
        /// </summary>
        private string _datePosted = DateTime.UtcNow.ToShortDateString();
        /// <summary>
        /// getter & setter
        /// </summary>
        public string DatePosted
        {
            get => _datePosted;
            set { _datePosted = value; OnPropertyChanged("DatePosted"); }
        }

        /// <summary>
        /// State property
        /// </summary>
        private bool _state;
        /// <summary>
        /// getter & setter
        /// </summary>
        public bool State
        {
            get => _state;
            set { _state = value; OnPropertyChanged("State"); }
        }
        #endregion
    }
}
