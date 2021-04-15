using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVP_Tema2_Checkers.ViewModels;

namespace MVP_Tema2_Checkers.Models
{
    class Game : BaseNotification
    {
        private static readonly int PIECES = 12;

        private int whitePieces;
        private int blackPieces;
        public ObservableCollection<ObservableCollection<Cell>> GameBoard { get; }
        private bool color;
        public bool Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                NotifyPropertyChanged("Player");
            }
        }
        public String Player
        {
            get
            {
                return Color ? "Jucatorul piese albe" : "Jucatorul piese negre";
            }
        }

        public Game(ObservableCollection<ObservableCollection<Cell>> gameBoard)
        {
            this.GameBoard = gameBoard;
            this.whitePieces = this.blackPieces = PIECES;
            this.Color = true;
        }

        public void RemovePiece(Cell cell)
        {
            _ = cell.PieceSet.Color ? --whitePieces : --blackPieces;
            cell.PieceSet = null;
        }
    }
}
