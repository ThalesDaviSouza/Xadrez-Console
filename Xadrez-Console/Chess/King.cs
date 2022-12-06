using board;

namespace Chess {
    internal class King : Piece{
        public King(Color color, Board board) : base(color, board) { }

        public override string ToString() {
            return "K";
        }
    }
}
