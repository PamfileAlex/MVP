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
        private static int SIZE = 8;
        private static List<String> tiles = new List<string>() { Cell.LightTile, Cell.DarkTile };
        public static ObservableCollection<ObservableCollection<Cell>> NewGame()
        {
            ObservableCollection<ObservableCollection<Cell>> board = new ObservableCollection<ObservableCollection<Cell>>();
            for (int row = 0; row < SIZE; ++row)
            {
                ObservableCollection<Cell> line = new ObservableCollection<Cell>();
                for (int column = 0; column < SIZE; ++column)
                {
                    Piece piece = null;
                    if (row < 3 && tiles[column % 2].Equals(Cell.DarkTile))
                    {
                        piece = new Piece(Piece.BlackPiece);
                    }
                    else if(row> 4 && tiles[column % 2].Equals(Cell.DarkTile))
                    {
                        piece = new Piece(Piece.WhitePiece);
                    }
                    line.Add(new Cell(row, column, tiles[column % 2], piece));
                }
                board.Add(line);
                tiles.Reverse();
            }
            return board;
        }
    }
}
