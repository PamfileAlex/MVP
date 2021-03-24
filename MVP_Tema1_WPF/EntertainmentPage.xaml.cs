using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private Game game;

        public EntertainmentPage(MainWindow window)
        {
            InitializeComponent();
            this.mainWindow = window;
            autoComplete = new AutoComplete(this.WordTextBox, this.AutoCompletePopup,
                this.AutoCompleteList, mainWindow.Dictionary, mainWindow.Indexes, AutoCompleteAction);
            game = new Game(mainWindow.Dictionary);
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.AutoCompleteCheckBox.IsChecked = false;
            this.WordTextBox.Text = String.Empty;
            game.Reset();
            this.QuizButton.Content = "Next";
            this.DescriptionTextBlock.Text = String.Empty;
            this.WordImage.Source = null;
            this.StartError.Text = String.Empty;
            this.StartGrid.Visibility = Visibility.Visible;
            this.GameGrid.Visibility = Visibility.Hidden;
            this.ResultGrid.Visibility = Visibility.Hidden;
            mainWindow.Content = mainWindow.mainPage;
        }

        private void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainWindow.Dictionary.Count == 0)
            {
                StartError.Text = "Dictionarul este gol";
                return;
            }
            game.Reset(String.IsNullOrEmpty(QuizSizeTextBox.Text) ? Utils.GetDictionarySize(mainWindow.Dictionary) : int.Parse(QuizSizeTextBox.Text));
            game.NextWord(DescriptionTextBlock, WordImage);
            if (game.Size == 1)
            {
                QuizButton.Content = "Finish";
            }
            StartGrid.Visibility = Visibility.Hidden;
            GameGrid.Visibility = Visibility.Visible;
        }

        private void QuizButton_Click(object sender, RoutedEventArgs e)
        {
            DescriptionTextBlock.Text = String.Empty;
            WordImage.Source = null;
            WordTextBox.Text = String.Empty;
            ++game.Index;
            if (game.Index == game.Size - 1)
            {
                QuizButton.Content = "Finish";
            }
            else if (game.Index >= game.Size)
            {
                GameGrid.Visibility = Visibility.Hidden;
                ResultGrid.Visibility = Visibility.Visible;
                //ResultsListView.Items.Add("Acesta este un test");
                //ResultsListView.Items.Add("Acesta este alt test");
                return;
            }
            game.NextWord(this.DescriptionTextBlock, this.WordImage);
        }

        private void QuizSizeTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void RestartGameButton_Click(object sender, RoutedEventArgs e)
        {
            ResultGrid.Visibility = Visibility.Hidden;
            StartGrid.Visibility = Visibility.Visible;
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
