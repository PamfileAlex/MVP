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
        private String errorMessage;
        public String ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                errorMessage = value;
                NotifyPropertyChanged("ErrorMessage");
            }
        }

        public ICommand LoginCommand { get; }

        public LoginPageVM()
        {
            LoginCommand = new RelayCommand<String[]>(UserBLL.Instance.UserLogin);
        }
    }
}
