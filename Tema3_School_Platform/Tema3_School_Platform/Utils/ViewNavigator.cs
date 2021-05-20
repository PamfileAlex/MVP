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

        public enum Page
        {
            None, Login, Admin, Professor, Student
        }

        private static readonly LoginPage loginPage;
        private static readonly AdminPage adminPage;
        private static readonly ProfessorPage professorPage;
        private static readonly StudentPage studentPage;
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
            adminPage = new AdminPage();
            professorPage = new ProfessorPage();
            studentPage = new StudentPage();
        }

        public static void ChangePage(Page page)
        {
            if (mainWindow == null) { return; }
            switch (page)
            {
                case Page.None:
                    return;
                case Page.Login:
                    mainWindow.Content = new LoginPage();
                    break;
                case Page.Admin:
                    mainWindow.Content = adminPage;
                    break;
                case Page.Professor:
                    mainWindow.Content = professorPage;
                    break;
                case Page.Student:
                    mainWindow.Content = studentPage;
                    break;
            }
        }
    }
}
