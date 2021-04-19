using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Win32;

using MVP_Tema2_Checkers.Models;

namespace MVP_Tema2_Checkers.Utils
{
    static class Serializer
    {
        public static void Serialize(Game game)
        {
            using (StreamWriter myWriter = new StreamWriter("..\\..\\..\\Saves\\game_" + GameInfo.Instance.Games + ".xml", false))
            {
                ++GameInfo.Instance.Games;
                XmlSerializer mySerializer = new XmlSerializer(typeof(Game));
                mySerializer.Serialize(myWriter, game);
            }
        }

        public static Game Desirialize()
        {
            String file = OpenFile();
            if (String.IsNullOrEmpty(file)) { return null; }
            using (var stream = System.IO.File.OpenRead(file))
            {
                var serializer = new XmlSerializer(typeof(Game));
                return serializer.Deserialize(stream) as Game;
            }
        }

        private static String OpenFile()
        {
            OpenFileDialog op = new OpenFileDialog();
            //op.InitialDirectory = "..\\..\\..\\Saves\\";
            op.Title = "Select save file";
            op.Filter = "XML Files (*.xml)|*.xml";
            if (op.ShowDialog() == true)
            {
                return op.FileName;
            }
            return null;
        }
    }
}
