using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVP_Tema2_Checkers.Models;
using MVP_Tema2_Checkers.Utils;

namespace MVP_Tema2_Checkers.ViewModels
{
    class GameVM
    {

        public String Test { get; set; }
        public ObservableCollection<ObservableCollection<Cell>> GameBoard { get; set; }
        public GameVM()
        {
            GameBoard = BoardGenerator.NewGame();
        }
    }
}
