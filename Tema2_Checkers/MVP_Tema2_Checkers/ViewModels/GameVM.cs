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
        public Game GameInfo { get; set; }
        public ObservableCollection<ObservableCollection<CellVM>> GameBoard { get; set; }
        public bool IsRunning => gameLogic.IsRunning;
        public bool MultipleJump
        {
            get
            {
                return gameLogic.MultipleJump;
            }
            set
            {
                gameLogic.MultipleJump = value;
            }
        }

        public GameVM()
        {
            this.GameInfo = new Game(BoardGenerator.NewGame());
            this.gameLogic = new GameLogic(GameInfo);
            this.GameBoard = CellBoardToCellVMBoard(GameInfo.GameBoard);
        }

        private ObservableCollection<ObservableCollection<CellVM>> CellBoardToCellVMBoard(ObservableCollection<ObservableCollection<Cell>> gameBoard)
        {
            return gameBoard.Select(row => row.Select(cell => new CellVM(cell, gameLogic)).ToObservableCollection()).ToObservableCollection();
        }
    }
}
