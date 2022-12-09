using board;

namespace Chess {
    // The Knight in this game is called of Cavalier cause King and Knight starts with the same letter
    internal class Cavalier : Piece {
        public Cavalier(Color color, Board board) : base(color, board) { }

        public override string ToString() {
            return "C";
        }

        public override bool[,] PossibleMoviments() {
            bool[,] possibleMoviments = new bool[board.Lines, board.Columns];

            // Up left
            Position upLeft = new Position(position.Line - 2, position.Column - 1);
            if (board.IsValidadPosition(upLeft) && canMove(upLeft)) {
                possibleMoviments[upLeft.Line, upLeft.Column] = true;
            }
            // Up right
            Position upRight = new Position(position.Line - 2, position.Column + 1);
            if (board.IsValidadPosition(upRight) && canMove(upRight)) {
                possibleMoviments[upRight.Line, upRight.Column] = true;
            }

            // Left Up
            Position leftUp = new Position(position.Line - 1, position.Column - 2);
            if (board.IsValidadPosition(leftUp) && canMove(leftUp)) {
                possibleMoviments[leftUp.Line, leftUp.Column] = true;
            }
            // Left Down
            Position leftDown = new Position(position.Line + 1, position.Column - 2);
            if (board.IsValidadPosition(leftDown) && canMove(leftDown)) {
                possibleMoviments[leftDown.Line, leftDown.Column] = true;
            }

            // Right Up
            Position rightUp = new Position(position.Line - 1, position.Column + 2);
            if (board.IsValidadPosition(rightUp) && canMove(rightUp)) {
                possibleMoviments[rightUp.Line, rightUp.Column] = true;
            }
            // Right Down
            Position rightDown = new Position(position.Line + 1, position.Column + 2);
            if (board.IsValidadPosition(rightDown) && canMove(rightDown)) {
                possibleMoviments[rightDown.Line, rightDown.Column] = true;
            }

            // Under Left
            Position underLeft = new Position(position.Line + 2, position.Column - 1);
            if (board.IsValidadPosition(underLeft) && canMove(underLeft)) {
                possibleMoviments[underLeft.Line, underLeft.Column] = true;
            }
            // Under Right
            Position underRight = new Position(position.Line + 2, position.Column + 1);
            if (board.IsValidadPosition(underRight) && canMove(underRight)) {
                possibleMoviments[underRight.Line, underRight.Column] = true;
            }

            return possibleMoviments;
        }

    }
}
