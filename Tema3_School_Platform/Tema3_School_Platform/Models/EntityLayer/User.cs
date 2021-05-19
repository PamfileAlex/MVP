using System;
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
        private String name;
        public String Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }
        private String surname;
        public String Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                NotifyPropertyChanged("Surname");
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

        public User(int id)
        {
            this.ID = id;
        }
    }
}
