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
                    // If don't have one piece in the current location, print "-"
                    if (board.GetPiece(i, j) != null) {
                        Screen.PrintPiece(board.GetPiece(i, j));
                        Console.Write(" ");
                    }
                    else {
                        Console.Write("{0} ", '-');
                    }
                }
                Console.WriteLine();
            }

            Console.Write("  ".PadLeft(padding + 1));
            for (int i = 0; i < board.Columns; i++) {
                Console.Write($"{(char)('a' + i)} ");
            }
        }

        public static void PrintPiece(Piece piece) {
            if (piece.color == Color.White) {
                ConsoleColor defaultColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(piece);
                Console.ForegroundColor = defaultColor;
            }
            else if(piece.color == Color.Black) {
                ConsoleColor defaultColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = defaultColor;
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
