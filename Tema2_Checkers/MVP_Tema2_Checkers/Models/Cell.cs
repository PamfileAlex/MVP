using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using MVP_Tema2_Checkers.ViewModels;

namespace MVP_Tema2_Checkers.Models
{
    class Cell : BaseNotification
    {
        public static readonly String LightTile;
        public static readonly String DarkTile;

        static Cell()
        {
            LightTile = "#ffce9e";
            DarkTile = "#d18b47";
        }

        private Piece pieceSet;

        public int Row { get; }
        public int Column { get; }
        public String TileColor { get; }
        public Piece PieceSet
        {
            get
            {
                return pieceSet;
            }
            set
            {
                pieceSet = value;
                NotifyPropertyChanged("PieceSet");
            }
        }

        public Cell(int row, int column, String tileColor, Piece pieceSet)
        {
            this.Row = row;
            this.Column = column;
            this.TileColor = tileColor;
            this.PieceSet = pieceSet;
        }
    }
}
