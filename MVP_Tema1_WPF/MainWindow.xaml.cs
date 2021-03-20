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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainPage mainPage;
        public AdminPage adminPage;
        public SearchPage searchPage;
        //private List<Word> dictionary;

        public List<Word> Dictionary { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            Dictionary = new List<Word>();
            PageInit();
            this.Content = mainPage;
        }

        private void PageInit()
        {
            mainPage = new MainPage(this);
            adminPage = new AdminPage(this);
            searchPage = new SearchPage(this);
        }
    }
}
