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
        private readonly Game game;
        private Cell previousCell;
        private bool pieceTaken;
        private List<Cell> cells = new List<Cell>();

        public GameLogic(Game game)
        {
            this.game = game;
            this.pieceTaken = false;
        }

        public void ResetPreviousCell()
        {
            previousCell = null;
        }

        public void MovePiece(Cell cell)
        {
            if (previousCell == cell || (cell.PieceSet == null ? previousCell == null : cell.PieceSet.Color != game.Color) || pieceTaken && !PossibleMultipleJumpCells().Contains(cell))
            {
                return;
            }
            if (previousCell == null || cell.PieceSet != null)
            {
                if (previousCell != null)
                {
                    previousCell.Selected = false;
                }
                game.IsRunning = true;
                previousCell = cell;
                previousCell.Selected = true;
                //foreach (var item in cells)
                //{
                //    item.Selected = false;
                //}
                //cells = Move();
                //foreach (var item in cells)
                //{
                //    item.Selected = true;
                //}
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
            if (game.CheckForWin()) { return; }
            if (game.MultipleJump && pieceTaken && CheckMultipleJump(cell))
            {
                previousCell = cell;
                previousCell.Selected = true;
                return;
            }
            pieceTaken = false;
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
            if (!previousCell.PieceSet.King && (previousCell.PieceSet.Color ? previousCell.Row < cell.Row : previousCell.Row > cell.Row))
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

        private List<Cell> PossibleMultipleJumpCells()
        {
            List<Cell> cellList = new List<Cell>();
            if (previousCell.PieceSet.King || previousCell.PieceSet.Color)
            {
                if (CheckJump(previousCell, previousCell.Row - 2, previousCell.Column - 2))
                {
                    cellList.Add(game.GameBoard[previousCell.Row - 2][previousCell.Column - 2]);
                }
                if (CheckJump(previousCell, previousCell.Row - 2, previousCell.Column + 2))
                {
                    cellList.Add(game.GameBoard[previousCell.Row - 2][previousCell.Column + 2]);
                }
            }
            if (previousCell.PieceSet.King || !previousCell.PieceSet.Color)
            {
                if (CheckJump(previousCell, previousCell.Row + 2, previousCell.Column - 2))
                {
                    cellList.Add(game.GameBoard[previousCell.Row + 2][previousCell.Column - 2]);
                }
                if (CheckJump(previousCell, previousCell.Row + 2, previousCell.Column + 2))
                {
                    cellList.Add(game.GameBoard[previousCell.Row + 2][previousCell.Column + 2]);
                }
            }
            return cellList;
        }






        public void Move(Cell cell)
        {
            if (previousCell == cell || previousCell == null && cell.PieceSet == null) { return; }
            cells = PossibleMoves();
            if (cell.PieceSet != null && cell.PieceSet.Color == game.Color)
            {
                if (previousCell != null)
                {
                    previousCell.Selected = false;
                    SetSelectedForCells(false);
                }
                game.IsRunning = true;
                previousCell = cell;
                previousCell.Selected = true;
                cells = PossibleMoves();
                SetSelectedForCells(true);
            }
            if (!cells.Contains(cell)) { return; }
            SetSelectedForCells(false);
            Jumped(cell);
            cell.PieceSet = previousCell.PieceSet;
            previousCell.PieceSet = null;
            previousCell.Selected = false;
            previousCell = null;
            CheckAndTransformToKing(cell);
            if (game.CheckForWin()) { return; }
            if (game.MultipleJump && pieceTaken && CheckMultipleJump(cell))
            {
                previousCell = cell;
                previousCell.Selected = true;
                cells = PossibleMoves();
                SetSelectedForCells(true);
                return;
            }
            pieceTaken = false;
            game.Color = !game.Color;
        }

        public void SetSelectedForCells(bool selected)
        {
            if (cells == null) { return; }
            foreach (var cell in cells)
            {
                cell.Selected = selected;
            }
        }

        private List<Cell> PossibleMoves()
        {
            List<Cell> cellList = new List<Cell>();
            if (previousCell == null)
            {
                return cellList;
            }
            if (previousCell.PieceSet.King || previousCell.PieceSet.Color)
            {
                OneTileMove(previousCell, cellList, Direction.NW);
                OneTileMove(previousCell, cellList, Direction.NE);
            }
            if (previousCell.PieceSet.King || !previousCell.PieceSet.Color)
            {
                OneTileMove(previousCell, cellList, Direction.SE);
                OneTileMove(previousCell, cellList, Direction.SW);
            }
            return cellList;
        }

        private void OneTileMove(Cell cell, List<Cell> cellList, Direction direction)
        {
            var directionTuple = DirectionControl.Get(direction);
            int row = cell.Row + directionTuple.Item1;
            int column = cell.Column + directionTuple.Item2;
            if (row < 0 || row >= BoardGenerator.SIZE || column < 0 || column >= BoardGenerator.SIZE)
            {
                return;
            }
            if (game.GameBoard[row][column].PieceSet == null)
            {
                cellList.Add(game.GameBoard[row][column]);
                return;
            }
            if (game.GameBoard[row][column].PieceSet.Color != game.Color)
            {
                TwoTileMove(cell, cellList, direction);
            }
        }

        private void TwoTileMove(Cell cell, List<Cell> cellList, Direction direction)
        {
            var directionTuple = DirectionControl.Get(direction);
            int row = cell.Row + 2 * directionTuple.Item1;
            int column = cell.Column + 2 * directionTuple.Item2;
            if (row < 0 || row >= BoardGenerator.SIZE || column < 0 || column >= BoardGenerator.SIZE)
            {
                return;
            }
            if (game.GameBoard[row][column].PieceSet == null)
            {
                cellList.Add(game.GameBoard[row][column]);
            }
        }

        private void Jumped(Cell cell)
        {
            if (Math.Abs(previousCell.Row - cell.Row) == 2 && Math.Abs(previousCell.Column - cell.Column) == 2)
            {
                Cell cellInBetween = game.GameBoard[(previousCell.Row + cell.Row) / 2][(previousCell.Column + cell.Column) / 2];
                game.RemovePiece(cellInBetween);
                pieceTaken = true;
            }
        }
    }
}