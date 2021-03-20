using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVP_Tema1_WPF
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private MainWindow mainWindow;

        public MainPage(MainWindow window)
        {
            InitializeComponent();
            this.mainWindow = window;
            //this.Background = window.Background;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine(sender.ToString());
            int index = int.Parse(((Button)e.Source).Uid);
            switch (index)
            {
                case 0:
                    mainWindow.Content = mainWindow.adminPage;
                    break;
                case 1:
                    mainWindow.Content = mainWindow.searchPage;
                    break;
                case 2:

                    break;
                case 3:
                    mainWindow.Close();
                    break;
                default:
                    break;
            }
        }
    }
}
