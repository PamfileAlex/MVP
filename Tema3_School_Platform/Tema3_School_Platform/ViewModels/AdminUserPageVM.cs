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

        private bool studentVisibility;
        public bool StudentVisibility
        {
            get { return studentVisibility; }
            set
            {
                studentVisibility = value;
                NotifyPropertyChanged("StudentVisibility");
            }
        }

        private bool teacherVisibility;
        public bool TeacherVisibility
        {
            get { return teacherVisibility; }
            set
            {
                teacherVisibility = value;
                NotifyPropertyChanged("TeacherVisibility");
            }
        }

        private int userType;
        public int UserType
        {
            get { return userType; }
            set
            {
                userType = value;
                NotifyPropertyChanged("UserType");
                switch (UserType)
                {
                    case 0:
                        StudentVisibility = false;
                        TeacherVisibility = true;
                        break;
                    case 1:
                        StudentVisibility = true;
                        TeacherVisibility = false;
                        break;
                    default:
                        StudentVisibility = false;
                        TeacherVisibility = false;
                        break;
                }
            }
            //BIND from Enum to ComboBox for role using something like this:
            //Enum.GetValues(typeof(SomeEnum)).Cast<SomeEnum>();
            //AND then bind SelectedItem to User
        }

        public ICommand AddCommand { get; }
        public ICommand ModifyCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand ClearCommand { get; }

        public AdminUserPageVM()
        {
            this.User = User.NullUser;
            Clear();
            //this.AddCommand = new RelayCommand<User>(UserBLL.Instance.AddUser);
            this.AddCommand = new RelayCommand<User>(user => { UserBLL.Instance.AddUser(user); Clear(); });
            this.ModifyCommand = new RelayCommand<User>(user => { UserBLL.Instance.ModifyUser(user, DataGridSelectedIndex); Clear(); });
            this.RemoveCommand = new RelayCommand<User>(user => { UserBLL.Instance.RemoveUser(UserBLL.Instance.Users[DataGridSelectedIndex]); Clear(); });
            this.ClearCommand = new ActionCommand(Clear);
        }

        public void Clear()
        {
            DataGridSelectedIndex = -1;
            UserType = -1;
        }
    }
}
