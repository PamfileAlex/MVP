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
        private bool pieceTaken;
        public bool MultipleJump { get; set; }
        public bool IsRunning { get; set; }

        public GameLogic(Game game)
        {
            this.game = game;
            this.pieceTaken = false;
            this.MultipleJump = false;
            this.IsRunning = false;
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
            if (previousCell == null || cell.PieceSet != null)
            {
                if (previousCell != null)
                {
                    previousCell.Selected = false;
                }
                IsRunning = true;
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
            CheckAndTransformToKing(cell);
            game.CheckWin();
            if (MultipleJump && pieceTaken && CheckMultipleJump(cell))
            {
                previousCell = cell;
                previousCell.Selected = true;
                return;
            }
            game.Color = !game.Color;
        }

        private void CheckAndTransformToKing(Cell cell)
        {
            if (cell.PieceSet.King)
            {
                return;
            }
            cell.PieceSet.King = cell.PieceSet.Color ? cell.Row == 0 : cell.Row == BoardGenerator.SIZE - 1;
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
                pieceTaken = true;
            }
            return true;
        }

        private int CheckCellPosition(Cell cell)
        {
            int row = Math.Abs(previousCell.Row - cell.Row);
            int column = Math.Abs(previousCell.Column - cell.Column);
            return (row == column) && (row == 1 || row == 2) ? row : 0;
        }

        private bool CheckMultipleJumpEasier(Cell cell)
        {
            if (cell.PieceSet.King)
            {
                return CheckJump(cell, cell.Row - 2, cell.Column - 2)
                || CheckJump(cell, cell.Row - 2, cell.Column + 2)
                || CheckJump(cell, cell.Row + 2, cell.Column - 2)
                || CheckJump(cell, cell.Row + 2, cell.Column - 2);
            }
            if (cell.PieceSet.Color)
            {
                return CheckJump(cell, cell.Row - 2, cell.Column - 2) || CheckJump(cell, cell.Row - 2, cell.Column + 2);
            }
            else
            {
                return CheckJump(cell, cell.Row + 2, cell.Column - 2) || CheckJump(cell, cell.Row + 2, cell.Column + 2);
            }
        }

        private bool CheckMultipleJump(Cell cell)
        {
            return (cell.PieceSet.King || cell.PieceSet.Color ? CheckJump(cell, cell.Row - 2, cell.Column - 2) || CheckJump(cell, cell.Row - 2, cell.Column + 2) : false) ||
                (cell.PieceSet.King || !cell.PieceSet.Color ? CheckJump(cell, cell.Row + 2, cell.Column - 2) || CheckJump(cell, cell.Row + 2, cell.Column + 2) : false);
        }

        private bool CheckJump(Cell cell, int row, int column)
        {
            if (row < 0 || row >= BoardGenerator.SIZE || column < 0 || column >= BoardGenerator.SIZE)
            {
                return false;
            }
            Piece piece = game.GameBoard[(cell.Row + row) / 2][(cell.Column + column) / 2].PieceSet;
            //return game.GameBoard[row][column].PieceSet == null && piece != null ? cell.PieceSet.Color != piece.Color : false;
            return game.GameBoard[row][column].PieceSet == null && piece != null && cell.PieceSet.Color != piece.Color;
        }
    }
}