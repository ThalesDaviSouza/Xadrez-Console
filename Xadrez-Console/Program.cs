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
                        Console.Clear();
                        Screen.PrintGame(chessMatch);
                        Console.Write("Origin: ");
                        Position origin = Screen.ReadChessPosition();
                        chessMatch.ValidateOrigin(origin);
                        Console.Clear();

                        Screen.PrintGame(chessMatch, chessMatch.board.GetPiece(origin).PossibleMoviments());
                        Console.WriteLine();
                        Console.Write("Destiny: ");
                        Position destiny = Screen.ReadChessPosition();
                        chessMatch.ValidateDestiny(origin, destiny);
                        chessMatch.PassTurn(origin, destiny);
                    }
                    catch(BoardException e) {
                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                    }
                }
                Console.WriteLine("CHECKMATE!");
                Console.WriteLine($"Winner: {chessMatch.CurrentPlayer}!!!");
            }
            catch (BoardException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}