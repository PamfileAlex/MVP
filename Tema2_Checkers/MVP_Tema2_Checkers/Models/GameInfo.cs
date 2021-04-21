using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVP_Tema2_Checkers.ViewModels;

namespace MVP_Tema2_Checkers.Models
{
    sealed class GameInfo : BaseNotification
    {
        private int whiteWins;
        private int blackWins;
        public int WhiteWins
        {
            get { return whiteWins; }
            private set
            {
                whiteWins = value;
                NotifyPropertyChanged("WhiteWins");
            }
        }
        public int BlackWins
        {
            get { return blackWins; }
            private set
            {
                blackWins = value;
                NotifyPropertyChanged("BlackWins");
            }
        }
        public static GameInfo Instance { get; } = new GameInfo();

        static GameInfo() { }
        private GameInfo()
        {
            try
            {
                using (TextReader reader = File.OpenText("../../../gameInfo.txt"))
                {
                    string line = reader.ReadLine();
                    string[] separated = line.Split(' ');
                    this.WhiteWins = int.Parse(separated[0]);
                    this.BlackWins = int.Parse(separated[1]);
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("Error reading GameInfo from file");
                Console.WriteLine(exc.Message);
                this.WhiteWins = 0;
                this.BlackWins = 0;
            }
        }

        ~GameInfo()
        {
            try
            {
                File.WriteAllText("../../../gameInfo.txt", WhiteWins + " " + BlackWins);
            }
            catch (Exception exc)
            {
                Console.WriteLine("Error writing GameInfo to file");
                Console.WriteLine(exc.Message);
            }
        }

        public void AddWin(bool color)
        {
            _ = color ? ++WhiteWins : ++BlackWins;
        }
    }
}
