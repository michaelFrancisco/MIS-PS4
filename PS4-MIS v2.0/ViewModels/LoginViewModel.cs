using Caliburn.Micro;
using PS4_MIS_v2._0.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PS4_MIS_v2._0.ViewModels
{
    class LoginViewModel : Screen
    {
        private string _username;
        private string _password;
        IWindowManager windowManager = new WindowManager();

        public string username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string password
        {
            get { return _password; }
            set { _password = value;}
        }

        public void login()
        {
            if(connection.verifyLogin(_username, _password))
            {
                MessageBox.Show("Oks");
                windowManager.ShowWindow(new MainViewModel(), null, null);
                TryClose();
            }
        }


    }
}
