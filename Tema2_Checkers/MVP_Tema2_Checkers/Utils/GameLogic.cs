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
        private Game game;
        private Cell previousCell;

        public GameLogic(Game game)
        {
            this.game = game;
        }

        private bool CanExecute(Cell cell)
        {
            return cell != null;
        }

        public void MovePiece(Cell cell)
        {
            if (previousCell == cell || (cell.PieceSet == null ? previousCell == null : cell.PieceSet.Color != game.Color))
            {
                return;
            }
            if (previousCell == null)
            {
                if (previousCell != null)
                {
                    previousCell.Selected = false;
                }
                previousCell = cell;
                previousCell.Selected = true;
                return;
            }
            if (!CheckMove(cell))
            {
                return;
            }
            cell.PieceSet = previousCell.PieceSet;
            previousCell.PieceSet = null;
            previousCell.Selected = false;
            previousCell = null;
            game.Color = !game.Color;
        }

        private bool CheckMove(Cell cell)
        {
            int cellDistance = CheckCellPosition(cell);
            if (cell.PieceSet != null || cellDistance == 0)
            {
                return false;
            }
            if (previousCell.PieceSet.King ? false : (previousCell.PieceSet.Color ? previousCell.Row < cell.Row : previousCell.Row > cell.Row))
            {
                return false;
            }
            if (cellDistance == 2)
            {
                Cell cellInBetween = game.GameBoard[(previousCell.Row + cell.Row) / 2][(previousCell.Column + cell.Column) / 2];
                if (cellInBetween.PieceSet == null || previousCell.PieceSet.Color == cellInBetween.PieceSet.Color)
                {
                    return false;
                }
                game.RemovePiece(cellInBetween);
            }
            return true;
        }

        private int CheckCellPosition(Cell cell)
        {
            int row = Math.Abs(previousCell.Row - cell.Row);
            int column = Math.Abs(previousCell.Column - cell.Column);
            return (row == column) && (row == 1 || row == 2) ? row : 0;
        }
    }
}