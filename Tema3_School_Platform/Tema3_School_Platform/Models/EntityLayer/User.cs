﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tema3_School_Platform.Utils;

namespace Tema3_School_Platform.Models.EntityLayer
{
    class User : BasePropertyChanged
    {
        public int ID { get; }
        private String firstName;
        public String FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                NotifyPropertyChanged("FirstName");
            }
        }
        private String lastName;
        public String LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                NotifyPropertyChanged("LastName");
            }
        }
        private String email;
        public String Email
        {
            get { return email; }
            set
            {
                email = value;
                NotifyPropertyChanged("Email");
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

        public static User CurrentUser { get; set; } = null;
        public static User NullUser { get; } = new User(0);
        public User(int id)
        {
            this.ID = id;
        }

        public User(User other)
        {
            this.ID = other.ID;
            this.FirstName = other.FirstName == null ? String.Empty : String.Copy(other.FirstName);
            this.LastName = other.LastName == null ? String.Empty : String.Copy(other.LastName);
            this.Email = other.Email == null ? String.Empty : String.Copy(other.Email);
            this.Password = other.Password == null ? String.Empty : String.Copy(other.Password);
        }

        public User(int id, User other) : this(other)
        {
            this.ID = id;
        }
    }
}