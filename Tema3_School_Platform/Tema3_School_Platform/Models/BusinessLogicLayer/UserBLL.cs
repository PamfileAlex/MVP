using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tema3_School_Platform.Models.DataAccessLayer;
using Tema3_School_Platform.Utils;

namespace Tema3_School_Platform.Models.BusinessLogicLayer
{
    class UserBLL : BasePropertyChanged
    {
        public void UserLogin(String[] login)
        {
            if (UserDAL.UserLogin(login[0], login[1]) == null)
            {
                MessageBox.Show("Nu s-a putut loga");
                return;
            }
            MessageBox.Show(String.Format("S-a logat utilizatorul:\n{0}\n{1}", login[0], login[1]));
        }
    }
}
