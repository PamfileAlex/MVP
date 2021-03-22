using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Xml.Serialization;

namespace MVP_Tema1_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainPage mainPage;
        public AdminPage adminPage;
        public SearchPage searchPage;

        public List<Category> Dictionary { get; set; }
        public ObservableCollection<string> Category { get; set; }
        public IndexPair Indexes { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            Dictionary = new List<Category>();
            Category = new ObservableCollection<string>();
            Indexes = new IndexPair();
            Deserialize();
            ReinitializeCategoryComboBoxItems();
            PageInit();
            this.Content = mainPage;
        }

        ~MainWindow()
        {
            Serialize();
        }

        private void PageInit()
        {
            mainPage = new MainPage(this);
            adminPage = new AdminPage(this);
            searchPage = new SearchPage(this);
        }

        private void Serialize()
        {
            using (StreamWriter myWriter = new StreamWriter("..\\..\\..\\dictionary.xml", false))
            {
                XmlSerializer mySerializer = new XmlSerializer(typeof(List<Category>));
                mySerializer.Serialize(myWriter, Dictionary);
            }
        }

        private void Deserialize()
        {
            using (var stream = System.IO.File.OpenRead("..\\..\\..\\dictionary.xml"))
            {
                var serializer = new XmlSerializer(typeof(List<Category>));
                Dictionary = serializer.Deserialize(stream) as List<Category>;
            }
        }

        private void ReinitializeCategoryComboBoxItems()
        {
            foreach (var category in Dictionary)
            {
                Category.Add(category.Title);
            }
        }
    }
}
