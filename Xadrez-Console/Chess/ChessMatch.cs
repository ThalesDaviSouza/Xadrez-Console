using System.Collections.Generic;
using board;

namespace Chess {
    internal class ChessMatch {
        public Board board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> piecesInGame;
        private HashSet<Piece> piecesCaptured;

        public ChessMatch() {
            board = new Board(8, 8);
            Turn = 1;
            Finished = false;
            CurrentPlayer = Color.White;
            piecesInGame = new HashSet<Piece>();
            piecesCaptured = new HashSet<Piece>();
            PutPieces();
        }

        public void DoMoviment(Position origin, Position destiny) {
            Piece piece = board.RemovePiece(origin);
            Piece? capturedPiece = board.RemovePiece(destiny);
            board.AddPiece(piece, destiny);
            if (capturedPiece != null) {
                piecesCaptured.Add(capturedPiece);
            }
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

        public HashSet<Piece> PiecesCaptured(Color color) {
            return piecesCaptured.ToList().FindAll(p => p.color == color).ToHashSet();
        }

        public HashSet<Piece> PiecesInGame(Color color) {
            HashSet<Piece> pieces = piecesInGame.ToList().FindAll(p => p.color == color).ToHashSet();
            pieces.ExceptWith(PiecesCaptured(color));
            return pieces;
        }

        public void PutPiece(char column, int line, Piece piece) {
            board.AddPiece(piece, new ChessPosition(column, line).toPosition());
            piecesInGame.Add(piece);
        }

        private void PutPieces() {
            PutPiece('a', 1, new Tower(Color.Black, board));
            PutPiece('d', 4, new Tower(Color.White, board));
            PutPiece('d', 3, new Tower(Color.Black, board));
            PutPiece('g', 3, new King(Color.Black, board));
        }



    }
}
