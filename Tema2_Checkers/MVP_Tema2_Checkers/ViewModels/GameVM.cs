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
        private GameLogic gameLogic;
        public String Test { get; set; }
        public ObservableCollection<ObservableCollection<CellVM>> GameBoard { get; set; }

        public GameVM()
        {
            Game game = new Game(BoardGenerator.NewGame());
            gameLogic = new GameLogic(game);
            GameBoard = CellBoardToCellVMBoard(game.GameBoard);
        }

        private ObservableCollection<ObservableCollection<CellVM>> CellBoardToCellVMBoard(ObservableCollection<ObservableCollection<Cell>> gameBoard)
        {
            return gameBoard.Select(row => row.Select(cell => new CellVM(cell, gameLogic)).ToObservableCollection()).ToObservableCollection();
        }
    }
}
