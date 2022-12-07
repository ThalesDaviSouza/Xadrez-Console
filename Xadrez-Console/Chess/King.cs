using board;

namespace Chess {
    internal class King : Piece{
        public King(Color color, Board board) : base(color, board) { }

        public override string ToString() {
            return "K";
        }

        public override bool[,] PossibleMoviments() {
            bool[,] possibleMoviments = new bool[board.Lines, board.Columns];

            // Up
            Position up = new Position(position.Line - 1, position.Column);
            if(board.IsValidadPosition(up) && canMove(up)) {
                possibleMoviments[up.Line, up.Column] = true;
            }

            // Northwest
            Position northwest = new Position(position.Line - 1, position.Column - 1);
            if (board.IsValidadPosition(northwest) && canMove(northwest)) {
                possibleMoviments[northwest.Line, northwest.Column] = true;
            }

            // Northeast
            Position northeast = new Position(position.Line - 1, position.Column + 1 );
            if (board.IsValidadPosition(northeast) && canMove(northeast)) {
                possibleMoviments[northeast.Line, northeast.Column] = true;
            }

            // Left
            Position left = new Position(position.Line, position.Column - 1);
            if (board.IsValidadPosition(left) && canMove(left)) {
                possibleMoviments[left.Line, left.Column] = true;
            }

            // Right
            Position right = new Position(position.Line, position.Column + 1);
            if (board.IsValidadPosition(right) && canMove(right)) {
                possibleMoviments[right.Line, right.Column] = true;
            }

            // Below
            Position below = new Position(position.Line + 1, position.Column);
            if (board.IsValidadPosition(below) && canMove(below)) {
                possibleMoviments[below.Line, below.Column] = true;
            }

            // South-West
            Position southWest = new Position(position.Line + 1, position.Column - 1);
            if (board.IsValidadPosition(southWest) && canMove(southWest)) {
                possibleMoviments[southWest.Line, southWest.Column] = true;
            }

            // South-East
            Position southEast = new Position(position.Line + 1, position.Column + 1);
            if (board.IsValidadPosition(southEast) && canMove(southEast)) {
                possibleMoviments[southEast.Line, southEast.Column] = true;
            }

            return possibleMoviments;
        }

    }
}
