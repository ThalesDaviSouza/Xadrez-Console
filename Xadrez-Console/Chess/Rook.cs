using board;

namespace Chess {
    internal class Rook : Piece{
        public Rook(Color color, Board board) : base(color, board) { }

        public override string ToString() {
            return "R";
        }

        public override bool[,] PossibleMoviments() {
            bool[,] possibleMoviments = new bool[board.Lines, board.Columns];

            // Up
            Position up = new Position(position.Line - 1, position.Column);
            while(board.IsValidadPosition(up) && canMove(up)) {
                possibleMoviments[up.Line, up.Column] = true;
                if((board.GetPiece(up) != null) && (board.GetPiece(up).color != this.color)) {
                    break;
                }

                up.SetLine(up.Line - 1);
            }

            // Under
            Position under = new Position(position.Line + 1, position.Column);
            while (board.IsValidadPosition(under) && canMove(under)) {
                possibleMoviments[under.Line, under.Column] = true;
                if ((board.GetPiece(under) != null) && (board.GetPiece(under).color != this.color)) {
                    break;
                }

                under.SetLine(under.Line + 1);
            }

            // Left
            Position left = new Position(position.Line, position.Column - 1);
            while (board.IsValidadPosition(left) && canMove(left)) {
                possibleMoviments[left.Line, left.Column] = true;
                if ((board.GetPiece(left) != null) && (board.GetPiece(left).color != this.color)) {
                    break;
                }

                left.SetColumn(left.Column - 1);
            }

            // Right
            Position right = new Position(position.Line, position.Column + 1);
            while (board.IsValidadPosition(right) && canMove(right)) {
                possibleMoviments[right.Line, right.Column] = true;
                if ((board.GetPiece(right) != null) && (board.GetPiece(right).color != this.color)) {
                    break;
                }

                right.SetColumn(right.Column + 1);
            }

            return possibleMoviments;
        }
    }
}
