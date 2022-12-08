namespace board {
    internal abstract class Piece {
        public Position position { get; protected set; }
        public Color color { get; protected set; }
        public int MovesQuantity { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Color color, Board board) {
            this.position = null;
            this.color = color;
            this.MovesQuantity = 0;
            this.board = board;
        }

        public void SetPosition(Position position) {
            this.position = position;
        }

        public void IncrementMoves() {
            MovesQuantity++;
        }
        public void DecrementMoves() {
            MovesQuantity--;
        }

        private protected bool canMove(Position position) {
            Piece pieceInDestiny = board.GetPiece(position);
            return (pieceInDestiny == null) || (pieceInDestiny.color != this.color);
        }

        public bool HasPossibleMoviments() {
            bool[,] possibleMoviments = PossibleMoviments();

            for(int i = 0; i < board.Lines; i++) {
                for(int j = 0; j < board.Columns; j++) {
                    if (possibleMoviments[i, j]) {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool PossibleMoviment(Position position) {
            return PossibleMoviments()[position.Line, position.Column];
        }

        public abstract bool[,] PossibleMoviments();

    }
}
