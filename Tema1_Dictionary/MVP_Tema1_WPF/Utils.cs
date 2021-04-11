using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MVP_Tema1_WPF
{
    public class Utils
    {
        public static string GetPhotoPath(string photoName)
        {
            var files = Directory.GetFiles("..\\..\\..\\Photos\\", photoName + ".*");
            if (files.Length == 0) { return null; }
            return Environment.CurrentDirectory + "\\" + files[0];
        }

        public static BitmapImage GetWordPhoto(string photoName)
        {
            string path = Utils.GetPhotoPath(photoName);
            if (File.Exists(path))
            {
                var bi = new BitmapImage();
                using (var fs = new FileStream(path, FileMode.Open))
                {
                    bi.BeginInit();
                    bi.StreamSource = fs;
                    bi.CacheOption = BitmapCacheOption.OnLoad;
                    bi.EndInit();
                }
                bi.Freeze();
                return bi;
            }
            return null;
        }

        public static void SetWordIndexes(IndexPair indexPair, List<Category> dictionary, string selectedWord)
        {
            if (dictionary == null)
            {
                indexPair.set(-1, -1, false);
                return;
            }
            for (int index = 0; index < dictionary.Count; ++index)
            {
                int wordIndex = dictionary[index].Words.FindIndex(word => word.WordText.Equals(selectedWord));
                if (wordIndex != -1)
                {
                    indexPair.set(index, wordIndex);
                    return;
                }
            }
            indexPair.set(-1, -1, false);
        }

        public static int GetDictionarySize(List<Category> dictionary)
        {
            int size = 0;
            if (dictionary == null) { return size; }
            foreach (var category in dictionary)
            {
                size += category.Words.Count;
            }
            return size;
        }
    }
}
