using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using MVP_Tema2_Checkers.Utils;
using MVP_Tema2_Checkers.Models;
using MVP_Tema2_Checkers.Commands;

namespace MVP_Tema2_Checkers.ViewModels
{
    class CellVM
    {
        private GameLogic gameLogic;

        public Cell CellObj { get; }

        public CellVM(Cell cell, GameLogic gameLogic)
        {
            this.CellObj = cell;
            this.gameLogic = gameLogic;
        }

        private ICommand moveCommand;
        public ICommand MoveCommand
        {
            get
            {
                if (moveCommand == null)
                {
                    moveCommand = new RelayCommand<Cell>(gameLogic.Move);
                }
                return moveCommand;
            }
        }
    }
}
