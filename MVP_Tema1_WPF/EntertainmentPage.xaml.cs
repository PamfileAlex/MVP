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
    /// Interaction logic for EntertainmentPage.xaml
    /// </summary>
    public partial class EntertainmentPage : Page
    {
        private MainWindow mainWindow;
        private AutoComplete autoComplete;

        public EntertainmentPage(MainWindow window)
        {
            InitializeComponent();
            this.mainWindow = window;
            autoComplete = new AutoComplete(this.WordTextBox, this.AutoCompletePopup,
                this.AutoCompleteList, mainWindow.Dictionary, mainWindow.Indexes, AutoCompleteAction);
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.AutoCompleteCheckBox.IsChecked = false;
            this.WordTextBox.Text = "";
            mainWindow.Content = mainWindow.mainPage;
        }

        private void QuizButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AutoCompleteCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (this.AutoCompleteCheckBox.IsChecked ?? false)
            {
                string aux = this.WordTextBox.Text;
                this.WordTextBox.Text = string.Empty;
                this.WordTextBox.Text = aux;
            }
        }

        private void WordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.QuizButton.IsEnabled = false;
            if (!(this.AutoCompleteCheckBox.IsChecked ?? false))
            {
                this.QuizButton.IsEnabled = !String.IsNullOrEmpty(this.WordTextBox.Text);
                return;
            }
            if (autoComplete == null)
            {
                return;
            }
            autoComplete.AutoTextBox_TextChanged(sender, e);
        }

        private void AutoCompleteList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (autoComplete == null)
            {
                return;
            }
            autoComplete.AutoList_SelectionChanged(sender, e);
        }

        private void AutoCompleteAction()
        {
            if (!mainWindow.Indexes.Active)
            {
                return;
            }
            this.QuizButton.IsEnabled = true;
        }
    }
}
