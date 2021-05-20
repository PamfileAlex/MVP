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

        private int dataGridSelectedIndex;
        public int DataGridSelectedIndex
        {
            get { return dataGridSelectedIndex; }
            set
            {
                dataGridSelectedIndex = value;
                NotifyPropertyChanged("SelectedIndex");
                if (DataGridSelectedIndex == -1) { User = User.NullUser; return; }
                User = new User(UserBLL.Instance.Users[DataGridSelectedIndex]);
            }
        }

        public List<User.UserRole> UserRoles { get; }

        private User.UserRole userRole;
        public User.UserRole UserRole
        {
            get { return userRole; }
            set
            {
                userRole = value;
                NotifyPropertyChanged("UserRole");
            }
        }

        public ICommand AddCommand { get; }
        public ICommand ModifyCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand ClearCommand { get; }

        public AdminUserPageVM()
        {
            this.User = User.NullUser;
            Clear();
            UserRoles = Enum.GetValues(typeof(User.UserRole)).Cast<User.UserRole>().ToList();
            UserRoles.Remove(User.UserRole.Admin);
            //this.AddCommand = new RelayCommand<User>(UserBLL.Instance.AddUser);
            this.AddCommand = new RelayCommand<User>(user => { UserBLL.Instance.AddUser(user); Clear(); });
            this.ModifyCommand = new RelayCommand<User>(user => { UserBLL.Instance.ModifyUser(user, DataGridSelectedIndex); Clear(); });
            this.RemoveCommand = new RelayCommand<User>(user => { UserBLL.Instance.RemoveUser(UserBLL.Instance.Users[DataGridSelectedIndex]); Clear(); });
            this.ClearCommand = new ActionCommand(Clear);
        }

        public void Clear()
        {
            DataGridSelectedIndex = -1;
            UserRole = User.UserRole.None;
        }
    }
}
