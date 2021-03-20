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
        private ObservableCollection<Category> list;
        private Action action;

        public AutoComplete(TextBox textBox, Popup popup, ListBox listBox, ObservableCollection<Category> list, Action action = null)
        {
            this.textBox = textBox;
            this.popup = popup;
            this.listBox = listBox;
            this.list = list;
            this.action = action;
        }

        private void OpenAutoSuggestionBox()
        {
            this.popup.Visibility = Visibility.Visible;
            this.popup.IsOpen = true;
            this.listBox.Visibility = Visibility.Visible;
        }

        private void CloseAutoSuggestionBox()
        {
            this.popup.Visibility = Visibility.Collapsed;
            this.popup.IsOpen = false;
            this.listBox.Visibility = Visibility.Collapsed;
        }

        public void AutoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox.Text))
            {
                this.CloseAutoSuggestionBox();
                return;
            }
            this.OpenAutoSuggestionBox();
            //this.listBox.ItemsSource = this.list.Where(x => x.WordText.IndexOf(textBox.Text, StringComparison.CurrentCultureIgnoreCase) == 0).Select(x => x.WordText);
            List<string> listBoxWords = new List<string> ();
            foreach(var category in this.list)
            {
                listBoxWords.AddRange(category.Words.Where(x => x.WordText.IndexOf(textBox.Text, StringComparison.CurrentCultureIgnoreCase) == 0).Select(x => x.WordText));
            }
            this.listBox.ItemsSource = listBoxWords;
            if (this.listBox.Items.Count == 0)
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
            if (action != null)
            {
                action();
            }
            this.listBox.SelectedIndex = -1;
        }
    }
}
