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
            autoComplete = new AutoComplete(this.WordTextBox, this.AutoCompletePopup, this.AutoCompleteList, mainWindow.Dictionary, AutoCompleteAction);
            //this.CategoryComboBox.ItemsSource = mainWindow.Dictionary;//.Select(category => category.Title);
            /*AddButton.Visibility = Visibility.Hidden;
            ModifyButton.Visibility = Visibility.Hidden;
            DeleteButton.Visibility = Visibility.Hidden;*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CommonEventAction();
            int index = int.Parse(((Button)e.Source).Uid);
            switch (index)
            {
                case 0:
                    mainWindow.Content = mainWindow.mainPage;
                    break;
                case 1:
                    if (Check())
                    {
                        //mainWindow.Dictionary.Add(new Word(WordTextBox.Text, DescriptionTextBox.Text));
                        if (ImgPhoto.Source != null)
                        {
                            string imagePath = ImgPhoto.Source.ToString().Replace("file:///", "");
                            System.IO.File.Copy(imagePath, "..\\..\\..\\Photos\\" + WordTextBox.Text + System.IO.Path.GetExtension(imagePath), true);
                        }
                        Reset();
                    }
                    else
                    {
                        Console.WriteLine("ERROR");
                        ErrorText.Text = "ERROR";
                    }
                    break;
                case 2:

                    break;
                default:
                    break;
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
            if (Check())
            {
                //mainWindow.Dictionary.Add(new Word(WordTextBox.Text, DescriptionTextBox.Text));
                if (CategoryComboBox.SelectedIndex != -1)
                {
                    mainWindow.Dictionary[CategoryComboBox.SelectedIndex].Words.Add(new Word(WordTextBox.Text, DescriptionTextBox.Text));
                }
                else
                {
                    mainWindow.Dictionary.Add(new Category(CategoryTextBox.Text));
                    mainWindow.Dictionary[mainWindow.Dictionary.Count-1].Words.Add(new Word(WordTextBox.Text, DescriptionTextBox.Text));
                    CategoryComboBox.Items.Add(CategoryTextBox.Text);
                }
                if (ImgPhoto.Source != null)
                {
                    string imagePath = ImgPhoto.Source.ToString().Replace("file:///", "");
                    System.IO.File.Copy(imagePath, "..\\..\\..\\Photos\\" + WordTextBox.Text + System.IO.Path.GetExtension(imagePath), true);
                }
                Reset();
            }
            else
            {
                Console.WriteLine("ERROR");
                ErrorText.Text = "ERROR";
            }
        }

        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            CommonEventAction();
            if (Check())
            {

                Reset();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            CommonEventAction();

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
            var indexes = GetWordIndexes();
            if (indexes == null)
            {
                return;
            }
            this.DescriptionTextBox.Text = mainWindow.Dictionary[indexes.Item1].Words[indexes.Item2].Description;
            CategoryComboBox.SelectedIndex = indexes.Item1;
            CategoryCheckBox.IsChecked = false;
            CategoryCheckBox_Click(null, null);
        }

        private Tuple<int,int> GetWordIndexes()
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

        private bool Check()
        {
            /*return !String.IsNullOrEmpty(WordTextBox.Text) && !String.IsNullOrEmpty(DescriptionTextBox.Text) &&
                (CategoryCheckBox.IsChecked ?? false) ? String.IsNullOrEmpty(CategoryTextBox.Text) ||
                !mainWindow.Dictionary.Exists(x => x.WordText.Equals(WordTextBox.Text)) : CategoryComboBox.SelectedIndex != -1;*/
            return true;
        }

        private void Reset()
        {
            WordTextBox.Text = "";
            DescriptionTextBox.Text = "";
            CategoryTextBox.Text = "";
            CategoryComboBox.SelectedIndex = -1;
            ImgPhoto.Source = null;
            ClearButton.IsEnabled = false;
        }
    }
}
