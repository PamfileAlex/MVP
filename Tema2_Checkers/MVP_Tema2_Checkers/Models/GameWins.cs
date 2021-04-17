using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVP_Tema2_Checkers.ViewModels;

namespace MVP_Tema2_Checkers.Models
{
    sealed class GameWins : BaseNotification
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
        public static GameWins Instance { get; } = new GameWins();

        private GameWins()
        {
            this.WhiteWins = 0;
            this.BlackWins = 0;
            //Serialize
        }

        ~GameWins()
        {
            //Desirialize
        }

        public void AddWin(bool color)
        {
            if (color)
            {
                ++WhiteWins;
            }
            else
            {
                ++BlackWins;
            }
        }
    }
}
