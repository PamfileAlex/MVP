using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Tema2_Checkers.Models
{
    class Cell
    {
        public static readonly String LightTile;
        public static readonly String DarkTile;

        static Cell()
        {
            LightTile = "#ffce9e";
            DarkTile = "#d18b47";
        }

        public String TileColor { get; set; }
        public Piece PieceSet { get; set; }

        public Cell(String tileColor, Piece pieceSet)
        {
            this.TileColor = tileColor;
            this.PieceSet = pieceSet;
        }
    }
}
