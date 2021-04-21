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
        private static readonly GamePage gamePage;
        private static readonly AboutPage aboutPage;

        static ViewNavigator()
        {
            gamePage = new GamePage();
            aboutPage = new AboutPage();
            mainWindow = null;
        }

        public static MainWindow MainWindow
        {
            set
            {
                //if (mainWindow != null) { return; }
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
