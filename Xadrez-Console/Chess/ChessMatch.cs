using board;

namespace Chess {
    internal class ChessMatch {
        public Board board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }

        public ChessMatch() {
            board = new Board(8, 8);
            Turn = 1;
            Finished = false;
            CurrentPlayer = Color.White;
            PutPieces();
        }

        public void DoMoviment(Position origin, Position destiny) {
            Piece piece = board.RemovePiece(origin);
            Piece? capturedPiece = board.RemovePiece(destiny);
            board.AddPiece(piece, destiny);
        }

        public void PassTurn(Position origin, Position destiny) {
            DoMoviment(origin, destiny);
            if(CurrentPlayer == Color.White) {
                CurrentPlayer = Color.Black;
            }
            else {
                CurrentPlayer = Color.White;
            }
            Turn++;

        }

        public void ValidateOrigin(Position position) {
            if(board.GetPiece(position) == null) {
                throw new BoardException("Does not exist a piece in origin!");
            }

            if(CurrentPlayer != board.GetPiece(position).color) {
                throw new BoardException("The piece in origin isn't your piece!");
            }

            if (!board.GetPiece(position).HasPossibleMoviments()) {
                throw new BoardException("Does not possible moviments to chosen piece!");
            }

        }

        public void ValidateDestiny(Position origin, Position destiny) {
            if (!board.GetPiece(origin).CanMoveTo(destiny)) {
                throw new BoardException("Destiny position is invalid!");
            }
        }


        private void PutPieces() {
            board.AddPiece(new Tower(Color.Black, board), new ChessPosition('a', 1).toPosition());
            board.AddPiece(new Tower(Color.White, board), new ChessPosition('d', 4).toPosition());
            board.AddPiece(new Tower(Color.Black, board), new ChessPosition('d', 3).toPosition());
            board.AddPiece(new King(Color.Black, board), new ChessPosition('g', 3).toPosition());
        }



    }
}
