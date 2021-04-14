using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVP_Tema2_Checkers.Models;

namespace MVP_Tema2_Checkers.Utils
{
    class GameLogic
    {
        private ObservableCollection<ObservableCollection<Cell>> gameBoard;

        public GameLogic(ObservableCollection<ObservableCollection<Cell>> gameBoard)
        {
            this.gameBoard = gameBoard;
        }
    }
}
