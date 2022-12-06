using System;
using board;
using Xadrez;


namespace Xadrez_Console {
    class Program {
        static void Main(string[] args) {
            Position p = new Position(5, 3);
            Console.WriteLine(p);

            Board b = new Board(8, 8);
            Console.WriteLine(b.Lines.ToString() + ", " + b.Columns.ToString());

            b.AddPiece(new Tower(Color.Black, b), new Position(0, 0));
            b.AddPiece(new King(Color.Black, b), new Position(3, 6));
            b.AddPiece(new Tower(Color.Black, b), new Position(6, 0));
            b.AddPiece(new Tower(Color.Black, b), new Position(7, 7));
            b.AddPiece(new King(Color.Black, b), new Position(2, 1));
            Screen.printBoard(b);

        }
    }
}