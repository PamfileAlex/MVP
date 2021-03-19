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
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        private MainWindow mainWindow;
        public SearchPage(MainWindow window)
        {
            InitializeComponent();
            this.mainWindow = window;
            List<string> list = new List<string> { "cuvant", "test", "ananas", "alfabet", "alfa" };
            //autoComplete = new AutoComplete(this.autoTextBox, this.autoListPopup, this.autoList, list);
        }

        private void AutoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //autoComplete.AutoTextBox_TextChanged(sender, e);
        }

        private void AutoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //autoComplete.AutoList_SelectionChanged(sender, e);
        }

        private AutoComplete autoComplete;
    }
}
