using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Tema3_School_Platform.Commands;
using Tema3_School_Platform.Models.BusinessLogicLayer;
using Tema3_School_Platform.Utils;

namespace Tema3_School_Platform.ViewModels
{
    class LoginPageVM : BasePropertyChanged
    {
        private UserBLL userBLL;
        private String errorMessage;
        public String ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                errorMessage = value;
                NotifyPropertyChanged("Error");
            }
        }

        private String username;
        public String Username
        {
            get { return username; }
            set
            {
                username = value;
                NotifyPropertyChanged("Username");
            }
        }

        private String password;
        public String Password
        {
            get { return password; }
            set
            {
                password = value;
                NotifyPropertyChanged("Password");
            }
        }

        public ICommand LoginCommand { get; }

        public LoginPageVM()
        {
            //LoginCommand = new ActionCommand(Login, CanLogin);
            userBLL = new UserBLL();
            LoginCommand = new RelayCommand<String[]>(userBLL.UserLogin);
        }

        private void Login()
        {

        }

        private bool CanLogin()
        {
            return !String.IsNullOrEmpty(Username);
        }
    }
}
