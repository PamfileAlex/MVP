﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tema3_School_Platform.Exceptions;
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
            ClassBLL.Instance.Init();
            Users = UserDAL.GetAllUsers();
        }

        public void UserLogin(String[] loginInfo)
        {
            User.CurrentUser = UserDAL.UserLogin(loginInfo[0], loginInfo[1]);
            if (User.CurrentUser == null)
                throw new SchoolPlatformException("Incorrect Email or Password");
            switch (User.CurrentUser.Role)
            {
                case User.UserRole.Admin:
                    ViewNavigator.ChangePage(ViewNavigator.MainPage.Admin);
                    break;
                case User.UserRole.Professor:
                    ViewNavigator.ChangePage(ViewNavigator.MainPage.Professor);
                    break;
                case User.UserRole.Student:
                    ViewNavigator.ChangePage(ViewNavigator.MainPage.Student);
                    break;
                default:
                    break;
            }
        }

        public void AddUser(User user)
        {
            AdminCheck(user);
            CheckUserFields(user);
            CheckForEmailExistence(user);
            UserDAL.AddUser(user);
            User userFromDB = UserDAL.UserLogin(user.Email, user.Password);
            if (userFromDB == null)
                throw new SchoolPlatformException("Add User failed");
            Users.Add(userFromDB);
        }

        public void RemoveUser(User user)
        {
            AdminCheck(user);
            //if (!Users.Contains(user)) { return; }
            if (!Users.Remove(user))
                throw new SchoolPlatformException("Remove User failed");
            UserDAL.RemoveUser(user);
        }

        public void ModifyUser(User user, int selectedIndex)
        {
            if (Users[selectedIndex].Role == User.UserRole.Admin)
                throw new SchoolPlatformException("Cannot Modify Admin");
            AdminCheck(user);
            CheckUserFields(user);
            if (!user.Email.Equals(Users[selectedIndex].Email))
                CheckForEmailExistence(user);
            Users[selectedIndex] = user;
            UserDAL.ModifyUser(user);
        }

        private void AdminCheck(User user)
        {
            if (user.Role == User.UserRole.Admin)
                throw new SchoolPlatformException("Cannot set Admin role");
        }

        private void CheckUserFields(User user)
        {
            if (String.IsNullOrEmpty(user.FirstName) || String.IsNullOrEmpty(user.LastName)
                || String.IsNullOrEmpty(user.Email) || String.IsNullOrEmpty(user.Password))
                throw new SchoolPlatformException("Please fill all inputs");
            if (user.Role == User.UserRole.None)
                throw new SchoolPlatformException("Please select a role");
            if (user.Role == User.UserRole.Student && user.Class == null)
                throw new SchoolPlatformException("Please select a class");
        }

        private void CheckForEmailExistence(User user)
        {
            if (UserDAL.CheckForEmailExistence(user))
                throw new SchoolPlatformException("Email address is taken");
        }
    }
}
