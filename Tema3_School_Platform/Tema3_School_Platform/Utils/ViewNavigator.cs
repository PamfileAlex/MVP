using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Tema3_School_Platform.Views;

namespace Tema3_School_Platform.Utils
{
    static class ViewNavigator
    {
        public enum MainPage
        {
            None, Login, Admin, Professor, Student
        }
        private static MainWindow mainWindow;
        public static MainWindow MainWindow
        {
            set
            {
                //if (mainWindow != null) { return; }
                mainWindow = value;
            }
        }

        public static void ChangePage(MainPage page)
        {
            if (mainWindow == null) { return; }
            switch (page)
            {
                case MainPage.None:
                    return;
                case MainPage.Login:
                    mainWindow.Content = new LoginPage();
                    break;
                case MainPage.Admin:
                    mainWindow.Content = new AdminPage();
                    break;
                case MainPage.Professor:
                    mainWindow.Content = new ProfessorPage();
                    break;
                case MainPage.Student:
                    mainWindow.Content = new StudentPage();
                    break;
            }
        }

        public static Page AdminPageControl(int option)
        {
            switch (option)
            {
                case 1:
                    return new UserPage();
                case 2:
                    return new SpecializationSubjectPage();
                default:
                    return null;
            }
        }
    }
}
