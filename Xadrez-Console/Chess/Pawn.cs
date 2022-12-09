using board;
using System.Runtime.Intrinsics.X86;

namespace Chess {
    internal class Pawn : Piece {
        private ChessMatch match;
        public Pawn(Color color, Board board, ChessMatch match) : base(color, board) {
            this.match = match;
        }

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

        private bool canEnPassant(Position position) {
            if (board.IsValidPosition(position) && thereIsEnemy(position) && board.GetPiece(position) == match.PieceVulnerableToEnPassant) {
                return true;
            }

            return false;
        }

        public override bool[,] PossibleMoviments() {
            bool[,] possibleMoviments = new bool[board.Lines, board.Columns];

            Position aux = new Position(0, 0);

            if (color == Color.White) {
                // Up
                aux.SetLine(position.Line - 1);
                aux.SetColumn(position.Column);
                if (board.IsValidPosition(aux) && freePosition(aux)) {
                    possibleMoviments[aux.Line, aux.Column] = true;
                }

                // Up 2
                aux.SetLine(position.Line - 2);
                aux.SetColumn(position.Column);
                if (board.IsValidPosition(aux) && freePosition(aux) && MovesQuantity == 0) {
                    possibleMoviments[aux.Line, aux.Column] = true;
                }

                // Enemy in left
                aux.SetLine(position.Line - 1);
                aux.SetColumn(position.Column - 1);
                if (board.IsValidPosition(aux) && thereIsEnemy(aux)) {
                    possibleMoviments[aux.Line, aux.Column] = true;
                }

                // Enemy in right
                aux.SetLine(position.Line - 1);
                aux.SetColumn(position.Column + 1);
                if (board.IsValidPosition(aux) && thereIsEnemy(aux)) {
                    possibleMoviments[aux.Line, aux.Column] = true;
                }

                // Special Moves
                // En Passant
                if(position.Line == 3) {
                    Position left = new Position(position.Line, position.Column - 1);
                    if (canEnPassant(left)) {
                        left.SetLine(left.Line - 1);
                        if (board.IsValidPosition(left))
                            possibleMoviments[left.Line, left.Column] = true;
                    }
                    Position right = new Position(position.Line, position.Column + 1);
                    if (canEnPassant(right)) {
                        right.SetLine(right.Line - 1);
                        if (board.IsValidPosition(right))
                            possibleMoviments[right.Line, right.Column] = true;
                    }
                }

            }
            else if (color == Color.Black) {
                // Under
                aux.SetLine(position.Line + 1);
                aux.SetColumn(position.Column);
                if (board.IsValidPosition(aux) && freePosition(aux)) {
                    possibleMoviments[aux.Line, aux.Column] = true;
                }

                // Under 2
                aux.SetLine(position.Line + 2);
                aux.SetColumn(position.Column);
                if (board.IsValidPosition(aux) && freePosition(aux) && MovesQuantity == 0) {
                    possibleMoviments[aux.Line, aux.Column] = true;
                }

                // Enemy in left
                aux.SetLine(position.Line + 1);
                aux.SetColumn(position.Column - 1);
                if (board.IsValidPosition(aux) && thereIsEnemy(aux)) {
                    possibleMoviments[aux.Line, aux.Column] = true;
                }

                // Enemy in right
                aux.SetLine(position.Line + 1);
                aux.SetColumn(position.Column + 1);
                if (board.IsValidPosition(aux) && thereIsEnemy(aux)) {
                    possibleMoviments[aux.Line, aux.Column] = true;
                }

                // Special Moves
                // En Passant
                if (position.Line == 4) {
                    Position left = new Position(position.Line, position.Column - 1);
                    if (canEnPassant(left)) {
                        left.SetLine(left.Line + 1);
                        if(board.IsValidPosition(left))
                            possibleMoviments[left.Line, left.Column] = true;
                    }
                    Position right = new Position(position.Line, position.Column + 1);
                    if (canEnPassant(right)) {
                        right.SetLine(right.Line + 1);
                        if (board.IsValidPosition(right))
                            possibleMoviments[right.Line, right.Column] = true;
                    }
                }
            }

            return possibleMoviments;
        }

    }
}
