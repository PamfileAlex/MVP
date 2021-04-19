using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVP_Tema2_Checkers.ViewModels;

namespace MVP_Tema2_Checkers.Models
{
    public class Piece : BaseNotification
    {
        private static readonly String WHITE_PIECE;
        private static readonly String BLACK_PIECE;
        private static readonly String WHITE_KING_PIECE;
        private static readonly String BLACK_KING_PIECE;

        static Piece()
        {
            WHITE_PIECE = "/MVP_Tema2_Checkers;component/Assets/White_Piece.png";
            BLACK_PIECE = "/MVP_Tema2_Checkers;component/Assets/Black_Piece.png";
            WHITE_KING_PIECE = "/MVP_Tema2_Checkers;component/Assets/White_King_Piece.png";
            BLACK_KING_PIECE = "/MVP_Tema2_Checkers;component/Assets/Black_King_Piece.png";
        }

        public enum COLOR
        {
            BLACK,
            WHITE
        }

        //true: WHITE
        //false: BLACK
        public bool Color { get; }
        private bool king;
        public bool King
        {
            get
            {
                return king;
            }
            set
            {
                king = value;
                NotifyPropertyChanged("PieceImage");
            }
        }
        public String PieceImage
        {
            get
            {
                return Color ? (King ? WHITE_KING_PIECE : WHITE_PIECE) : (King ? BLACK_KING_PIECE : BLACK_PIECE);
            }
        }

        public Piece(COLOR color)
        {
            this.Color = Convert.ToBoolean(color);
            this.King = false;
        }
    }
}
