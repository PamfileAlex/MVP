using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tema3_School_Platform.Views;

namespace Tema3_School_Platform.Utils
{
    static class ViewNavigator
    {
        private static readonly LoginPage loginPage;
        private static MainWindow mainWindow;
        public static MainWindow MainWindow
        {
            set
            {
                //if (mainWindow != null) { return; }
                mainWindow = value;
            }
        }

        static ViewNavigator()
        {
            loginPage = new LoginPage();
        }

        public static void ChangeToLoginPage()
        {
            if (mainWindow == null) { return; }
            mainWindow.Content = loginPage;
        }
    }
}
