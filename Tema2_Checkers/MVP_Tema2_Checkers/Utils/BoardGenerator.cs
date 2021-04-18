﻿using System;
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
        public static int SIZE = 8;
        private static readonly List<Cell.TILE> tiles = new List<Cell.TILE>() { Cell.TILE.LIGHT, Cell.TILE.DARK };
        public static ObservableCollection<ObservableCollection<Cell>> NewGame()
        {
            ObservableCollection<ObservableCollection<Cell>> board = new ObservableCollection<ObservableCollection<Cell>>();
            for (int row = 0; row < SIZE; ++row)
            {
                ObservableCollection<Cell> line = new ObservableCollection<Cell>();
                for (int column = 0; column < SIZE; ++column)
                {
                    line.Add(new Cell(row, column, tiles[column % 2], GeneratePiece(row, column)));
                }
                board.Add(line);
                tiles.Reverse();
            }
            return board;
        }

        public static void ResetNewGame(Game game)
        {
            game.IsRunning = false;
            game.Color = true;
            for (int row = 0; row < SIZE; ++row)
            {
                for (int column = 0; column < SIZE; ++column)
                {
                    game.GameBoard[row][column].PieceSet = GeneratePiece(row, column);
                    game.GameBoard[row][column].Selected = false;
                }
                tiles.Reverse();
            }
        }

        private static Piece GeneratePiece(int row, int column)
        {
            if (tiles[column % 2] == Cell.TILE.LIGHT)
            {
                return null;
            }
            if (row < 3)
            {
                return new Piece(Piece.COLOR.BLACK);
            }
            else if (row > 4)
            {
                return new Piece(Piece.COLOR.WHITE);
            }
            return null;
        }
    }
}
