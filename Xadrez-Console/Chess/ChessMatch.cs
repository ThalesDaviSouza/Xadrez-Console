using System.Collections.Generic;
using board;
using Chess_Console;

namespace Chess {
    internal class ChessMatch {
        public Board board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }
        public bool Check { get; private set; }
        public Piece PieceVulnerableToEnPassant { get; private set; }
        private HashSet<Piece> piecesInGame;
        private HashSet<Piece> piecesCaptured;

        public ChessMatch() {
            board = new Board(8, 8);
            Turn = 1;
            Finished = false;
            CurrentPlayer = Color.White;
            piecesInGame = new HashSet<Piece>();
            piecesCaptured = new HashSet<Piece>();
            PieceVulnerableToEnPassant = null;
            PutPieces();
        }

        private bool isCastlingShort(Position origin, Position destiny) {
            return (destiny.Column == origin.Column + 2);
        }

        private bool isCastlingLong(Position origin, Position destiny) {
            return (destiny.Column == origin.Column - 2);
        }

        public Piece DoMoviment(Position origin, Position destiny) {
            Piece piece = board.RemovePiece(origin);
            piece.IncrementMoves();

            Piece capturedPiece = board.RemovePiece(destiny);
            board.AddPiece(piece, destiny);

            if (capturedPiece != null) {
                piecesCaptured.Add(capturedPiece);
            }

            // Special Moves
            // Castling Short
            if (piece is King && isCastlingShort(origin, destiny)) {
                // Moving the rook in castling short
                Position originRook = new Position(origin.Line, origin.Column + 3);
                Position destinyRook = new Position(origin.Line, origin.Column + 1);
                Piece rook = board.RemovePiece(originRook);
                rook.IncrementMoves();
                board.AddPiece(rook, destinyRook);
            }

            // Castling Long
            if (piece is King && isCastlingLong(origin, destiny)) {
                // Moving the rook in castling long
                Position originRook = new Position(origin.Line, origin.Column - 4);
                Position destinyRook = new Position(origin.Line, origin.Column - 1);
                Piece rook = board.RemovePiece(originRook);
                rook.IncrementMoves();
                board.AddPiece(rook, destinyRook);
            }

            // En Passant
            if (piece is Pawn) {
                if (origin.Column != destiny.Column && capturedPiece == null) {
                    Position capturedPawn;
                    if (piece.color == Color.White) {
                        capturedPawn = new Position(destiny.Line + 1, destiny.Column);
                    }
                    else {
                        capturedPawn = new Position(destiny.Line - 1, destiny.Column);
                    }
                    capturedPiece = board.RemovePiece(capturedPawn);
                    piecesCaptured.Add(capturedPiece);
                }
            }

            return capturedPiece;
        }

        public void UndoMoviment(Position origin, Position destiny, Piece capturedPiece) {
            Piece piece = board.RemovePiece(destiny);
            piece.DecrementMoves();
            if (capturedPiece != null) {
                board.AddPiece(capturedPiece, destiny);
                piecesCaptured.Remove(capturedPiece);
            }
            board.AddPiece(piece, origin);

            // Special Moves
            // Castling Short
            if (piece is King && isCastlingShort(origin, destiny)) {
                // Moving the rook in castling short
                Position originRook = new Position(origin.Line, origin.Column + 3);
                Position destinyRook = new Position(origin.Line, origin.Column + 1);
                Piece rook = board.RemovePiece(destinyRook);
                rook.DecrementMoves();
                board.AddPiece(rook, originRook);
            }

            // Castling Long
            if (piece is King && isCastlingLong(origin, destiny)) {
                // Moving the rook in castling long
                Position originRook = new Position(origin.Line, origin.Column - 4);
                Position destinyRook = new Position(origin.Line, origin.Column - 1);
                Piece rook = board.RemovePiece(destinyRook);
                rook.DecrementMoves();
                board.AddPiece(rook, originRook);
            }

            // En Passant
            if (piece is Pawn) {
                if (origin.Column != destiny.Column && capturedPiece == PieceVulnerableToEnPassant) {
                    Piece capturedPawn = board.RemovePiece(destiny);
                    Position positionCapturedPawn;
                    if (piece.color == Color.White) {
                        positionCapturedPawn = new Position(3, destiny.Column);
                    }
                    else {
                        positionCapturedPawn = new Position(4, destiny.Column);
                    }
                    board.AddPiece(capturedPawn, positionCapturedPawn);
                }
            }
        }

        public Color OpossingColor(Color color) {
            if (color == Color.Black) {
                return Color.White;
            }
            else {
                return Color.Black;
            }
        }
        public void ChangePlayer() {
            if (CurrentPlayer == Color.White) {
                CurrentPlayer = Color.Black;
            }
            else {
                CurrentPlayer = Color.White;
            }
        }

        private bool isPromotion(Piece piece, Position destiny) {
            return ((piece.color == Color.White) && (destiny.Line == 0)) || ((piece.color == Color.Black) && (destiny.Line == 7));
        }

