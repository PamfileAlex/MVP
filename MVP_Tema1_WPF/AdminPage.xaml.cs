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
        private List<Word> dictionary;

        public AdminPage(MainWindow window)
        {
            InitializeComponent();
            this.mainWindow = window;
            List<string> list = new List<string> { "cuvant", "test", "ananas", "alfabet", "alfa" };
            //autoComplete = new AutoComplete(this.WordTextBox, this.AutoCompletePopup, this.AutoCompleteList, list);
            dictionary = new List<Word>();
            autoComplete = new AutoComplete(this.WordTextBox, this.AutoCompletePopup, this.AutoCompleteList, dictionary);
            //WordTextBox.TextChanged += TBTextChanged;
            //WordTextBox.PreviewKeyDown += DelPressed;

            /*AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            source.Add("some string");
            WordTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            WordTextBox.AutoCompleteCustomSource = source;*/
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
                        dictionary.Add(new Word(WordTextBox.Text, DescriptionTextBox.Text));
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
            //textBlock.Text = CategoryCheckBox.IsChecked.ToString();
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
                //System.IO.File.Copy(op.FileName, "..\\Photos\\" + WordTextBox.Text);
                //Console.WriteLine(".\\" + WordTextBox.Text + System.IO.Path.GetExtension(op.FileName));
                //System.IO.File.Copy(op.FileName, "..\\..\\..\\Photos\\" + WordTextBox.Text + System.IO.Path.GetExtension(op.FileName), true);
            }
        }

        /*private void WordTextBox_TextChanged(object sender, TextChangedEventArgs e)
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
        }*/



        private void OpenAutoSuggestionBox()
        {
            this.AutoCompletePopup.Visibility = Visibility.Visible;
            this.AutoCompletePopup.IsOpen = true;
            this.AutoCompleteList.Visibility = Visibility.Visible;
        }

        private void CloseAutoSuggestionBox()
        {
            this.AutoCompletePopup.Visibility = Visibility.Collapsed;
            this.AutoCompletePopup.IsOpen = false;
            this.AutoCompleteList.Visibility = Visibility.Collapsed;
        }

        public void WordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.WordTextBox.Text))
            {
                this.CloseAutoSuggestionBox();
                return;
            }
            this.OpenAutoSuggestionBox();
            this.AutoCompleteList.ItemsSource = this.dictionary.Where(x => x.WordText.IndexOf(WordTextBox.Text, StringComparison.CurrentCultureIgnoreCase) == 0).Select(x => x.WordText);
            if (this.AutoCompleteList.Items.Count == 0)
            {
                this.CloseAutoSuggestionBox();
            }
        }

        public void AutoCompleteList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.AutoCompleteList.SelectedIndex <= -1)
            {
                this.CloseAutoSuggestionBox();
                return;
            }
            this.CloseAutoSuggestionBox();
            this.WordTextBox.Text = this.AutoCompleteList.SelectedItem.ToString();
            //int index = DictionaryIndexOf(this.AutoCompleteList.SelectedItem.ToString());
            int index = dictionary.FindIndex(word => word.WordText.Equals(this.AutoCompleteList.SelectedItem.ToString()));
            this.DescriptionTextBox.Text = dictionary[index].Description;
            this.AutoCompleteList.SelectedIndex = -1;
        }

        private int DictionaryIndexOf(string searchedWord)
        {
            dictionary.FindIndex(word => word.WordText.Equals(searchedWord));

            foreach (var (item, index) in dictionary.Select((value, i) => (value, i)))
            {
                if (searchedWord.Equals(item))
                {
                    return index;
                }
            }
            return -1;
        }




        private bool Check()
        {
            return !String.IsNullOrEmpty(WordTextBox.Text) && !String.IsNullOrEmpty(DescriptionTextBox.Text) &&
                (CategoryCheckBox.IsChecked ?? false) ? String.IsNullOrEmpty(CategoryTextBox.Text) ||
                !dictionary.Exists(x => x.WordText.Equals(WordTextBox.Text)) : CategoryComboBox.SelectedIndex != -1;
            /*Console.WriteLine(String.IsNullOrEmpty(WordTextBox.Text));
            Console.WriteLine(String.IsNullOrEmpty(DescriptionTextBox.Text));
            Console.WriteLine(String.IsNullOrEmpty(CategoryTextBox.Text) ||
                dictionary.Exists(x => x.WordText.Equals(WordTextBox.Text)));
            Console.WriteLine();
            return false;*/
        }

        private void Reset()
        {
            WordTextBox.Text = "";
            DescriptionTextBox.Text = "";
            CategoryTextBox.Text = "";
            CategoryComboBox.SelectedIndex = -1;
            ImgPhoto.Source = null;
        }







        private List<string> test = new List<string> { "Test", "banana", "girafa", "ananas", "babilon" };
        private bool InProg;
        internal void TBTextChanged(object sender, TextChangedEventArgs e)
        {
            var change = e.Changes.FirstOrDefault();
            if (!InProg)
            {
                InProg = true;
                var culture = new CultureInfo(CultureInfo.CurrentCulture.Name);
                var source = ((TextBox)sender);
                if (((change.AddedLength - change.RemovedLength) > 0 || source.Text.Length > 0) && !DelKeyPressed)
                {
                    if (test.Where(x => x.IndexOf(source.Text, StringComparison.CurrentCultureIgnoreCase) == 0).Count() > 0)
                    {
                        var _appendtxt = test.FirstOrDefault(ap => (culture.CompareInfo.IndexOf(ap, source.Text, CompareOptions.IgnoreCase) == 0));
                        _appendtxt = _appendtxt.Remove(0, change.Offset + 1);
                        source.Text += _appendtxt;
                        source.SelectionStart = change.Offset + 1;
                        source.SelectionLength = source.Text.Length;
                    }
                }
                InProg = false;
            }
        }
        private static bool DelKeyPressed;
        internal static void DelPressed(object sender, KeyEventArgs e)
        { if (e.Key == Key.Back) { DelKeyPressed = true; } else { DelKeyPressed = false; } }

    }
}
