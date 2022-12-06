namespace board {
    internal class Piece {
        public Position position { get; private set; }
        public Color color { get; protected set; }
        public int MovesQuantity { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Position position, Color color, int movesQuantity, Board board) {
            this.position = position;
            this.color = color;
            this.MovesQuantity = movesQuantity;
            this.board = board;
        }
    }
}
