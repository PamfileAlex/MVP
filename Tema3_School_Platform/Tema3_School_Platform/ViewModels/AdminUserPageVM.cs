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

namespace Tema3_School_Platform.ViewModels
{
    class AdminUserPageVM : BaseVM
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
                ErrorMessage = String.Empty;
                if (DataGridSelectedIndex == -1) { User = new User(User.NullUser); ; return; }
                User = new User(UserBLL.Instance.Users[DataGridSelectedIndex]);
            }
        }

        public List<User.UserRole> UserRoles { get; }

        public ICommand AddCommand { get; }
        public ICommand ModifyCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand ClearCommand { get; }

        public AdminUserPageVM()
        {
            this.User = new User(User.NullUser);
            Clear();
            UserRoles = Enum.GetValues(typeof(User.UserRole)).Cast<User.UserRole>().ToList();
            //UserRoles.Remove(User.UserRole.Admin);
            //this.AddCommand = new RelayCommand<User>(user => { UserBLL.Instance.AddUser(user); Clear(); });
            this.AddCommand = new RelayCommand<User>(user => ErrorWrapper(() => { UserBLL.Instance.AddUser(user); Clear(); }));
            //this.ModifyCommand = new RelayCommand<User>(user => { UserBLL.Instance.ModifyUser(user, DataGridSelectedIndex); Clear(); });
            this.ModifyCommand = new RelayCommand<User>(user => ErrorWrapper(() => { UserBLL.Instance.ModifyUser(user, DataGridSelectedIndex); Clear(); }));
            //this.RemoveCommand = new RelayCommand<User>(user => { UserBLL.Instance.RemoveUser(UserBLL.Instance.Users[DataGridSelectedIndex]); Clear(); });
            this.RemoveCommand = new RelayCommand<User>(user => ErrorWrapper(() => { UserBLL.Instance.RemoveUser(UserBLL.Instance.Users[DataGridSelectedIndex]); Clear(); }));
            this.ClearCommand = new ActionCommand(Clear);
        }

        public void Clear()
        {
            DataGridSelectedIndex = -1;
            ErrorMessage = String.Empty;
        }
    }
}
