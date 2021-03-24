using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MVP_Tema1_WPF
{
    public partial class AdminPage : Page
    {
        private bool Check()
        {
            return CheckDictionary() && CheckAllNotEmpty() &&
                !CheckWordExistence() && !CheckCategoryExistence();
        }

        private bool CheckDictionary()
        {
            if (this.mainWindow.Dictionary == null)
            {
                this.ErrorText.Text = "Dictionarul este null";
                return false;
            }
            return true;
        }

        private bool CheckAllNotEmpty()
        {
            if (!String.IsNullOrEmpty(this.WordTextBox.Text) && !String.IsNullOrEmpty(this.DescriptionTextBox.Text) &&
                ((this.CategoryCheckBox.IsChecked ?? false) ? !String.IsNullOrEmpty(this.CategoryTextBox.Text) :
                this.CategoryComboBox.SelectedIndex != -1))
            {
                return true;
            }
            this.ErrorText.Text = "Nu sunt completate toate campurile";
            return false;
        }

        private bool CheckWordExistence()
        {
            foreach (var category in this.mainWindow.Dictionary)
            {
                if (category.Words.Exists(word => word.WordText.Equals(this.WordTextBox.Text)))
                {
                    this.ErrorText.Text = "Exista deja acest cuvant in dictionar";
                    return true;
                }
            }
            return false;
        }

        private bool CheckCategoryExistence()
        {
            if (String.IsNullOrEmpty(this.CategoryTextBox.Text))
            {
                return false;
            }
            if (this.mainWindow.Dictionary.Exists(category => category.Title.Equals(this.CategoryTextBox.Text)))
            {
                this.ErrorText.Text = "Exista deja aceasta categorie in dictionar";
                return true;
            }
            return false;
        }
    }
}
