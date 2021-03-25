using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace MVP_Tema1_WPF
{
    class AutoComplete
    {
        private TextBox textBox;
        private Popup popUp;
        private ListBox listBox;
        private List<Category> dictionary;
        private IndexPair indexes;
        private Action action;

        public AutoComplete(TextBox textBox, Popup popUp, ListBox listBox, List<Category> dictionary, IndexPair indexes, Action action = null)
        {
            this.textBox = textBox;
            this.popUp = popUp;
            this.listBox = listBox;
            this.dictionary = dictionary;
            this.indexes = indexes;
            this.action = action;
        }

        public void OpenAutoSuggestionBox()
        {
            popUp.Visibility = Visibility.Visible;
            popUp.IsOpen = true;
            listBox.Visibility = Visibility.Visible;
        }

        public void CloseAutoSuggestionBox()
        {
            popUp.Visibility = Visibility.Collapsed;
            popUp.IsOpen = false;
            listBox.Visibility = Visibility.Collapsed;
        }

        public void AutoTextBox_TextChanged(object sender, TextChangedEventArgs e, ComboBox CategoryComboBox = null)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                CloseAutoSuggestionBox();
                return;
            }
            OpenAutoSuggestionBox();
            //listBox.ItemsSource = list.Where(x => x.WordText.IndexOf(textBox.Text, StringComparison.CurrentCultureIgnoreCase) == 0).Select(x => x.WordText);
            if (CategoryComboBox != null && CategoryComboBox.SelectedIndex != -1)
            {
                listBox.ItemsSource = dictionary[CategoryComboBox.SelectedIndex].Words.Where(x => x.WordText.IndexOf(textBox.Text, StringComparison.CurrentCultureIgnoreCase) == 0).Select(x => x.WordText);
            }
            else
            {
                List<string> listBoxWords = new List<string>();
                foreach (var category in dictionary)
                {
                    listBoxWords.AddRange(category.Words.Where(x => x.WordText.IndexOf(textBox.Text, StringComparison.CurrentCultureIgnoreCase) == 0).Select(x => x.WordText));
                }
                listBoxWords.Sort();
                listBox.ItemsSource = listBoxWords;
            }
            if(listBox.Items.Count == 1 && textBox.Text.Equals(listBox.Items[0]))
            {
                listBox.SelectedIndex = 0;
            }
            else if (listBox.Items.Count == 0)
            {
                CloseAutoSuggestionBox();
            }
        }

        public void AutoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox.SelectedIndex <= -1)
            {
                CloseAutoSuggestionBox();
                return;
            }
            CloseAutoSuggestionBox();
            textBox.Text = listBox.SelectedItem.ToString();
            Utils.SetWordIndexes(indexes, dictionary, listBox.SelectedItem.ToString());
            listBox.SelectedIndex = -1;
            if (action != null)
            {
                action();
            }
        }
    }
}
