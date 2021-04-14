using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Tema2_Checkers.Models
{
    class Game
    {
        private static readonly int PIECES = 12;

        private int whitePieces;
        private int blackPieces;
        public ObservableCollection<ObservableCollection<Cell>> GameBoard { get; }

        public Game(ObservableCollection<ObservableCollection<Cell>> gameBoard)
        {
            this.GameBoard = gameBoard;
            this.whitePieces = this.blackPieces = PIECES;
        }

        public void RemovePiece(Cell cell)
        {
            _ = cell.PieceSet.Color ? --whitePieces : --blackPieces;
            cell.PieceSet = null;
        }
    }
}
