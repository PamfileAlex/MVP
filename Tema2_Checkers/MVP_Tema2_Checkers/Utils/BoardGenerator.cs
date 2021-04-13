using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVP_Tema2_Checkers.Models;

namespace MVP_Tema2_Checkers.Utils
{
    static class BoardGenerator
    {
        public static ObservableCollection<ObservableCollection<Cell>> NewGame()
        {
            return new ObservableCollection<ObservableCollection<Cell>>()
            {
                new ObservableCollection<Cell>()
                {
                    new Cell(Cell.LightTile, null),
                    new Cell(Cell.DarkTile, new Piece(Piece.BlackPiece)),
                    new Cell(Cell.LightTile, null),
                    new Cell(Cell.DarkTile, new Piece(Piece.BlackPiece)),
                    new Cell(Cell.LightTile, null),
                    new Cell(Cell.DarkTile, new Piece(Piece.BlackPiece)),
                    new Cell(Cell.LightTile, null),
                    new Cell(Cell.DarkTile, new Piece(Piece.BlackPiece))
                },
                new ObservableCollection<Cell>()
                {
                    new Cell(Cell.DarkTile, new Piece(Piece.BlackPiece)),
                    new Cell(Cell.LightTile, null),
                    new Cell(Cell.DarkTile, new Piece(Piece.BlackPiece)),
                    new Cell(Cell.LightTile, null),
                    new Cell(Cell.DarkTile, new Piece(Piece.BlackPiece)),
                    new Cell(Cell.LightTile, null),
                    new Cell(Cell.DarkTile, new Piece(Piece.BlackPiece)),
                    new Cell(Cell.LightTile, null)
                },
                new ObservableCollection<Cell>()
                {
                    new Cell(Cell.LightTile, null),
                    new Cell(Cell.DarkTile, new Piece(Piece.BlackPiece)),
                    new Cell(Cell.LightTile, null),
                    new Cell(Cell.DarkTile, new Piece(Piece.BlackPiece)),
                    new Cell(Cell.LightTile, null),
                    new Cell(Cell.DarkTile, new Piece(Piece.BlackPiece)),
                    new Cell(Cell.LightTile, null),
                    new Cell(Cell.DarkTile, new Piece(Piece.BlackPiece))
                },
                new ObservableCollection<Cell>()
                {
                    new Cell(Cell.DarkTile, null),
                    new Cell(Cell.LightTile, null),
                    new Cell(Cell.DarkTile, null),
                    new Cell(Cell.LightTile, null),
                    new Cell(Cell.DarkTile, null),
                    new Cell(Cell.LightTile, null),
                    new Cell(Cell.DarkTile, null),
                    new Cell(Cell.LightTile, null)
                },
                new ObservableCollection<Cell>()
                {
                    new Cell(Cell.LightTile, null),
                    new Cell(Cell.DarkTile, null),
                    new Cell(Cell.LightTile, null),
                    new Cell(Cell.DarkTile, null),
                    new Cell(Cell.LightTile, null),
                    new Cell(Cell.DarkTile, null),
                    new Cell(Cell.LightTile, null),
                    new Cell(Cell.DarkTile, null)
                },
                new ObservableCollection<Cell>()
                {
                    new Cell(Cell.DarkTile, new Piece(Piece.WhitePiece)),
                    new Cell(Cell.LightTile, null),
                    new Cell(Cell.DarkTile, new Piece(Piece.WhitePiece)),
                    new Cell(Cell.LightTile, null),
                    new Cell(Cell.DarkTile, new Piece(Piece.WhitePiece)),
                    new Cell(Cell.LightTile, null),
                    new Cell(Cell.DarkTile, new Piece(Piece.WhitePiece)),
                    new Cell(Cell.LightTile, null)
                },
                new ObservableCollection<Cell>()
                {
                    new Cell(Cell.LightTile, null),
                    new Cell(Cell.DarkTile, new Piece(Piece.WhitePiece)),
                    new Cell(Cell.LightTile, null),
                    new Cell(Cell.DarkTile, new Piece(Piece.WhitePiece)),
                    new Cell(Cell.LightTile, null),
                    new Cell(Cell.DarkTile, new Piece(Piece.WhitePiece)),
                    new Cell(Cell.LightTile, null),
                    new Cell(Cell.DarkTile, new Piece(Piece.WhitePiece))
                },
                new ObservableCollection<Cell>()
                {
                    new Cell(Cell.DarkTile, new Piece(Piece.WhitePiece)),
                    new Cell(Cell.LightTile, null),
                    new Cell(Cell.DarkTile, new Piece(Piece.WhitePiece)),
                    new Cell(Cell.LightTile, null),
                    new Cell(Cell.DarkTile, new Piece(Piece.WhitePiece)),
                    new Cell(Cell.LightTile, null),
                    new Cell(Cell.DarkTile, new Piece(Piece.WhitePiece)),
                    new Cell(Cell.LightTile, null)
                },
            };
        }
    }
}
