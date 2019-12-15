using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        #region members
        public UserCLS user = new UserCLS();
        private string _JWT = string.Empty;
        public string JWT { get { return _JWT; } }
        #endregion

        #region ctor
        public Login()
        {
            InitializeComponent();
        }
        #endregion

        #region methods
        private void Login1_Click(object sender, RoutedEventArgs e)
        {
            user.UserName = this.tbUsername.Text;
            user.Password = this.tbPassword.Text;
            //Now Get JWT for this user
            string payloadStr = user.UserName + user.Password + DateTime.Now.Ticks.ToString();
            user.JWT = GetJWT.Instance.GetJsonWebToke(payloadStr);
            DialogResult = true;
        }
        #endregion
    }
}
