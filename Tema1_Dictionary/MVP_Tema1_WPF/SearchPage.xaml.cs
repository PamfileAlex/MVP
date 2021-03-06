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
            mainWindow = window;
            autoComplete = new AutoComplete(WordTextBox, AutoCompletePopup,
                AutoCompleteList, mainWindow.Dictionary, mainWindow.Indexes, AutoCompleteAction);
            CategoryComboBox.ItemsSource = mainWindow.Category;
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Reset();
            mainWindow.Content = mainWindow.mainPage;
        }

        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!mainWindow.Indexes.Active) { return; }
            mainWindow.adminPage.AutoCompleteActionOutside();
            Reset();
            mainWindow.Content = mainWindow.adminPage;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearButton.IsEnabled = true;
        }

        private void WordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (autoComplete == null) { return; }
            autoComplete.AutoTextBox_TextChanged(sender, e, CategoryComboBox);
        }

        private void AutoCompleteList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (autoComplete == null) { return; }
            autoComplete.AutoList_SelectionChanged(sender, e);
        }

        private void AutoCompleteAction()
        {
            if (!mainWindow.Indexes.Active) { return; }
            DescriptionTextBlock.Text = mainWindow.Dictionary[mainWindow.Indexes.CategoryIndex].Words[mainWindow.Indexes.WordIndex].Description;
            CategoryTextBlock.Text = mainWindow.Dictionary[mainWindow.Indexes.CategoryIndex].Title;
            WordImage.Source = Utils.GetWordPhoto(WordTextBox.Text);
            if (WordImage.Source == null)
            {
                WordImage.Source = Utils.GetWordPhoto("noImageFound");
            }
            ClearButton.IsEnabled = true;
            ModifyButton.IsEnabled = true;
        }

        private void Reset()
        {
            WordTextBox.Text = String.Empty;
            DescriptionTextBlock.Text = String.Empty;
            CategoryTextBlock.Text = String.Empty;
            CategoryComboBox.SelectedIndex = -1;
            ClearButton.IsEnabled = false;
            ModifyButton.IsEnabled = false;
            WordImage.Source = null;
        }
    }
}
