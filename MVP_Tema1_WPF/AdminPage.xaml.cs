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
            /*AddButton.Visibility = Visibility.Hidden;
            ModifyButton.Visibility = Visibility.Hidden;
            DeleteButton.Visibility = Visibility.Hidden;*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);
            switch (index)
            {
                case 0:
                    mainWindow.Content = mainWindow.mainPage;
                    break;
                case 1:
                    if (Check())
                    {
                        mainWindow.Dictionary.Add(new Word(WordTextBox.Text, DescriptionTextBox.Text));
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

        private void CategoryCheckBox_Click(object sender, RoutedEventArgs e)
        {
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

        private void UploadPhotoButton_Click(object sender, RoutedEventArgs e)
        {
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
            ImgPhoto.Source = null;
            ClearPhotoButton.IsEnabled = false;
        }

        private void WordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
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
            this.WordTextBox.Text = this.AutoCompleteList.SelectedItem.ToString();
            int index = mainWindow.Dictionary.FindIndex(word => word.WordText.Equals(this.AutoCompleteList.SelectedItem.ToString()));
            this.DescriptionTextBox.Text = mainWindow.Dictionary[index].Description;
        }

        private bool Check()
        {
            return !String.IsNullOrEmpty(WordTextBox.Text) && !String.IsNullOrEmpty(DescriptionTextBox.Text) &&
                (CategoryCheckBox.IsChecked ?? false) ? String.IsNullOrEmpty(CategoryTextBox.Text) ||
                !mainWindow.Dictionary.Exists(x => x.WordText.Equals(WordTextBox.Text)) : CategoryComboBox.SelectedIndex != -1;
        }

        private void Reset()
        {
            WordTextBox.Text = "";
            DescriptionTextBox.Text = "";
            CategoryTextBox.Text = "";
            CategoryComboBox.SelectedIndex = -1;
            ImgPhoto.Source = null;
        }
    }
}
