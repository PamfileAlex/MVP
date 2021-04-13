using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Tema2_Checkers.Models
{
    class Piece
    {
        public static readonly String WhitePiece;
        public static readonly String BlackPiece;
        public static readonly String WhiteKingPiece;
        public static readonly String BlackKingPiece;

        static Piece()
        {
            WhitePiece = "/MVP_Tema2_Checkers;component/Assets/White_Piece.png";
            BlackPiece = "/MVP_Tema2_Checkers;component/Assets/Black_Piece.png";
            WhiteKingPiece = "/MVP_Tema2_Checkers;component/Assets/White_King_Piece.png";
            BlackKingPiece = "/MVP_Tema2_Checkers;component/Assets/Black_King_Piece.png";
        }

        public String PieceImage { get; set; }

        public Piece(String pieceImage)
        {
            this.PieceImage = pieceImage;
        }
    }
}
