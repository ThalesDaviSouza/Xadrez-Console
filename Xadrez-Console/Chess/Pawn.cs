using board;

namespace Chess {
    internal class Pawn : Piece {
        public Pawn(Color color, Board board) : base(color, board) { }

        public override string ToString() {
            return "P";
        }

        private bool thereIsEnemy(Position position) {
            Piece piece = board.GetPiece(position);
            return piece != null && piece.color != color;
        }

        private bool freePosition(Position position) {
            Piece piece = board.GetPiece(position);
            return (piece == null);
        }


        public override bool[,] PossibleMoviments() {
            bool[,] possibleMoviments = new bool[board.Lines, board.Columns];

            Position aux = new Position(0, 0);

            if (color == Color.White) {
                // Up
                aux.SetLine(position.Line - 1);
                aux.SetColumn(position.Column);
                if (board.IsValidadPosition(aux) && freePosition(aux)) {
                    possibleMoviments[aux.Line, aux.Column] = true;
                }

                // Up 2
                aux.SetLine(position.Line - 2);
                aux.SetColumn(position.Column);
                if (board.IsValidadPosition(aux) && freePosition(aux) && MovesQuantity == 0) {
                    possibleMoviments[aux.Line, aux.Column] = true;
                }

                // Enemy in left
                aux.SetLine(position.Line - 1);
                aux.SetColumn(position.Column - 1);
                if (board.IsValidadPosition(aux) && thereIsEnemy(aux)) {
                    possibleMoviments[aux.Line, aux.Column] = true;
                }

                // Enemy in right
                aux.SetLine(position.Line - 1);
                aux.SetColumn(position.Column + 1);
                if (board.IsValidadPosition(aux) && thereIsEnemy(aux)) {
                    possibleMoviments[aux.Line, aux.Column] = true;
                }

            }
            else if (color == Color.Black) {
                // Under
                aux.SetLine(position.Line + 1);
                aux.SetColumn(position.Column);
                if (board.IsValidadPosition(aux) && freePosition(aux)) {
                    possibleMoviments[aux.Line, aux.Column] = true;
                }

                // Under 2
                aux.SetLine(position.Line + 2);
                aux.SetColumn(position.Column);
                if (board.IsValidadPosition(aux) && freePosition(aux) && MovesQuantity == 0) {
                    possibleMoviments[aux.Line, aux.Column] = true;
                }

                // Enemy in left
                aux.SetLine(position.Line + 1);
                aux.SetColumn(position.Column - 1);
                if (board.IsValidadPosition(aux) && thereIsEnemy(aux)) {
                    possibleMoviments[aux.Line, aux.Column] = true;
                }

                // Enemy in right
                aux.SetLine(position.Line + 1);
                aux.SetColumn(position.Column + 1);
                if (board.IsValidadPosition(aux) && thereIsEnemy(aux)) {
                    possibleMoviments[aux.Line, aux.Column] = true;
                }
            }

            return possibleMoviments;
        }

    }
}
