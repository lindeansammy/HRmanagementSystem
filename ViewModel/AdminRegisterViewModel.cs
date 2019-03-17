using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfTeamProject.Datas;
using WpfTeamProject.Helpers;
using WpfTeamProject.View;

namespace WpfTeamProject.ViewModel
{
    class AdminRegisterViewModel
    {
        //create connection to data base as gobal variable;
        wpf_databaseEntities context = new wpf_databaseEntities();


        /// <summary>
        /// register a new Admin
        /// </summary>
        /// <param name="AdminUN"></param>
        /// <param name="AdminPW"></param>
        /// <param name="AdminEM"></param>
        public bool Register(string AdminUN, string AdminPW) //bool is for benefit not only how code run ,but laso what message to show
        {
            /*
            * first i need to check it userName,password,email is empty or not
            * secondly i need to check is there any duplicate userName
            * finally i need to save it in to database with bool true type
             */

            if (string.IsNullOrEmpty(AdminUN) || string.IsNullOrEmpty(AdminPW))
            {
                MessageBox.Show("There is one text box is empty");
                return false;
            }
            else
            {
                /*  create a paramenter name call "result" which is from databa
                 * "context" mean connect to database at we use DBset<user> users table, 
                 * "where" column name userName,but we give "x" as a hold value
                 * x will point to x.userName,and will be variable for AdminUN (where is the input value from we set at the beginning )
                 * "Any" mean any value inside of x.userName
                 */
                var result = context.users.Where(x => x.userName == AdminUN).Any();
                if (result == true)
                {
                    MessageBox.Show("There is Admin with same name exits");
                    return false;
                }
                else
                {
                    user NewAdmin = new user(); //create 新实体类（new user） 实例化 ，这个使用 类（user）并且给予新的名字NewAdmin

                    NewAdmin.userName = AdminUN; //把输入的参数（AdminUN,AdminPW）对应到新的实体类中
                    NewAdmin.password = AdminPW;
                    NewAdmin.type = true; //由于我们的project要求，Type 要写死成true

                    context.users.Add(NewAdmin); //加入到database 的方法
                    context.SaveChanges(); //并且保存
                    return true;
                }
            }
        }
    }
}
