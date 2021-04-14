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
        private Cell previousCell;

        public GameLogic(ObservableCollection<ObservableCollection<Cell>> gameBoard)
        {
            this.gameBoard = gameBoard;
        }

        private bool CanExecute(Cell cell)
        {
            return cell != null;
        }

        public void MovePiece(Cell cell)
        {
            if (previousCell == cell || previousCell == null && cell.PieceSet == null)
            {
                return;
            }
            if (previousCell == null || (cell.PieceSet != null ? (previousCell.PieceSet.Color == cell.PieceSet.Color) : false))
            {
                previousCell = cell;
                return;
            }
            if (!CheckMove(cell))
            {
                return;
            }
            cell.PieceSet = previousCell.PieceSet;
            previousCell.PieceSet = null;
            previousCell = null;
        }

        private bool CheckMove(Cell cell)
        {
            if (cell.PieceSet != null)
            {
                return false;
            }
            int color = previousCell.PieceSet.Color ? -1 : 1;
            if (previousCell.Row + color != cell.Row)
            {
                return false;
            }
            if (previousCell.Column - 1 == cell.Column || previousCell.Column + 1 == cell.Column)
            {
                return true;
            }
            return false;
        }
    }
}
