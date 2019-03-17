using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTeamProject.Helpers;
using WpfTeamProject.View;
using WpfTeamProject.Model;
using WpfTeamProject.Datas;
using System.Windows;
using System.Collections.ObjectModel;

namespace WpfTeamProject.ViewModel
{
    public class AdminListViewModel : ModelBase
    {
        wpf_databaseEntities context = new wpf_databaseEntities();
        UserModel usermodel = new UserModel();

        #region jobs Prop
        /// <summary>
        /// jobs information
        /// </summary>
        private List<job> _jobs;

        /// <summary>
        /// getter & setter
        /// </summary>
        public List<job> Jobs
        {
            get { return _jobs; }
            set { _jobs = value; OnPropertyChanged("Jobs"); }
        }
        #endregion

        #region users Prop
        /// <summary>
        /// users information
        /// </summary>
        private List<UserModel> _usermodels;

        public List<UserModel> UserModels
        {
            get { return _usermodels; }
            set { _usermodels = value; OnPropertyChanged("UserModels"); }
        }
        #endregion

        

        #region Definite Commands

        /// <summary>
        /// Search Job Command
        /// </summary>
        public RelayCommand SearchJobCommand { get; set; }

        /// <summary>
        /// Add New Job Command
        /// </summary>
        public RelayCommand AddJobCommand { get; set; }

        /// <summary>
        /// Edit Job Command
        /// </summary>
        public RelayCommand EditJobCommand { get; set; }

        /// <summary>
        /// Delete Job Command
        /// </summary>
        public RelayCommand DeleteJobCommand { get; set; }


        /// <summary>
        /// Search User Command
        /// </summary>
        public RelayCommand SearchUserCommand { get; set; }

        /// <summary>
        /// Delete User Command
        /// </summary>
        public RelayCommand DeleteUserCommand { get; set; }


        /// <summary>
        /// Add New Admin Command
        /// </summary>
        public RelayCommand AddAdminCommand { get; set; }

        /// <summary>
        /// SignOut Command
        /// </summary>
        public RelayCommand SignOutCommand { get; set; }
        #endregion      

        private int userID = Properties.Settings.Default.userID;

        public AdminListViewModel()
        {
            //get all jobs
            JobList("");
            //get all user (not include login admin)
            UserList("");
            AddJobCommand = new RelayCommand(AddNewJob);
            SignOutCommand = new RelayCommand(SignOut);
            SearchJobCommand = new RelayCommand(JobList);
            SearchUserCommand = new RelayCommand(UserList);
            AddAdminCommand = new RelayCommand(AddNewAdmin);
            EditJobCommand = new RelayCommand(EditJob, canEdit);
            DeleteJobCommand = new RelayCommand(DeleteJob, canEdit);
        }

        /// <summary>
        /// Go to Add new job page (jobDetail.xaml)
        /// </summary>
        private void AddNewJob()
        {
            JobDetail newJob = new JobDetail();
            newJob.ShowDialog();
        }

        /// <summary>
        /// Go to Add new admin page (AdminRegister.xaml)
        /// </summary>
        private void AddNewAdmin()
        {
            AdminRegister newAdmin = new AdminRegister();
            newAdmin.Show();
        }

        /// <summary>
        /// Go to Edit job page (jobDetail.xaml)
        /// </summary>
        /// <param name="jobinfo"></param>
        private void EditJob(object jobinfo)
        {
            job jobDetail = (job)jobinfo;
            Properties.Settings.Default.jobID = jobDetail.jobID;

            JobDetail window = new JobDetail();
            window.ShowDialog();
        }

        /// <summary>
        /// Check whether select one job
        /// </summary>
        /// <param name="jobinfo"></param>
        /// <returns></returns>
        private bool canEdit(object jobinfo)
        {
            if (jobinfo == null)
            {
                return false;
            }
            else {
                return true;
            }
        }

        private void DeleteJob(object jobinfo)
        {
            if (MessageBox.Show("Are you sure to Delete", "Delete Job", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                job jobDetail = (job)jobinfo;
                job updateJob = context.jobs.First(x=>x.jobID == jobDetail.jobID);
                updateJob.state = false;
                context.SaveChanges();
                JobList(null);
            }            
        }

        /// <summary>
        /// Go to Login page (Login.xaml)
        /// </summary>
        private void SignOut(object param)
        {
            //Open Login Page
            Login login = new Login();
            login.Show();

            //Close CurrentWindow Page
            Window CurrentWindow = (Window)param;
            CurrentWindow.Close();

        }

        /// <summary>
        /// Filter Jobs by Condition
        /// </summary>
        /// <param name="condition">condition</param>
        private void JobList(object condition)
        {
            string search = condition.ToString();

            if (int.TryParse(search, out int id))
            {
                Jobs = context.jobs.Where(x => x.jobID == id).ToList();
            }
            else
            {

                Jobs = context.jobs.Where(x => x.jobName.Contains(search) || x.jobDescription.Contains(search) || x.employer.Contains(search)).ToList();
            }
        }

        /// <summary>
        /// Filter Users by Condition
        /// </summary>
        /// <param name="condition"></param>
        private void UserList(object condition)
        {
            string search = condition.ToString();

            UserModels = usermodel.PopulateList(context.users.Where(x => x.type == false).ToList());

            if (int.TryParse(search, out int number))
            {
                UserModels = UserModels.Where(x => x.UserID == number || x.Phone == number).ToList();
            }
            else
            {
                UserModels = UserModels.Where(x => x.FullName.Contains(search) || x.Email.Contains(search) || x.Position.Contains(search)).ToList();
            }

        }      
    }

    #region UserList Class
    /// <summary>
    /// Userlist Class
    /// </summary>
    public class UserModel : ModelBase
    {
        private int _userid;

        public int UserID
        {
            get { return _userid; }
            set { _userid = value; OnPropertyChanged("UserID"); }
        }

        private string _fullName;

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; OnPropertyChanged("FullName"); }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged("Email"); }
        }

        private long _phone;

        public long Phone
        {
            get { return _phone; }
            set { _phone = value; OnPropertyChanged("Phone"); }
        }

        private string _position;

        public string Position
        {
            get { return _position; }
            set { _position = value; OnPropertyChanged("Position"); }
        }


        /// <summary>
        /// Populate UserModel from UserEntity
        /// </summary>
        /// <param name="userEntity">user</param>
        /// <returns>UserModel</returns>
        public UserModel PopulateUserModel(user userEntity)
        {
            return new UserModel
            {
                UserID = userEntity.userID,
                FullName = userEntity.userInfo.firstName + " " + userEntity.userInfo.lastName,
                Email = userEntity.userInfo.email,
                Phone = userEntity.userInfo.phone,
                Position = userEntity.userInfo.position
            };
        }

        /// <summary>
        /// Popluate UserModelList
        /// </summary>
        /// <param name="users">list of user</param>
        /// <returns>list of UserModel</returns>
        public List<UserModel> PopulateList(List<user> users)
        {
            List<UserModel> userModels = new List<UserModel>();
            foreach (var user in users)
            {
                userModels.Add(PopulateUserModel(user));
            }
            return userModels;
        }
    }
    #endregion
}
