using board;
using Chess;

namespace Chess_Console {
    internal class Screen {
        public static void PrintBoard(Board board) {

            int padding = 1;
            int lines = board.Lines;
            while (lines >= 10) {
                padding++;
                lines /= 10;
            }

            for (int i = 0; i < board.Lines; i++) {
                Console.Write($"{(board.Lines - i).ToString().PadLeft(padding)} ");
                for (int j = 0; j < board.Columns; j++) {
                    Screen.PrintPiece(board.GetPiece(i, j));
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

            Console.Write("  ".PadLeft(padding + 1));
            for (int i = 0; i < board.Columns; i++) {
                Console.Write($"{(char)('a' + i)} ");
            }
            Console.WriteLine();
        }

        public static void PrintBoard(Board board, bool[,] possibleMoviments) {

            int padding = 1;
            int lines = board.Lines;
            while (lines >= 10) {
                padding++;
                lines /= 10;
            }

            ConsoleColor defaultColor = Console.BackgroundColor;
            for (int i = 0; i < board.Lines; i++) {
                Console.Write($"{(board.Lines - i).ToString().PadLeft(padding)} ");
                for (int j = 0; j < board.Columns; j++) {
                    if (possibleMoviments[i, j]) {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                    }
                    Screen.PrintPiece(board.GetPiece(i, j));
                    Console.BackgroundColor = defaultColor;

                    Console.Write(" ");
                }
                Console.WriteLine();
            }

            Console.Write("  ".PadLeft(padding + 1));
            for (int i = 0; i < board.Columns; i++) {
                Console.Write($"{(char)('a' + i)} ");
            }
            Console.WriteLine();
        }

        public static void PrintGame(ChessMatch match) {
            PrintBoard(match.board);
            Console.WriteLine();

            Console.WriteLine("Captured Pieces:");
            PrintPiecesCaptured(match);
            Console.WriteLine();

            Console.WriteLine($"Turn of player: {match.CurrentPlayer}");
            Console.WriteLine();
            
            Console.WriteLine($"Turn: #{match.Turn}");
        }

        public static void PrintGame(ChessMatch match, bool[,] possibleMoviments) {
            PrintBoard(match.board, possibleMoviments);
            Console.WriteLine();

            Console.WriteLine($"Turn of player: {match.CurrentPlayer}");
            Console.WriteLine();

            Console.WriteLine($"Turn: #{match.Turn}");
        }

        public static void PrintPiecesCaptured(ChessMatch match) {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Whites: ");
            PrintSet(match, Color.White);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Blacks: ");
            PrintSet(match, Color.Black);
            Console.ForegroundColor = defaultColor;
        }

        public static void PrintSet(ChessMatch match, Color color) {
            Console.Write("{ ");
            foreach (Piece p in match.PiecesCaptured(color)) {
                Console.Write(p + " ");
            }
            Console.WriteLine("}");
        }

        public static void PrintPiece(Piece piece) {
            // If the piece is null, print "-" in the place
            if (piece == null) {
                Console.Write("-");
            }
            else {
                if (piece.color == Color.White) {
                    ConsoleColor defaultColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(piece);
                    Console.ForegroundColor = defaultColor;
                }
                else if (piece.color == Color.Black) {
                    ConsoleColor defaultColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = defaultColor;
                }
            }
        }

        public static Position ReadChessPosition() {
            string input = Console.ReadLine();
            char column = input[0];
            int line = int.Parse(input[1] + "");
            return new ChessPosition(column, line).toPosition();
        }
    }
}
