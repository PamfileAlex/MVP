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
using System.Globalization;
using Microsoft.Win32;
using System.IO;
using System.Xml.Serialization;

namespace MVP_Tema1_WPF
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public MainWindow mainWindow { get; }
        private AutoComplete autoComplete;
        private bool modifyImage;

        public AdminPage(MainWindow window)
        {
            InitializeComponent();
            mainWindow = window;
            autoComplete = new AutoComplete(WordTextBox, AutoCompletePopup,
                AutoCompleteList, mainWindow.Dictionary, mainWindow.Indexes, AutoCompleteAction);
            CategoryComboBox.ItemsSource = mainWindow.Category;
            ModifyRemoveClearButtonsEnabled(false);
            modifyImage = false;
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            CommonEventAction();
            Reset();
            mainWindow.Content = mainWindow.mainPage;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            CommonEventAction();
            if (!Check()) { return; }
            AddWord();
            Reset();
        }

        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            CommonEventAction();
            if (!mainWindow.Indexes.Active || !Check(true)) { return; }
            modifyImage = true;
            AddWord();
            RemoveWord();
            Reset();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            CommonEventAction();
            if (!mainWindow.Indexes.Active) { return; }
            RemoveWord();
            Reset();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            CommonEventAction();
            Reset();
        }

        private void UploadPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            CommonEventAction();
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                WordImage.Source = new BitmapImage(new Uri(op.FileName));
                ClearPhotoButton.IsEnabled = true;
            }
        }

        private void ClearPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            CommonEventAction();
            WordImage.Source = null;
            ClearPhotoButton.IsEnabled = false;
        }

        private void CategoryCheckBox_Click(object sender, RoutedEventArgs e)
        {
            CommonEventAction();
            if (CategoryCheckBox.IsChecked ?? false)
            {
                CategoryComboBox.SelectedIndex = -1;
                CategoryComboBox.Visibility = Visibility.Hidden;
                CategoryTextBox.Visibility = Visibility.Visible;
            }
            else
            {
                CategoryTextBox.Text = String.Empty;
                CategoryTextBox.Visibility = Visibility.Hidden;
                CategoryComboBox.Visibility = Visibility.Visible;
            }
        }

        private void WordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CommonEventAction();
            if (autoComplete == null) { return; }
            autoComplete.AutoTextBox_TextChanged(sender, e);
        }

        private void AutoCompleteList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CommonEventAction();
            if (autoComplete == null) { return; }
            autoComplete.AutoList_SelectionChanged(sender, e);
        }

        private void AutoCompleteAction()
        {
            if (!mainWindow.Indexes.Active)
            {
                ModifyRemoveClearButtonsEnabled(false);
                return;
            }
            ModifyRemoveClearButtonsEnabled(true);
            //WordTextBox.Text = mainWindow.Dictionary[mainWindow.Indexes.CategoryIndex].Words[mainWindow.Indexes.WordIndex].WordText;
            DescriptionTextBox.Text = mainWindow.Dictionary[mainWindow.Indexes.CategoryIndex].Words[mainWindow.Indexes.WordIndex].Description;
            CategoryComboBox.SelectedIndex = mainWindow.Indexes.CategoryIndex;
            CategoryCheckBox.IsChecked = false;
            CategoryCheckBox_Click(null, null);
            WordImage.Source = Utils.GetWordPhoto(WordTextBox.Text);
            if (WordImage.Source != null)
            {
                ClearPhotoButton.IsEnabled = true;
            }
        }

        public void AutoCompleteActionOutside()
        {
            WordTextBox.Text = mainWindow.Dictionary[mainWindow.Indexes.CategoryIndex].Words[mainWindow.Indexes.WordIndex].WordText;
            autoComplete.CloseAutoSuggestionBox();
            AutoCompleteAction();
        }

        private void AddWord()
        {
            int index;
            if (CategoryComboBox.SelectedIndex != -1)
            {
                index = CategoryComboBox.SelectedIndex;
            }
            else
            {
                mainWindow.Dictionary.Add(new Category(CategoryTextBox.Text));
                index = mainWindow.Dictionary.Count - 1;
                mainWindow.Category.Add(CategoryTextBox.Text);
            }
            mainWindow.Dictionary[index].Words.Add(new Word(WordTextBox.Text, DescriptionTextBox.Text));
            if (WordImage.Source != null)
            {
                string imagePath = WordImage.Source.ToString().Replace("file:///", "");
                WordImage.Source = null;
                try
                {
                    System.IO.File.Copy(imagePath, "..\\..\\..\\Photos\\" + WordTextBox.Text + System.IO.Path.GetExtension(imagePath), true);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    if (!mainWindow.Indexes.Active) { return; }
                    string previousWord = mainWindow.Dictionary[mainWindow.Indexes.CategoryIndex].Words[mainWindow.Indexes.WordIndex].WordText;
                    imagePath = Utils.GetPhotoPath(previousWord);
                    try
                    {
                        System.IO.File.Copy(imagePath, "..\\..\\..\\Photos\\" + WordTextBox.Text + System.IO.Path.GetExtension(imagePath), true);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private void RemoveWord()
        {
            WordImage.Source = null;
            string wordText = mainWindow.Dictionary[mainWindow.Indexes.CategoryIndex].Words[mainWindow.Indexes.WordIndex].WordText;
            string path = Utils.GetPhotoPath(wordText);
            if (path != null && (!modifyImage || !ClearPhotoButton.IsEnabled || !WordTextBox.Text.Equals(wordText)) && File.Exists(path))
            {
                File.Delete(path);
            }
            modifyImage = false;
            mainWindow.Dictionary[mainWindow.Indexes.CategoryIndex].Words.RemoveAt(mainWindow.Indexes.WordIndex);
            if (mainWindow.Dictionary[mainWindow.Indexes.CategoryIndex].Words.Count == 0)
            {
                mainWindow.Dictionary.RemoveAt(mainWindow.Indexes.CategoryIndex);
                mainWindow.Category.RemoveAt(mainWindow.Indexes.CategoryIndex);
            }
        }

        private void ModifyRemoveClearButtonsEnabled(bool option)
        {
            ModifyButton.IsEnabled = option;
            RemoveButton.IsEnabled = option;
            //ClearButton.IsEnabled = option;
        }

        private void CommonEventAction()
        {
            ErrorText.Text = String.Empty;
            ClearButton.IsEnabled = true;
        }

        private void Reset()
        {
            WordTextBox.Text = String.Empty;
            DescriptionTextBox.Text = String.Empty;
            CategoryTextBox.Text = String.Empty;
            CategoryComboBox.SelectedIndex = -1;
            ClearButton.IsEnabled = false;
            WordImage.Source = null;
            mainWindow.Indexes.set(-1, -1, false);
            ModifyRemoveClearButtonsEnabled(false);
        }
    }
}
