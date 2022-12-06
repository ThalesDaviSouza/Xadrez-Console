﻿namespace board {
    internal class Piece {
        public Position? position { get; protected set; }
        public Color color { get; protected set; }
        public int MovesQuantity { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Color color, Board board) {
            this.position = null;
            this.color = color;
            this.MovesQuantity = 0;
            this.board = board;
        }

        public void SetPosition(Position position) {
            this.position = position;
        }

    }
}