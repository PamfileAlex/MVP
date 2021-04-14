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
                    new Cell(0, 0, Cell.LightTile, null),
                    new Cell(0, 1, Cell.DarkTile, new Piece(Piece.BlackPiece)),
                    new Cell(0, 2, Cell.LightTile, null),
                    new Cell(0, 3, Cell.DarkTile, new Piece(Piece.BlackPiece)),
                    new Cell(0, 4, Cell.LightTile, null),
                    new Cell(0, 5, Cell.DarkTile, new Piece(Piece.BlackPiece)),
                    new Cell(0, 6, Cell.LightTile, null),
                    new Cell(0, 7, Cell.DarkTile, new Piece(Piece.BlackPiece))
                },
                new ObservableCollection<Cell>()
                {
                    new Cell(1, 0, Cell.DarkTile, new Piece(Piece.BlackPiece)),
                    new Cell(1, 1, Cell.LightTile, null),
                    new Cell(1, 2, Cell.DarkTile, new Piece(Piece.BlackPiece)),
                    new Cell(1, 3, Cell.LightTile, null),
                    new Cell(1, 4, Cell.DarkTile, new Piece(Piece.BlackPiece)),
                    new Cell(1, 5, Cell.LightTile, null),
                    new Cell(1, 6, Cell.DarkTile, new Piece(Piece.BlackPiece)),
                    new Cell(1, 7, Cell.LightTile, null)
                },
                new ObservableCollection<Cell>()
                {
                    new Cell(2, 0, Cell.LightTile, null),
                    new Cell(2, 1, Cell.DarkTile, new Piece(Piece.BlackPiece)),
                    new Cell(2, 2, Cell.LightTile, null),
                    new Cell(2, 3, Cell.DarkTile, new Piece(Piece.BlackPiece)),
                    new Cell(2, 4, Cell.LightTile, null),
                    new Cell(2, 5, Cell.DarkTile, new Piece(Piece.BlackPiece)),
                    new Cell(2, 6, Cell.LightTile, null),
                    new Cell(2, 7, Cell.DarkTile, new Piece(Piece.BlackPiece))
                },
                new ObservableCollection<Cell>()
                {
                    new Cell(3, 0, Cell.DarkTile, null),
                    new Cell(3, 1, Cell.LightTile, null),
                    new Cell(3, 2, Cell.DarkTile, null),
                    new Cell(3, 3, Cell.LightTile, null),
                    new Cell(3, 4, Cell.DarkTile, null),
                    new Cell(3, 5, Cell.LightTile, null),
                    new Cell(3, 6, Cell.DarkTile, null),
                    new Cell(3, 7, Cell.LightTile, null)
                },
                new ObservableCollection<Cell>()
                {
                    new Cell(4, 0, Cell.LightTile, null),
                    new Cell(4, 1, Cell.DarkTile, null),
                    new Cell(4, 2, Cell.LightTile, null),
                    new Cell(4, 3, Cell.DarkTile, null),
                    new Cell(4, 4, Cell.LightTile, null),
                    new Cell(4, 5, Cell.DarkTile, null),
                    new Cell(4, 6, Cell.LightTile, null),
                    new Cell(4, 7, Cell.DarkTile, null)
                },
                new ObservableCollection<Cell>()
                {
                    new Cell(5, 0, Cell.DarkTile, new Piece(Piece.WhitePiece)),
                    new Cell(5, 1, Cell.LightTile, null),
                    new Cell(5, 2, Cell.DarkTile, new Piece(Piece.WhitePiece)),
                    new Cell(5, 3, Cell.LightTile, null),
                    new Cell(5, 4, Cell.DarkTile, new Piece(Piece.WhitePiece)),
                    new Cell(5, 5, Cell.LightTile, null),
                    new Cell(5, 6, Cell.DarkTile, new Piece(Piece.WhitePiece)),
                    new Cell(5, 7, Cell.LightTile, null)
                },
                new ObservableCollection<Cell>()
                {
                    new Cell(6, 0, Cell.LightTile, null),
                    new Cell(6, 1, Cell.DarkTile, new Piece(Piece.WhitePiece)),
                    new Cell(6, 2, Cell.LightTile, null),
                    new Cell(6, 3, Cell.DarkTile, new Piece(Piece.WhitePiece)),
                    new Cell(6, 4, Cell.LightTile, null),
                    new Cell(6, 5, Cell.DarkTile, new Piece(Piece.WhitePiece)),
                    new Cell(6, 6, Cell.LightTile, null),
                    new Cell(6, 7, Cell.DarkTile, new Piece(Piece.WhitePiece))
                },
                new ObservableCollection<Cell>()
                {
                    new Cell(7, 0, Cell.DarkTile, new Piece(Piece.WhitePiece)),
                    new Cell(7, 1, Cell.LightTile, null),
                    new Cell(7, 2, Cell.DarkTile, new Piece(Piece.WhitePiece)),
                    new Cell(7, 3, Cell.LightTile, null),
                    new Cell(7, 4, Cell.DarkTile, new Piece(Piece.WhitePiece)),
                    new Cell(7, 5, Cell.LightTile, null),
                    new Cell(7, 6, Cell.DarkTile, new Piece(Piece.WhitePiece)),
                    new Cell(7, 7, Cell.LightTile, null)
                },
            };
        }
    }
}
