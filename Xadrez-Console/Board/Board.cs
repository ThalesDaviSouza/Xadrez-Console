namespace board {
    internal class Board {
        public int Lines { get; private set; }
        public int Columns { get; private set; }
        private Piece[,] pieces;

        public Board(int lines, int columns) {
            if(lines <= 0 || columns <= 0) {
                throw new BoardException("Error creating board!");
            }

            Lines = lines;
            Columns = columns;
            pieces = new Piece[Lines, Columns];
        }

        // Getter to get a specific piece from the board
        public Piece GetPiece(int line, int column) {
            ValidatePosition(line, column);

            return pieces[line, column];
        }
        public Piece GetPiece(Position position) {
            ValidatePosition(position);

            return pieces[position.Line, position.Column];
        }

        public void AddPiece(Piece piece, Position position) {
            ValidatePosition(position);

            if (ThereIsPiece(position)) {
                throw new BoardException("There is a piece in this place!");
            }
            pieces[position.Line, position.Column] = piece;
            piece.SetPosition(position);
        }


        public bool ThereIsPiece(Position position) {
            ValidatePosition(position);
            
            if(pieces[position.Line, position.Column] == null) {
                return false;
            }
            return true;
        }

        public Piece? RemovePiece(Position position) {
            if (ThereIsPiece(position)) {
                Piece removed = pieces[position.Line, position.Column];
                pieces[position.Line, position.Column] = null;
                return removed;
            }

            return null;
        }

        // Exceptions Methods
        // Position Exceptions
        public bool IsValidadPosition(Position position) {
            // Validanting the Line number
            if(position.Line < 0 || position.Line >= Lines) {
                return false;
            }

            // Validanting the Column number
            if (position.Column < 0 || position.Column >= Columns) {
                return false;
            }

            return true;
        }

        public void ValidatePosition(Position position) {
            if (!IsValidadPosition(position)) {
                throw new BoardException("Invalid position!");
            }
        }
        public void ValidatePosition(int line, int column) {
            if (!IsValidadPosition(new Position(line, column))) {
                throw new BoardException("Invalid position!");
            }
        }

    }
}
