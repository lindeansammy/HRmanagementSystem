using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfTeamProject.ViewModel;

namespace WpfTeamProject.View
{
    /// <summary>
    /// Interaction logic for AdminRegister.xaml
    /// </summary>
    public partial class AdminRegister : Window
    {
        public AdminRegister()
        {
            InitializeComponent();
            //DataContext = new AdminRegisterViewModel();
        }

        private void btn_cancel(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*
             * //实例化 AdminRegisterViewModel 这个类 ，并且设置变量名为btn_newAdmin
             * 设置类型为 bool 变量 resultShow 默认值为 false
             * 使用变量 resultShow 来接收 register 方法的返回值
             * 判段输出不同的结果true代表添加成功，false 反之
             */
            AdminRegisterViewModel btn_newAdmin = new AdminRegisterViewModel();
            bool resultShow = false;
            resultShow = btn_newAdmin.Register(AdminUN.Text, AdminPW.Text);
            if (resultShow == false)
            {
                AdminUN.Text = "";
                AdminPW.Text = "";
            }
            else
            {
                MessageBox.Show("Sucessfully create .");
                AdminUN.Text = "";
                AdminPW.Text = "";
            }


        }
    }
}
