using board;

namespace Chess {
    internal class Queen : Piece {
        public Queen(Color color, Board board) : base(color, board) { }

        public override string ToString() {
            return "Q";
        }

        public override bool[,] PossibleMoviments() {
            bool[,] possibleMoviments = new bool[board.Lines, board.Columns];

            // Up
            Position up = new Position(position.Line - 1, position.Column);
            while (board.IsValidPosition(up) && canMove(up)) {
                possibleMoviments[up.Line, up.Column] = true;
                if ((board.GetPiece(up) != null) && (board.GetPiece(up).color != this.color)) {
                    break;
                }

                up.SetLine(up.Line - 1);
            }

            // Under
            Position under = new Position(position.Line + 1, position.Column);
            while (board.IsValidPosition(under) && canMove(under)) {
                possibleMoviments[under.Line, under.Column] = true;
                if ((board.GetPiece(under) != null) && (board.GetPiece(under).color != this.color)) {
                    break;
                }

                under.SetLine(under.Line + 1);
            }

            // Left
            Position left = new Position(position.Line, position.Column - 1);
            while (board.IsValidPosition(left) && canMove(left)) {
                possibleMoviments[left.Line, left.Column] = true;
                if ((board.GetPiece(left) != null) && (board.GetPiece(left).color != this.color)) {
                    break;
                }

                left.SetColumn(left.Column - 1);
            }

            // Right
            Position right = new Position(position.Line, position.Column + 1);
            while (board.IsValidPosition(right) && canMove(right)) {
                possibleMoviments[right.Line, right.Column] = true;
                if ((board.GetPiece(right) != null) && (board.GetPiece(right).color != this.color)) {
                    break;
                }

                right.SetColumn(right.Column + 1);
            }

            // Up and Left
            Position upLeft = new Position(position.Line - 1, position.Column - 1);
            while (board.IsValidPosition(upLeft) && canMove(upLeft)) {
                possibleMoviments[upLeft.Line, upLeft.Column] = true;
                if ((board.GetPiece(upLeft) != null) && (board.GetPiece(upLeft).color != this.color)) {
                    break;
                }

                upLeft.SetLine(upLeft.Line - 1);
                upLeft.SetColumn(upLeft.Column - 1);
            }

            // Up and Right
            Position upRight = new Position(position.Line - 1, position.Column + 1);
            while (board.IsValidPosition(upRight) && canMove(upRight)) {
                possibleMoviments[upRight.Line, upRight.Column] = true;
                if ((board.GetPiece(upRight) != null) && (board.GetPiece(upRight).color != this.color)) {
                    break;
                }

                upRight.SetLine(upRight.Line - 1);
                upRight.SetColumn(upRight.Column + 1);
            }

            // Under and Left
            Position underLeft = new Position(position.Line + 1, position.Column - 1);
            while (board.IsValidPosition(underLeft) && canMove(underLeft)) {
                possibleMoviments[underLeft.Line, underLeft.Column] = true;
                if ((board.GetPiece(underLeft) != null) && (board.GetPiece(underLeft).color != this.color)) {
                    break;
                }

                underLeft.SetLine(underLeft.Line + 1);
                underLeft.SetColumn(underLeft.Column - 1);
            }

            // Under and Right
            Position underRight = new Position(position.Line + 1, position.Column + 1);
            while (board.IsValidPosition(underRight) && canMove(underRight)) {
                possibleMoviments[underRight.Line, underRight.Column] = true;
                if ((board.GetPiece(underRight) != null) && (board.GetPiece(underRight).color != this.color)) {
                    break;
                }

                underRight.SetLine(underRight.Line + 1);
                underRight.SetColumn(underRight.Column + 1);
            }

            return possibleMoviments;
        }
    }
}
