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

        public AdminPage(MainWindow window)
        {
            InitializeComponent();
            this.mainWindow = window;
            autoComplete = new AutoComplete(this.WordTextBox, this.AutoCompletePopup,
                this.AutoCompleteList, mainWindow.Dictionary, mainWindow.Indexes, AutoCompleteAction);
            this.CategoryComboBox.ItemsSource = mainWindow.Category;
            ModifyRemoveClearButtonsEnabled(false);
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
            if (!Check())
            {
                return;
            }
            AddWord();
            Reset();
        }

        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            CommonEventAction();
            if (!Check() || !mainWindow.Indexes.Active)
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
            if (!mainWindow.Indexes.Active)
            {
                return;
            }
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
                //System.IO.File.Copy(op.FileName, "..\\Photos\\" + WordTextBox.Text);
                //Console.WriteLine(".\\" + WordTextBox.Text + System.IO.Path.GetExtension(op.FileName));
                //System.IO.File.Copy(op.FileName, "..\\..\\..\\Photos\\" + WordTextBox.Text + System.IO.Path.GetExtension(op.FileName), true);
            }
        }

        private void ClearPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            CommonEventAction();
            WordImage.Source = null;
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
            //this.WordTextBox.Text = this.AutoCompleteList.SelectedItem.ToString();

            //int index = mainWindow.Dictionary.FindIndex(word => word.WordText.Equals(this.AutoCompleteList.SelectedItem.ToString()));
            //int index = mainWindow.Dictionary.FindIndex(category => category.Words.Exists(word => word.WordText.Equals(this.AutoCompleteList.SelectedItem.ToString())));
            //mainWindow.Indexes = Utils.GetWordIndexes(mainWindow.Dictionary, this.AutoCompleteList.SelectedItem.ToString());
            if (!mainWindow.Indexes.Active)
            {
                ModifyRemoveClearButtonsEnabled(false);
                return;
            }
            ModifyRemoveClearButtonsEnabled(true);
            //this.WordTextBox.Text = mainWindow.Dictionary[mainWindow.Indexes.CategoryIndex].Words[mainWindow.Indexes.WordIndex].WordText;
            this.DescriptionTextBox.Text = mainWindow.Dictionary[mainWindow.Indexes.CategoryIndex].Words[mainWindow.Indexes.WordIndex].Description;
            CategoryComboBox.SelectedIndex = mainWindow.Indexes.CategoryIndex;
            CategoryCheckBox.IsChecked = false;
            CategoryCheckBox_Click(null, null);

            //string path = "D:\\Programming\\Facultate\\MVP_Tema1_WPF\\Photos\\" + this.AutoCompleteList.SelectedItem.ToString() + ".png";
            //string path = Environment.CurrentDirectory + "\\..\\..\\..\\Photos\\" + this.AutoCompleteList.SelectedItem.ToString() + ".png";
            //var strings = Directory.GetFiles("..\\..\\..\\Photos\\", this.AutoCompleteList.SelectedItem.ToString() + ".*");
            //string path = Environment.CurrentDirectory + "\\" + strings[0];
            /*string path = GetPhotoPath(this.AutoCompleteList.SelectedItem.ToString());
            *//*Console.WriteLine(strings.Length);
            foreach (var x in strings)
            {
                Console.WriteLine(x);
            }*//*
            if (File.Exists(path))
            {
                WordImage.Source = new BitmapImage(new Uri(path));
            }*/
            WordImage.Source = Utils.getWordPhoto(this.WordTextBox.Text);
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
            if (WordImage.Source != null)
            {
                string imagePath = WordImage.Source.ToString().Replace("file:///", "");
                System.IO.File.Copy(imagePath, "..\\..\\..\\Photos\\" + WordTextBox.Text + System.IO.Path.GetExtension(imagePath), true);
            }
        }

        private void RemoveWord()
        {
            WordImage.Source = null;
            //File.Delete(GetPhotoPath(mainWindow.Dictionary[indexes.Item1].Words[indexes.Item2].WordText));
            mainWindow.Dictionary[mainWindow.Indexes.CategoryIndex].Words.RemoveAt(mainWindow.Indexes.WordIndex);
            if (mainWindow.Dictionary[mainWindow.Indexes.CategoryIndex].Words.Count == 0)
            {
                mainWindow.Dictionary.RemoveAt(mainWindow.Indexes.CategoryIndex);
                //this.CategoryComboBox.Items.RemoveAt(indexes.Item1);
                mainWindow.Category.RemoveAt(mainWindow.Indexes.CategoryIndex);
            }
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
            WordImage.Source = null;
            //mainWindow.Indexes = null;
            mainWindow.Indexes.set(-1, -1, false);
            ModifyRemoveClearButtonsEnabled(false);
        }
    }
}
