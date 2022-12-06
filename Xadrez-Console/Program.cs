using System;
using board;
using Chess;


namespace Chess_Console {
    class Program {
        static void Main(string[] args) {
            try {
                Board b = new Board(8, 8);

                b.AddPiece(new Tower(Color.Black, b), new Position(0, 0));
                b.AddPiece(new Tower(Color.White, b), new Position(2, 0));
                b.AddPiece(new King(Color.Black, b), new Position(4, 2));

                Screen.PrintBoard(b);
            }
            catch(BoardException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}