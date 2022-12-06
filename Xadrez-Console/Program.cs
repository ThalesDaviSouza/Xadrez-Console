using System;
using board;
using Chess;


namespace Chess_Console {
    class Program {
        static void Main(string[] args) {
            try {
                ChessMatch chessMatch = new ChessMatch();
                Screen.PrintBoard(chessMatch.board);

                Console.WriteLine();
                Console.WriteLine("Origin: ");
                Position origin = Screen.ReadChessPosition();
                Console.WriteLine("Destiny: ");
                Position destiny = Screen.ReadChessPosition();

                chessMatch.DoMoviment(origin, destiny);
                Screen.PrintBoard(chessMatch.board);

            }
            catch(BoardException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}