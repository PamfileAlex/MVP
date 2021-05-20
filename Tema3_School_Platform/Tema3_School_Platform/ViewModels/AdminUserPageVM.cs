using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Tema3_School_Platform.Commands;
using Tema3_School_Platform.Models.BusinessLogicLayer;
using Tema3_School_Platform.Models.EntityLayer;
using Tema3_School_Platform.Utils;

namespace Tema3_School_Platform.ViewModels
{
    class AdminUserPageVM : BasePropertyChanged
    {
        public ObservableCollection<User> Users { get { return UserBLL.Instance.Users; } }
        private User user;
        public User User
        {
            get { return user; }
            set
            {
                user = value;
                NotifyPropertyChanged("User");
            }
        }
        private int selectedIndex;
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
                NotifyPropertyChanged("SelectedIndex");
                if (SelectedIndex == -1) { User = User.NullUser; return; }
                User = new User(UserBLL.Instance.Users[SelectedIndex]);
            }
        }
        public ICommand AddCommand { get; }
        public ICommand ModifyCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand ClearCommand { get; }

        public AdminUserPageVM()
        {
            this.User = User.NullUser;
            this.SelectedIndex = -1;
            this.AddCommand = new RelayCommand<User>(UserBLL.Instance.AddUser);
            this.ClearCommand = new ActionCommand(() => SelectedIndex = -1);
        }
    }
}
