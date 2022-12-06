using board;

namespace Chess_Console {
    internal class Screen {
        public static void printBoard(Board board) {

            for(int i = 0; i < board.Lines; i++) {
                for (int j = 0; j < board.Columns; j++) {
                    // If don't have one piece in the current location, print "-"
                    Console.Write("{0} ", (board.GetPiece(i, j) == null ? '-' : board.GetPiece(i,j)) );
                }
                Console.WriteLine();
            }
        }
    }
}
