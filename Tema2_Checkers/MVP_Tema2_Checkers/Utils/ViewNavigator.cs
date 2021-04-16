using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVP_Tema2_Checkers.Views;

namespace MVP_Tema2_Checkers.Utils
{
    static class ViewNavigator
    {
        private static MainWindow mainWindow;
        private static GamePage gamePage;
        private static AboutPage aboutPage;

        static ViewNavigator()
        {
            gamePage = new GamePage();
            aboutPage = new AboutPage();
        }

        public static MainWindow MainWindow
        {
            set
            {
                mainWindow = value;
            }
        }

        public static void ChangeToGamePage()
        {
            if (mainWindow == null) { return; }
            mainWindow.Content = gamePage;
        }

        public static void ChangeToAboutPage()
        {
            if (mainWindow == null) { return; }
            mainWindow.Content = aboutPage;
        }

        public static void CloseWindow()
        {
            if (mainWindow == null) { return; }
            mainWindow.Close();
        }
    }
}
