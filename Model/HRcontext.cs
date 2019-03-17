using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WpfTeamProject.Datas;

namespace WpfTeamProject.Model
{
    public class HRcontext: DbContext
    {

        public HRcontext():base("wpf_databaseEntities")
        {

        }


        public DbSet<applicationDetail> ApplicationDetails { get; set; }
        public DbSet<job> Jobs { get; set; }
        public DbSet<user> Users { get; set; }
        public DbSet<userInfo> UserInfos { get; set; }
    }
}
