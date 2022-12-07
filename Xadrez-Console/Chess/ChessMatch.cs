using board;

namespace Chess {
    internal class ChessMatch {
        public Board board { get; private set; }
        private int turn;
        private Color currentPlayer;

        public ChessMatch() {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            PutPieces();
        }

        public void DoMoviment(Position origin, Position destiny) {
            Piece piece = board.RemovePiece(origin);
            Piece? capturedPiece = board.RemovePiece(destiny);
            board.AddPiece(piece, destiny);

        }

        private void PutPieces() {
            board.AddPiece(new Tower(Color.Black, board), new ChessPosition('a', 1).toPosition());
            board.AddPiece(new Tower(Color.White, board), new ChessPosition('d', 4).toPosition());
            board.AddPiece(new Tower(Color.Black, board), new ChessPosition('d', 3).toPosition());
            board.AddPiece(new King(Color.Black, board), new ChessPosition('g', 3).toPosition());
        }



    }
}
