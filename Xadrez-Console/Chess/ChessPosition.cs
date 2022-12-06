using board;

namespace Chess {
    internal class ChessPosition {
        public int Line { get; private set; }
        public char Column { get; private set; }

        public ChessPosition(char column, int line) {
            Line = line;
            Column = column;
        }

        public Position toPosition() {
            return new Position(8 - Line, Column - 'a');
        }


        public override string ToString() {
            return $"{Column}{Line}";
        }
    }
}
