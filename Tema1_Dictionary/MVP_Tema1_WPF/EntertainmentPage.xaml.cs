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
            mainWindow = window;
            autoComplete = new AutoComplete(WordTextBox, AutoCompletePopup,
                AutoCompleteList, mainWindow.Dictionary, mainWindow.Indexes, AutoCompleteAction);
            game = new Game(mainWindow.Dictionary);
            ResultsListView.ItemsSource = game.ResultsList;
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Reset();
            mainWindow.Content = mainWindow.mainPage;
        }

        private void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            QuizButton.Content = "Next";
            if (mainWindow.Dictionary.Count == 0)
            {
                StartError.Text = "Dictionarul este gol";
                return;
            }
            game.Reset(String.IsNullOrEmpty(QuizSizeTextBox.Text) ? Utils.GetDictionarySize(mainWindow.Dictionary) : int.Parse(QuizSizeTextBox.Text));
            game.SetWord(DescriptionTextBlock, WordImage);
            if (game.Size == 1)
            {
                QuizButton.Content = "Finish";
            }
            StartGrid.Visibility = Visibility.Hidden;
            GameGrid.Visibility = Visibility.Visible;
        }

        private void QuizButton_Click(object sender, RoutedEventArgs e)
        {
            game.AddToResultsList(WordTextBox);
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
                ResultsTextBlock.Text = "Rezultatul dumneavoastra: " + game.GetOutOf();
                GameGrid.Visibility = Visibility.Hidden;
                ResultGrid.Visibility = Visibility.Visible;
                return;
            }
            game.SetWord(DescriptionTextBlock, WordImage);
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
            if (AutoCompleteCheckBox.IsChecked ?? false)
            {
                string aux = WordTextBox.Text;
                WordTextBox.Text = string.Empty;
                WordTextBox.Text = aux;
            }
        }

        private void WordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            QuizButton.IsEnabled = false;
            if (!(AutoCompleteCheckBox.IsChecked ?? false))
            {
                QuizButton.IsEnabled = !String.IsNullOrEmpty(WordTextBox.Text);
                return;
            }
            if (autoComplete == null) { return; }
            autoComplete.AutoTextBox_TextChanged(sender, e);
        }

        private void AutoCompleteList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (autoComplete == null) { return; }
            autoComplete.AutoList_SelectionChanged(sender, e);
        }

        private void AutoCompleteAction()
        {
            if (!mainWindow.Indexes.Active) { return; }
            QuizButton.IsEnabled = true;
        }

        private void Reset()
        {
            AutoCompleteCheckBox.IsChecked = false;
            WordTextBox.Text = String.Empty;
            game.Reset();
            QuizButton.Content = "Next";
            DescriptionTextBlock.Text = String.Empty;
            WordImage.Source = null;
            StartError.Text = String.Empty;
            StartGrid.Visibility = Visibility.Visible;
            GameGrid.Visibility = Visibility.Hidden;
            ResultGrid.Visibility = Visibility.Hidden;
        }
    }
}
