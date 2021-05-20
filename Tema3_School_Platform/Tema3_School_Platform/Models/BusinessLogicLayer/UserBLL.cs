using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using Tema3_School_Platform.Models.DataAccessLayer;
using Tema3_School_Platform.Models.EntityLayer;
using Tema3_School_Platform.Utils;

namespace Tema3_School_Platform.Models.BusinessLogicLayer
{
    class UserBLL : BasePropertyChanged
    {
        public static UserBLL Instance { get; } = new UserBLL();
        public ObservableCollection<User> Users { get; }
        static UserBLL() { }
        private UserBLL()
        {
            Users = UserDAL.GetAllUsers();
        }

        public void UserLogin(String[] loginInfo)
        {
            User.CurrentUser = UserDAL.UserLogin(loginInfo[0], loginInfo[1]);
            if (User.CurrentUser == null) { return; }
            if (User.CurrentUser.Email.Contains("@admin"))
            {
                ViewNavigator.ChangePage(ViewNavigator.Page.Admin);
            }
            else if (User.CurrentUser.Email.Contains("@professor"))
            {
                ViewNavigator.ChangePage(ViewNavigator.Page.Professor);
            }
            else if (User.CurrentUser.Email.Contains("@student"))
            {
                ViewNavigator.ChangePage(ViewNavigator.Page.Student);
            }
        }

        public void AddUser(User user)
        {
            if (String.IsNullOrEmpty(user.FirstName) || String.IsNullOrEmpty(user.LastName)
                || String.IsNullOrEmpty(user.Email) || String.IsNullOrEmpty(user.Password)) { return; }
            //Check if 2 users have same Email
            if (UserDAL.CheckForEmailExistence(user)) { return; }
            UserDAL.AddUser(user);
            //Add to Users ObservableCollection
            //Get ID from DataBase
            //OPTION: Create new User based on ID from DB and previous User
            User userFromDB = UserDAL.UserLogin(user.Email, user.Password);
            if (userFromDB == null)
            {
                Console.WriteLine("ERROR");
                return;
            }
            Users.Add(userFromDB);
        }

        public void ModifyUser(User user, int selectedIndex)
        {
            Users[selectedIndex] = user;
            UserDAL.ModifyUser(user);
        }

        public void RemoveUser(User user)
        {
            if (!Users.Contains(user)) { return; }
            Users.Remove(user);
            UserDAL.RemoveUser(user);
        }
    }
}
