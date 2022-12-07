using System;

namespace board {
    internal class Position {
        public int Line { get; private set; }
        public int Column { get; private set; }

        public Position(int line, int column) {
            Line = line;
            Column = column;
        }

        public void SetLine(int line) {
            Line = line;
        }

        public void SetColumn(int column) {
            Column = column;
        }

        public override string ToString() {
            return $"{Line}, {Column}";
        }

    }
}
