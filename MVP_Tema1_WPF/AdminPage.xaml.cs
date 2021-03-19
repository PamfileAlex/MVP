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

namespace MVP_Tema1_WPF
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        private MainWindow mainWindow;
        public AdminPage(MainWindow window)
        {
            InitializeComponent();
            this.mainWindow = window;
            //WordTextBox.TextChanged += TBTextChanged;
            //WordTextBox.PreviewKeyDown += DelPressed;
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
                    //mainWindow.Content = mainWindow.mainPage;
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









        private List<string> test = new List<string> { "Test", "banana", "girafa","ananas","babilon" };
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
