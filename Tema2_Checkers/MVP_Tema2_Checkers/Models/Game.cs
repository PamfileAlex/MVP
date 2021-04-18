using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using MVP_Tema2_Checkers.Utils;
using MVP_Tema2_Checkers.ViewModels;

namespace MVP_Tema2_Checkers.Models
{
    public class Game : BaseNotification
    {
        private static readonly int PIECES = 12;

        private int whitePieces;
        private int blackPieces;
        public ObservableCollection<ObservableCollection<Cell>> GameBoard { get; }
        public bool IsRunning { get; set; }
        public bool MultipleJump { get; set; }
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
                return Color ? "Piese albe" : "Piese negre";
            }
        }
        public Game() { }
        public Game(ObservableCollection<ObservableCollection<Cell>> gameBoard)
        {
            this.GameBoard = gameBoard;
            this.whitePieces = this.blackPieces = PIECES;
            this.Color = true;
            this.IsRunning = false;
            this.MultipleJump = false;
        }

        public void RemovePiece(Cell cell)
        {
            _ = cell.PieceSet.Color ? --whitePieces : --blackPieces;
            cell.PieceSet = null;
        }

        public bool CheckForWin()
        {
            if (whitePieces == 0)
            {
                GameWins.Instance.AddWin(false);
                MessageBox.Show("A castigat jucatorul cu piese negre");
                BoardGenerator.ResetNewGame(this);
                return true;
            }
            else if (blackPieces == 0)
            {
                GameWins.Instance.AddWin(true);
                MessageBox.Show("A castigat jucatorul cu piese albe");
                BoardGenerator.ResetNewGame(this);
                return true;
            }
            return false;
        }
    }
}
