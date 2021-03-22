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
        private MainWindow mainWindow;
        private AutoComplete autoComplete;
        private Tuple<int, int> indexes;

        public AdminPage(MainWindow window)
        {
            InitializeComponent();
            this.mainWindow = window;
            autoComplete = new AutoComplete(this.WordTextBox, this.AutoCompletePopup, this.AutoCompleteList, mainWindow.Dictionary, AutoCompleteAction);
            //this.CategoryComboBox.ItemsSource = mainWindow.Dictionary;//.Select(category => category.Title);
            this.CategoryComboBox.ItemsSource = mainWindow.Category;
            ModifyRemoveClearButtonsEnabled(false);
            //ReinitializeCategoryComboBoxItems();
        }

        private void ReinitializeCategoryComboBoxItems()
        {
            foreach (var category in mainWindow.Dictionary)
            {
                CategoryComboBox.Items.Add(category.Title);
            }
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            CommonEventAction();
            mainWindow.Content = mainWindow.mainPage;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            CommonEventAction();
            if (!Check())
            {
                return;
            }
            AddWord();
            if (ImgPhoto.Source != null)
            {
                string imagePath = ImgPhoto.Source.ToString().Replace("file:///", "");
                System.IO.File.Copy(imagePath, "..\\..\\..\\Photos\\" + WordTextBox.Text + System.IO.Path.GetExtension(imagePath), true);
            }
            Reset();
        }

        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            CommonEventAction();
            if (!Check() || indexes == null)
            {
                return;
            }
            //mainWindow.Dictionary[indexes.Item1].Words[indexes.Item2];
            AddWord();
            RemoveWord();
            Reset();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            CommonEventAction();
            if (indexes == null)
            {
                return;
            }
            RemoveWord();
            Reset();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
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
                ImgPhoto.Source = new BitmapImage(new Uri(op.FileName));
                ClearPhotoButton.IsEnabled = true;
                //System.IO.File.Copy(op.FileName, "..\\Photos\\" + WordTextBox.Text);
                //Console.WriteLine(".\\" + WordTextBox.Text + System.IO.Path.GetExtension(op.FileName));
                //System.IO.File.Copy(op.FileName, "..\\..\\..\\Photos\\" + WordTextBox.Text + System.IO.Path.GetExtension(op.FileName), true);
            }
        }

        private void ClearPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            CommonEventAction();
            ImgPhoto.Source = null;
            ClearPhotoButton.IsEnabled = false;
        }

        private void CommonEventAction()
        {
            ErrorText.Text = "";
            ClearButton.IsEnabled = true;
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
                CategoryTextBox.Text = "";
                CategoryTextBox.Visibility = Visibility.Hidden;
                CategoryComboBox.Visibility = Visibility.Visible;
            }
        }

        private void WordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CommonEventAction();
            if (autoComplete == null)
            {
                return;
            }
            autoComplete.AutoTextBox_TextChanged(sender, e);
        }

        private void AutoCompleteList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CommonEventAction();
            if (autoComplete == null)
            {
                return;
            }
            autoComplete.AutoList_SelectionChanged(sender, e);
        }

        private void AutoCompleteAction()
        {
            this.WordTextBox.Text = this.AutoCompleteList.SelectedItem.ToString();
            //int index = mainWindow.Dictionary.FindIndex(word => word.WordText.Equals(this.AutoCompleteList.SelectedItem.ToString()));
            //int index = mainWindow.Dictionary.FindIndex(category => category.Words.Exists(word => word.WordText.Equals(this.AutoCompleteList.SelectedItem.ToString())));
            indexes = GetWordIndexes();
            if (indexes == null)
            {
                ModifyRemoveClearButtonsEnabled(false);
                return;
            }
            ModifyRemoveClearButtonsEnabled(true);
            this.DescriptionTextBox.Text = mainWindow.Dictionary[indexes.Item1].Words[indexes.Item2].Description;
            CategoryComboBox.SelectedIndex = indexes.Item1;
            CategoryCheckBox.IsChecked = false;
            CategoryCheckBox_Click(null, null);

            //string path = "D:\\Programming\\Facultate\\MVP_Tema1_WPF\\Photos\\" + this.AutoCompleteList.SelectedItem.ToString() + ".png";
            //string path = Environment.CurrentDirectory + "\\..\\..\\..\\Photos\\" + this.AutoCompleteList.SelectedItem.ToString() + ".png";
            //var strings = Directory.GetFiles("..\\..\\..\\Photos\\", this.AutoCompleteList.SelectedItem.ToString() + ".*");
            //string path = Environment.CurrentDirectory + "\\" + strings[0];
            string path = GetPhotoPath(this.AutoCompleteList.SelectedItem.ToString());
            /*Console.WriteLine(strings.Length);
            foreach (var x in strings)
            {
                Console.WriteLine(x);
            }*/
            if (File.Exists(path))
            {
                ImgPhoto.Source = new BitmapImage(new Uri(path));
            }
        }

        private string GetPhotoPath(string photoName)
        {
            var files = Directory.GetFiles("..\\..\\..\\Photos\\", photoName + ".*");
            if (files.Length == 0)
            {
                return "";
            }
            return Environment.CurrentDirectory + "\\" + files[0];
        }

        private void AddWord()
        {
            int index;
            if (CategoryComboBox.SelectedIndex != -1)
            {
                //mainWindow.Dictionary[CategoryComboBox.SelectedIndex].Words.Add(new Word(WordTextBox.Text, DescriptionTextBox.Text));
                index = CategoryComboBox.SelectedIndex;
            }
            else
            {
                mainWindow.Dictionary.Add(new Category(CategoryTextBox.Text));
                //mainWindow.Dictionary[mainWindow.Dictionary.Count - 1].Words.Add(new Word(WordTextBox.Text, DescriptionTextBox.Text));
                index = mainWindow.Dictionary.Count - 1;
                //CategoryComboBox.Items.Add(CategoryTextBox.Text);
                mainWindow.Category.Add(CategoryTextBox.Text);
            }
            mainWindow.Dictionary[index].Words.Add(new Word(WordTextBox.Text, DescriptionTextBox.Text));
        }

        private void RemoveWord()
        {
            ImgPhoto.Source = null;
            //File.Delete(GetPhotoPath(mainWindow.Dictionary[indexes.Item1].Words[indexes.Item2].WordText));
            mainWindow.Dictionary[indexes.Item1].Words.RemoveAt(indexes.Item2);
            if (mainWindow.Dictionary[indexes.Item1].Words.Count == 0)
            {
                mainWindow.Dictionary.RemoveAt(indexes.Item1);
                //this.CategoryComboBox.Items.RemoveAt(indexes.Item1);
                mainWindow.Category.RemoveAt(indexes.Item1);
            }
        }

        private Tuple<int, int> GetWordIndexes()
        {
            for (int index = 0; index < mainWindow.Dictionary.Count; ++index)
            {
                int wordIndex = mainWindow.Dictionary[index].Words.FindIndex(word => word.WordText.Equals(this.AutoCompleteList.SelectedItem.ToString()));
                if (wordIndex != -1)
                {
                    return new Tuple<int, int>(index, wordIndex);
                }
            }
            return null;
        }

        private void ModifyRemoveClearButtonsEnabled(bool option)
        {
            ModifyButton.IsEnabled = option;
            RemoveButton.IsEnabled = option;
            //ClearButton.IsEnabled = option;
        }

        private bool Check()
        {
            /*return !String.IsNullOrEmpty(WordTextBox.Text) && !String.IsNullOrEmpty(DescriptionTextBox.Text) &&
                (CategoryCheckBox.IsChecked ?? false) ? String.IsNullOrEmpty(CategoryTextBox.Text) ||
                !mainWindow.Dictionary.Exists(x => x.WordText.Equals(WordTextBox.Text)) : CategoryComboBox.SelectedIndex != -1;*/
            return CheckAllNotEmpty();
        }

        private bool CheckAllNotEmpty()
        {
            /*Console.WriteLine(!String.IsNullOrEmpty(WordTextBox.Text));
            Console.WriteLine(!String.IsNullOrEmpty(DescriptionTextBox.Text));
            Console.WriteLine((CategoryCheckBox.IsChecked ?? false));
            Console.WriteLine((CategoryCheckBox.IsChecked ?? false) ? !String.IsNullOrEmpty(CategoryTextBox.Text) : CategoryComboBox.SelectedIndex != -1);
            Console.WriteLine("........................");*/
            if (!String.IsNullOrEmpty(WordTextBox.Text) && !String.IsNullOrEmpty(DescriptionTextBox.Text) &&
                (CategoryCheckBox.IsChecked ?? false) ? !String.IsNullOrEmpty(CategoryTextBox.Text) : CategoryComboBox.SelectedIndex != -1)
            {
                return true;
            }
            ErrorText.Text = "Nu sunt completate toate campurile";
            return false;
        }

        private void Reset()
        {
            WordTextBox.Text = "";
            DescriptionTextBox.Text = "";
            CategoryTextBox.Text = "";
            CategoryComboBox.SelectedIndex = -1;
            ClearButton.IsEnabled = false;
            ImgPhoto.Source = null;
            indexes = null;
            ModifyRemoveClearButtonsEnabled(false);
        }
    }
}
