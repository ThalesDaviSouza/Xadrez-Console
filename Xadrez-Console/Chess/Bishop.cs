using board;

namespace Chess {
    internal class Bishop : Piece {
        public Bishop(Color color, Board board) : base(color, board) { }

        public override string ToString() {
            return "B";
        }

        public override bool[,] PossibleMoviments() {
            bool[,] possibleMoviments = new bool[board.Lines, board.Columns];

            // Up and Left
            Position upLeft = new Position(position.Line - 1, position.Column - 1);
            while (board.IsValidadPosition(upLeft) && canMove(upLeft)) {
                possibleMoviments[upLeft.Line, upLeft.Column] = true;
                if ((board.GetPiece(upLeft) != null) && (board.GetPiece(upLeft).color != this.color)) {
                    break;
                }

                upLeft.SetLine(upLeft.Line - 1);
                upLeft.SetColumn(upLeft.Column - 1);
            }

            // Up and Right
            Position upRight = new Position(position.Line - 1, position.Column + 1);
            while (board.IsValidadPosition(upRight) && canMove(upRight)) {
                possibleMoviments[upRight.Line, upRight.Column] = true;
                if ((board.GetPiece(upRight) != null) && (board.GetPiece(upRight).color != this.color)) {
                    break;
                }

                upRight.SetLine(upRight.Line - 1);
                upRight.SetColumn(upRight.Column + 1);
            }

            // Under and Left
            Position underLeft = new Position(position.Line + 1, position.Column - 1);
            while (board.IsValidadPosition(underLeft) && canMove(underLeft)) {
                possibleMoviments[underLeft.Line, underLeft.Column] = true;
                if ((board.GetPiece(underLeft) != null) && (board.GetPiece(underLeft).color != this.color)) {
                    break;
                }

                underLeft.SetLine(underLeft.Line + 1);
                underLeft.SetColumn(underLeft.Column - 1);
            }

            // Under and Right
            Position underRight = new Position(position.Line + 1, position.Column + 1);
            while (board.IsValidadPosition(underRight) && canMove(underRight)) {
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
