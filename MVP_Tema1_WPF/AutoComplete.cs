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
        private Popup popup;
        private ListBox listBox;
        private List<Category> list;
        private IndexPair indexes;
        private Action action;

        public AutoComplete(TextBox textBox, Popup popup, ListBox listBox, List<Category> list, IndexPair indexes, Action action = null)
        {
            this.textBox = textBox;
            this.popup = popup;
            this.listBox = listBox;
            this.list = list;
            this.indexes = indexes;
            this.action = action;
        }

        public void OpenAutoSuggestionBox()
        {
            this.popup.Visibility = Visibility.Visible;
            this.popup.IsOpen = true;
            this.listBox.Visibility = Visibility.Visible;
        }

        public void CloseAutoSuggestionBox()
        {
            this.popup.Visibility = Visibility.Collapsed;
            this.popup.IsOpen = false;
            this.listBox.Visibility = Visibility.Collapsed;
        }

        public void AutoTextBox_TextChanged(object sender, TextChangedEventArgs e, ComboBox CategoryComboBox = null)
        {
            if (string.IsNullOrEmpty(this.textBox.Text))
            {
                this.CloseAutoSuggestionBox();
                return;
            }
            this.OpenAutoSuggestionBox();
            //this.listBox.ItemsSource = this.list.Where(x => x.WordText.IndexOf(textBox.Text, StringComparison.CurrentCultureIgnoreCase) == 0).Select(x => x.WordText);
            if (CategoryComboBox != null && CategoryComboBox.SelectedIndex != -1)
            {
                this.listBox.ItemsSource = this.list[CategoryComboBox.SelectedIndex].Words.Where(x => x.WordText.IndexOf(textBox.Text, StringComparison.CurrentCultureIgnoreCase) == 0).Select(x => x.WordText);
            }
            else
            {
                List<string> listBoxWords = new List<string>();
                foreach (var category in this.list)
                {
                    listBoxWords.AddRange(category.Words.Where(x => x.WordText.IndexOf(textBox.Text, StringComparison.CurrentCultureIgnoreCase) == 0).Select(x => x.WordText));
                }
                listBoxWords.Sort();
                this.listBox.ItemsSource = listBoxWords;
            }
            if(this.listBox.Items.Count == 1 && this.textBox.Text.Equals(this.listBox.Items[0]))
            {
                this.listBox.SelectedIndex = 0;
            }
            else if (this.listBox.Items.Count == 0)
            {
                this.CloseAutoSuggestionBox();
            }
        }

        public void AutoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.listBox.SelectedIndex <= -1)
            {
                this.CloseAutoSuggestionBox();
                return;
            }
            this.CloseAutoSuggestionBox();
            this.textBox.Text = this.listBox.SelectedItem.ToString();
            Utils.setWordIndexes(indexes, this.list, this.listBox.SelectedItem.ToString());
            this.listBox.SelectedIndex = -1;
            if (action != null)
            {
                action();
            }
        }
    }
}
