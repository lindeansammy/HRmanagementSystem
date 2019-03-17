using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTeamProject.Model;
using WpfTeamProject.Helpers;
using WpfTeamProject.Datas;
using WpfTeamProject.View;
using System.Windows;

namespace WpfTeamProject.ViewModel
{


    public class JobDetailViewModel : ModelBase
    {
        readonly wpf_databaseEntities context = new wpf_databaseEntities();
        private int jobID = Properties.Settings.Default.jobID;


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

        private bool _status;

        public bool Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("Status"); }
        }
        #endregion




        /// <summary>
        /// Binding Save Button
        /// </summary>
        public RelayCommand SaveCommand { get; set; }

        /// <summary>
        /// Binding Edit Button
        /// </summary>
        public RelayCommand EditCommand { get; set; }

        /// <summary>
        /// Binding Close Button
        /// </summary>
        public RelayCommand CloseCommand { get; set; }

        public RelayCommand BindCommand { get; set; }

        public JobDetailViewModel()
        {
            BindingData();
            SaveCommand = new RelayCommand(AddNewJob, IsAddJob);
            EditCommand = new RelayCommand(EditJob, IsEditJob);
            CloseCommand = new RelayCommand(CloseWindow);
        }

        /// <summary>
        /// Binding Data (Edit Method)
        /// </summary>
        public void BindingData()
        {
            if (jobID > 0)
            {
                job jobEntity = context.jobs.First(x => x.jobID == jobID);
                JobTitle = jobEntity.jobName;
                JobDescription = jobEntity.jobDescription;
                Employer = jobEntity.employer;
                Status = jobEntity.state;
                Salary = jobEntity.jobSalary;
            }
        }

        /// <summary>
        /// Add New Job
        /// </summary>
        /// <param name="jobInfo">New Job Infor</param>
        private void AddNewJob()
        {

            job jobEntity = new job
            {
                jobName = JobTitle,
                jobDescription = JobDescription,
                jobSalary = Salary,
                state = Status,
                employer = Employer,
                datePosted = DateTime.Now
            };

            context.jobs.Add(jobEntity);
            context.SaveChanges();

            
        }

        /// <summary>
        /// Close Window
        /// </summary>
        /// <param name="window"></param>
        private void CloseWindow(object window)
        {
            Window CurrentWindow = (Window)window;
            CurrentWindow.Close();
        }


        /// <summary>
        /// Edit Job
        /// </summary>
        /// <param name="jobInfo"></param>
        private void EditJob()
        {

            int jobID = Properties.Settings.Default.jobID;

            job jobEntity = context.jobs.First(x => x.jobID == jobID);

            jobEntity.jobName = JobTitle;
            jobEntity.jobSalary = Salary;
            jobEntity.jobDescription = JobDescription;
            jobEntity.employer = Employer;
            jobEntity.state = Status;

            context.SaveChanges();

        }


        /// <summary>
        /// Check Whether Edit Button is Enabled
        /// </summary>
        /// <param name="param">condition</param>
        /// <returns></returns>
        private bool IsEditJob(object param)
        {
            return jobID > 0 ? true : false;
        }


        /// <summary>
        /// Check Whether add button is Enabled
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        private bool IsAddJob(object param)
        {
            return string.IsNullOrEmpty(JobTitle) ? false : true;
        }
    }
}
