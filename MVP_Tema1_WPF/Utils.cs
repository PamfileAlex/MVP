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
        private static string GetPhotoPath(string photoName)
        {
            var files = Directory.GetFiles("..\\..\\..\\Photos\\", photoName + ".*");
            if (files.Length == 0)
            {
                return null;
            }
            return Environment.CurrentDirectory + "\\" + files[0];
        }

        public static BitmapImage getWordPhoto(string photoName)
        {
            string path = Utils.GetPhotoPath(photoName);
            if (File.Exists(path))
            {
                return new BitmapImage(new Uri(path));
            }
            return null;
        }
    }
}
