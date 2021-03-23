using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Tema1_WPF
{
    public class Checks
    {
        public static bool Check(AdminPage adminPage)
        {
            return CheckDictionary(adminPage) && CheckAllNotEmpty(adminPage) &&
                !CheckWordExistence(adminPage) && !CheckCategoryExistence(adminPage);
        }

        private static bool CheckDictionary(AdminPage adminPage)
        {
            if (adminPage.mainWindow.Dictionary == null)
            {
                adminPage.ErrorText.Text = "Dictionarul este null";
                return false;
            }
            return true;
        }

        private static bool CheckAllNotEmpty(AdminPage adminPage)
        {
            if (!String.IsNullOrEmpty(adminPage.WordTextBox.Text) && !String.IsNullOrEmpty(adminPage.DescriptionTextBox.Text) &&
                (adminPage.CategoryCheckBox.IsChecked ?? false) ? !String.IsNullOrEmpty(adminPage.CategoryTextBox.Text) :
                adminPage.CategoryComboBox.SelectedIndex != -1)
            {
                return true;
            }
            adminPage.ErrorText.Text = "Nu sunt completate toate campurile";
            return false;
        }

        private static bool CheckWordExistence(AdminPage adminPage)
        {
            foreach (var category in adminPage.mainWindow.Dictionary)
            {
                if (category.Words.Exists(word => word.WordText.Equals(adminPage.WordTextBox.Text)))
                {
                    adminPage.ErrorText.Text = "Exista deja acest cuvant in dictionar";
                    return true;
                }
            }
            return false;
        }

        private static bool CheckCategoryExistence(AdminPage adminPage)
        {
            if (adminPage.CategoryTextBox.Text.Equals(""))
            {
                return false;
            }
            if (adminPage.mainWindow.Dictionary.Exists(category => category.Title.Equals(adminPage.CategoryTextBox.Text)))
            {
                adminPage.ErrorText.Text = "Exista deja aceasta categorie in dictionar";
                return true;
            }
            return false;
        }
    }
}
