using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

using MVP_Tema2_Checkers.Utils;
using MVP_Tema2_Checkers.ViewModels;

namespace MVP_Tema2_Checkers.Models
{
    public class Game : BaseNotification, IXmlSerializable
    {
        private static readonly int PIECES = 12;

        private int whitePieces;
        public int WhitePieces
        {
            get { return whitePieces; }
            private set
            {
                whitePieces = value;
                NotifyPropertyChanged("WhitePieces");
            }
        }
        private int blackPieces;
        public int BlackPieces
        {
            get { return blackPieces; }
            private set
            {
                blackPieces = value;
                NotifyPropertyChanged("BlackPieces");
            }
        }
        public ObservableCollection<ObservableCollection<Cell>> GameBoard { get; }
        public bool IsRunning { get; set; }
        private bool multipleJump;
        public bool MultipleJump
        {
            get { return multipleJump; }
            set
            {
                multipleJump = value;
                NotifyPropertyChanged("MultipleJump");
            }
        }
        private bool color;
        public bool Color
        {
            get { return color; }
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

        public Game()
        {
            GameBoard = BoardGenerator.NewGame(true);
        }
        public Game(ObservableCollection<ObservableCollection<Cell>> gameBoard)
        {
            this.GameBoard = gameBoard;
            Reset();
        }

        public void Reset()
        {
            this.WhitePieces = this.BlackPieces = PIECES;
            this.Color = true;
            this.IsRunning = false;
            this.MultipleJump = false;
        }

        public void RemovePiece(Cell cell)
        {
            _ = cell.PieceSet.Color ? --WhitePieces : --BlackPieces;
            cell.PieceSet = null;
        }

        public bool CheckForWin()
        {
            if (WhitePieces == 0)
            {
                GameInfo.Instance.AddWin(false);
                MessageBox.Show("A castigat jucatorul cu piese negre");
                BoardGenerator.ResetNewGame(this);
                this.Reset();
                return true;
            }
            else if (BlackPieces == 0)
            {
                GameInfo.Instance.AddWin(true);
                MessageBox.Show("A castigat jucatorul cu piese albe");
                BoardGenerator.ResetNewGame(this);
                this.Reset();
                return true;
            }
            return false;
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            BoardGenerator.ResetNewGame(this, true);
            WhitePieces = int.Parse(reader.GetAttribute("whitePieces"));
            BlackPieces = int.Parse(reader.GetAttribute("blackPieces"));
            IsRunning = bool.Parse(reader.GetAttribute("IsRunning"));
            MultipleJump = bool.Parse(reader.GetAttribute("MultipleJump"));
            Color = bool.Parse(reader.GetAttribute("Color"));
            while (reader.ReadToFollowing("Piece"))
            {
                int row = int.Parse(reader.GetAttribute("Row"));
                int column = int.Parse(reader.GetAttribute("Column"));
                Piece piece = new Piece(bool.Parse(reader.GetAttribute("Color")) ? Piece.COLOR.WHITE : Piece.COLOR.BLACK);
                piece.King = bool.Parse(reader.GetAttribute("King"));
                GameBoard[row][column].PieceSet = piece;
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("whitePieces", WhitePieces.ToString());
            writer.WriteAttributeString("blackPieces", BlackPieces.ToString());
            writer.WriteAttributeString("IsRunning", IsRunning.ToString());
            writer.WriteAttributeString("MultipleJump", MultipleJump.ToString());
            writer.WriteAttributeString("Color", Color.ToString());
            writer.WriteStartElement("Board");
            foreach (var line in GameBoard)
            {
                foreach (var cell in line)
                {
                    if (cell.PieceSet == null) { continue; }
                    writer.WriteStartElement("Piece");
                    writer.WriteAttributeString("Row", cell.Row.ToString());
                    writer.WriteAttributeString("Column", cell.Column.ToString());
                    writer.WriteAttributeString("Color", cell.PieceSet.Color.ToString());
                    writer.WriteAttributeString("King", cell.PieceSet.King.ToString());
                    writer.WriteEndElement();
                }
            }
            writer.WriteEndElement();
        }
    }
}
