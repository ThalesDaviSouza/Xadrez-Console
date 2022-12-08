using System;
using board;
using Chess;


namespace Chess_Console {
    class Program {
        static void Main(string[] args) {
            try {
                ChessMatch chessMatch = new ChessMatch();
                while (!chessMatch.Finished) {
                    try {
                        Screen.PrintGame(chessMatch);
                        Console.Write("Origin: ");
                        Position origin = Screen.ReadChessPosition();
                        Console.Clear();
                        chessMatch.ValidateOrigin(origin);

                        Screen.PrintGame(chessMatch, chessMatch.board.GetPiece(origin).PossibleMoviments());
                        Console.WriteLine();
                        Console.Write("Destiny: ");
                        Position destiny = Screen.ReadChessPosition();
                        Console.Clear();
                        chessMatch.ValidateDestiny(origin, destiny);

                        chessMatch.PassTurn(origin, destiny);
                    }
                    catch(BoardException e) {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            catch (BoardException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}