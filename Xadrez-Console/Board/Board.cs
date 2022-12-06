namespace board {
    internal class Board {
        public int Lines { get; private set; }
        public int Columns { get; private set; }
        private Piece[,] pieces;

        public Board(int lines, int columns) {
            Lines = lines;
            Columns = columns;
            pieces = new Piece[Lines, Columns];
        }

        // Getter to get a specific piece from the board
        public Piece GetPiece(int line, int column) {
            return pieces[line, column];
        }

        public void AddPiece(Piece piece, Position position) {
            pieces[position.Line, position.Column] = piece;
            piece.SetPosition(position);
        }

    }
}
