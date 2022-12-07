using System;
using board;
using Chess;


namespace Chess_Console {
    class Program {
        static void Main(string[] args) {
            try {
                ChessMatch chessMatch = new ChessMatch();
                Screen.PrintBoard(chessMatch.board);

                Console.WriteLine("Origin: ");
                Position origin = Screen.ReadChessPosition();
                Console.Clear();
                Screen.PrintBoard(chessMatch.board, chessMatch.board.GetPiece(origin).PossibleMoviments());
                Console.WriteLine("Destiny: ");
                Position destiny = Screen.ReadChessPosition();
                Console.Clear();

                chessMatch.DoMoviment(origin, destiny);
                Screen.PrintBoard(chessMatch.board);

            }
            catch(BoardException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}