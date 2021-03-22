using System;
using System.Collections.Generic;
using System.IO;
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
        private AutoComplete autoComplete;

        public SearchPage(MainWindow window)
        {
            InitializeComponent();
            this.mainWindow = window;
            autoComplete = new AutoComplete(this.WordTextBox, this.AutoCompletePopup, this.AutoCompleteList, mainWindow.Dictionary);
            this.CategoryComboBox.ItemsSource = mainWindow.Category;
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Content = mainWindow.mainPage;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            WordTextBox.Text = "";
            DescriptionTextBlock.Text = "";
            CategoryComboBox.SelectedIndex = -1;
            //ClearButton.IsEnabled = false;
            WordImage.Source = null;
        }

        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void WordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (autoComplete == null)
            {
                return;
            }
            autoComplete.AutoTextBox_TextChanged(sender, e, CategoryComboBox);
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
            this.WordTextBox.Text = this.AutoCompleteList.SelectedItem.ToString();
            /*indexes = GetWordIndexes();
            if (indexes == null)
            {
                return;
            }
            this.DescriptionTextBlock.Text = mainWindow.Dictionary[indexes.Item1].Words[indexes.Item2].Description;
            CategoryTextBlock.Text = mainWindow.Dictionary[indexes.Item1].Title;*/
            WordImage.Source = Utils.getWordPhoto(this.AutoCompleteList.SelectedItem.ToString());
        }
    }
}