        public void PassTurn(Position origin, Position destiny) {
            Piece capturedPiece = DoMoviment(origin, destiny);

            if (IsInCheck(CurrentPlayer)) {
                UndoMoviment(origin, destiny, capturedPiece);
                throw new BoardException("You cannot put yourself in check!");
            }

            if (IsInCheck(OpossingColor(CurrentPlayer))) {
                Check = true;
            }
            else {
                Check = false;
            }

            if (IsChekmate(OpossingColor(CurrentPlayer))) {
                Finished = true;
                return;
            }

            // Special Moves 
            // En Passant
            Piece piece = board.GetPiece(destiny);
            if ((piece is Pawn) && (destiny.Line == origin.Line - 2 || destiny.Line == origin.Line + 2)) {
                PieceVulnerableToEnPassant = piece;
            }
            else {
                PieceVulnerableToEnPassant = null;
            }

            // Promotion
            if (piece is Pawn) {
                if (isPromotion(piece, destiny)) {
                    char promotion = Screen.AskPromotion();
                    Piece promotedPiece;
                    switch (promotion) {
                        case 'c':
                            promotedPiece = new Cavalier(piece.color, board);
                            break;
                        case 'r':
                            promotedPiece = new Rook(piece.color, board);
                            break;
                        case 'b':
                            promotedPiece = new Bishop(piece.color, board);
                            break;
                        case 'q':
                            promotedPiece = new Queen(piece.color, board);
                            break;
                        default:
                            promotedPiece = new Queen(piece.color, board);
                            break;
                    }
                    piece = board.RemovePiece(destiny);
                    piecesInGame.Remove(piece);
                    board.AddPiece(promotedPiece, destiny);
                    piecesInGame.Add(promotedPiece);
                }
            }

            ChangePlayer();
            Turn++;
        }

        public void ValidateOrigin(Position position) {
            if (board.GetPiece(position) == null) {
                throw new BoardException("Does not exist a piece in origin!");
            }

            if (CurrentPlayer != board.GetPiece(position).color) {
                throw new BoardException("The piece in origin isn't your piece!");
            }

            if (!board.GetPiece(position).HasPossibleMoviments()) {
                throw new BoardException("Does not possible moviments to chosen piece!");
            }

        }

        public void ValidateDestiny(Position origin, Position destiny) {
            if (!board.GetPiece(origin).PossibleMoviment(destiny)) {
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

        private Piece GetKing(Color color) {
            foreach (Piece p in PiecesInGame(color)) {
                if (p is King) {
                    return p;
                }
            }
            return null;
        }

        public bool IsInCheck(Color color) {
            Piece king = GetKing(color);
            if (king == null) {
                throw new BoardException($"Does not exist a {color} king!");
            }

            foreach (Piece p in PiecesInGame(OpossingColor(color))) {
                bool[,] possibleMoviments = p.PossibleMoviments();
                if (possibleMoviments[king.position.Line, king.position.Column]) {
                    return true;
                }
            }

            return false;
        }

        public bool IsChekmate(Color color) {
            if (!IsInCheck(color)) {
                return false;
            }

            foreach (Piece p in PiecesInGame(color)) {
                bool[,] possibleMoviments = p.PossibleMoviments();
                for (int i = 0; i < board.Lines; i++) {
                    for (int j = 0; j < board.Columns; j++) {
                        if (possibleMoviments[i, j]) {
                            Position origin = p.position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = DoMoviment(origin, destiny);
                            bool checkTest = IsInCheck(color);
                            UndoMoviment(origin, destiny, capturedPiece);
                            if (!checkTest) {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void PutPiece(char column, int line, Piece piece) {
            board.AddPiece(piece, new ChessPosition(column, line).toPosition());
            piecesInGame.Add(piece);
        }

        private void PutPieces() {
            //Line 8 (Black)
            PutPiece('a', 8, new Rook(Color.Black, board));
            PutPiece('b', 8, new Cavalier(Color.Black, board));
            PutPiece('c', 8, new Bishop(Color.Black, board));
            PutPiece('d', 8, new Queen(Color.Black, board));
            PutPiece('e', 8, new King(Color.Black, board, this));
            PutPiece('f', 8, new Bishop(Color.Black, board));
            PutPiece('g', 8, new Cavalier(Color.Black, board));
            PutPiece('h', 8, new Rook(Color.Black, board));

            //Line 7(Black)
            PutPiece('a', 7, new Pawn(Color.Black, board, this));
            PutPiece('b', 7, new Pawn(Color.Black, board, this));
            PutPiece('c', 7, new Pawn(Color.Black, board, this));
            PutPiece('d', 7, new Pawn(Color.Black, board, this));
            PutPiece('e', 7, new Pawn(Color.Black, board, this));
            PutPiece('f', 7, new Pawn(Color.Black, board, this));
            PutPiece('g', 7, new Pawn(Color.Black, board, this));
            PutPiece('h', 7, new Pawn(Color.Black, board, this));

            //Line 1(White)
            PutPiece('a', 1, new Rook(Color.White, board));
            PutPiece('b', 1, new Cavalier(Color.White, board));
            PutPiece('c', 1, new Bishop(Color.White, board));
            PutPiece('d', 1, new Queen(Color.White, board));
            PutPiece('e', 1, new King(Color.White, board, this));
            PutPiece('f', 1, new Bishop(Color.White, board));
            PutPiece('g', 1, new Cavalier(Color.White, board));
            PutPiece('h', 1, new Rook(Color.White, board));

            //Line 2 (White)
            PutPiece('a', 2, new Pawn(Color.White, board, this));
            PutPiece('b', 2, new Pawn(Color.White, board, this));
            PutPiece('c', 2, new Pawn(Color.White, board, this));
            PutPiece('d', 2, new Pawn(Color.White, board, this));
            PutPiece('e', 2, new Pawn(Color.White, board, this));
            PutPiece('f', 2, new Pawn(Color.White, board, this));
            PutPiece('g', 2, new Pawn(Color.White, board, this));
            PutPiece('h', 2, new Pawn(Color.White, board, this));
        }



    }
}
