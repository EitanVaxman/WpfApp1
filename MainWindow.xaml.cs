using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.LogicClasses;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region members
        UsersManager _Manager = new UsersManager();
        TracksSearch _ts = new TracksSearch();
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            int value = Int32.Parse(ConfigurationManager.AppSettings["JWT_TimeExpiration"]);
            _Manager.JWT_TimeExpiration = value;
            _ts.PageSourceArrivedEvent += _ts_PageSourceArrivedEvent;
        }

        private void _ts_PageSourceArrivedEvent(string content)
        {
            ;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
            UserCLS user = new UserCLS();

            if (login.DialogResult.HasValue && login.DialogResult.Value)
            {
                user.UserName = login.user.UserName;
                user.Password = login.user.Password;
                user.JWT = login.user.JWT;
                user.JWT_CreateTime = DateTime.Now;
            }

            else
            {
                MessageBox.Show("User clicked Cancel");
            }

            _Manager.AddUser(user);
            _ts.GetWebPageSourceAsync();
        }
    }
}
