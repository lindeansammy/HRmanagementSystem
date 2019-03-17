using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfTeamProject.Datas;
using WpfTeamProject.Helpers;
using WpfTeamProject.Model;
using WpfTeamProject.View;

namespace WpfTeamProject.ViewModel
{

    public class JobListViewModel : ModelBase
    {
        wpf_databaseEntities context = new wpf_databaseEntities();

        private int userid = Properties.Settings.Default.userID;

        #region PageModel
        private string _jobtitle;

        public string JobTitle
        {
            get { return _jobtitle; }
            set { _jobtitle = value; OnPropertyChanged("JobTitle"); }
        }


        private string _employer;

        public string Employer
        {
            get { return _employer; }
            set { _employer = value; OnPropertyChanged("Employer"); }
        }

        private string _jobdescription;

        public string JobDescription
        {
            get { return _jobdescription; }
            set { _jobdescription = value; OnPropertyChanged("JobDescription"); }
        }

        private decimal _salary;

        public decimal Salary
        {
            get { return _salary; }
            set { _salary = value; OnPropertyChanged("Salary"); }
        }

        private string _applied = "No";
        public string Applied
        {
            get { return _applied; }
            set { _applied = value; OnPropertyChanged("Applied"); }
        }

        #endregion

        private List<job> _joblist;
        public List<job> JobList
        {
            get { return _joblist; }
            set { _joblist = value; OnPropertyChanged("JobList"); }
        }


        public RelayCommand SearchCommand { get; set; }
        public RelayCommand ApplyCommand { get; set; }
        public RelayCommand LogoutCommand { get; set; }



        public JobListViewModel()
        {
            BindDate();
            SearchCommand = new RelayCommand(Search);
            ApplyCommand = new RelayCommand(AppliedJob, canApply);
            LogoutCommand = new RelayCommand(SignOut);
        }

        private void BindDate()
        {
            int userid = Properties.Settings.Default.userID;
            JobList = context.jobs.Where(x => x.state == true).ToList();
        }

        private void Search(object condition)
        {
            if (int.TryParse(condition.ToString(), out int id))
            {
                JobList = context.jobs.Where(x => x.jobID == id && x.state == true).ToList();
            }
            else
            {
                JobList = context.jobs.Where(x => x.jobName.Contains(condition.ToString()) || x.jobDescription.Contains(condition.ToString()) || x.employer.Contains(condition.ToString())).ToList();
            }
        }

        private bool canApply(object param)
        {
            if (param != null)
            {
                job job = (job)param;
                bool result = context.applicationDetails.Where(x => x.jobID == job.jobID && x.userID == userid).Any();

                if (result)
                    return false;
                else
                    return true;
            }
            else {
                return false;
            }
        }

        private void AppliedJob(object param)
        {
            job job = (job)param;

            applicationDetail application = new applicationDetail
            {
                jobID = job.jobID,
                userID = userid,
                applicationDate = DateTime.Now

            };

            context.applicationDetails.Add(application);
            context.SaveChanges();

        }

        private void SignOut(object param)
        {
            //Open Login Page
            Login login = new Login();
            login.Show();

            //Close CurrentWindow Page
            Window CurrentWindow = (Window)param;
            CurrentWindow.Close();

        }
    }
}
