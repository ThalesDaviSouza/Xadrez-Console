using board;

namespace Chess {
    internal class King : Piece{
        private ChessMatch match;

        public King(Color color, Board board, ChessMatch match) : base(color, board) {
            this.match = match;
        }

        public override string ToString() {
            return "K";
        }

        private bool rookCanCastling(Position position) {
            Piece rook = board.GetPiece(position);
            return (rook != null) && (rook is Rook) && (rook.color == color) && (rook.MovesQuantity == 0);
        }

        public override bool[,] PossibleMoviments() {
            bool[,] possibleMoviments = new bool[board.Lines, board.Columns];

            // Up
            Position up = new Position(position.Line - 1, position.Column);
            if(board.IsValidadPosition(up) && canMove(up)) {
                possibleMoviments[up.Line, up.Column] = true;
            }

            // Northwest
            Position northwest = new Position(position.Line - 1, position.Column - 1);
            if (board.IsValidadPosition(northwest) && canMove(northwest)) {
                possibleMoviments[northwest.Line, northwest.Column] = true;
            }

            // Northeast
            Position northeast = new Position(position.Line - 1, position.Column + 1 );
            if (board.IsValidadPosition(northeast) && canMove(northeast)) {
                possibleMoviments[northeast.Line, northeast.Column] = true;
            }

            // Left
            Position left = new Position(position.Line, position.Column - 1);
            if (board.IsValidadPosition(left) && canMove(left)) {
                possibleMoviments[left.Line, left.Column] = true;
            }

            // Right
            Position right = new Position(position.Line, position.Column + 1);
            if (board.IsValidadPosition(right) && canMove(right)) {
                possibleMoviments[right.Line, right.Column] = true;
            }

            // Below
            Position below = new Position(position.Line + 1, position.Column);
            if (board.IsValidadPosition(below) && canMove(below)) {
                possibleMoviments[below.Line, below.Column] = true;
            }

            // South-West
            Position southWest = new Position(position.Line + 1, position.Column - 1);
            if (board.IsValidadPosition(southWest) && canMove(southWest)) {
                possibleMoviments[southWest.Line, southWest.Column] = true;
            }

            // South-East
            Position southEast = new Position(position.Line + 1, position.Column + 1);
            if (board.IsValidadPosition(southEast) && canMove(southEast)) {
                possibleMoviments[southEast.Line, southEast.Column] = true;
            }

            // Special Moves 
            if((MovesQuantity == 0) && (!match.Check)) {
                // Castling

                // Castling Short
                Position rookInRight = new Position(position.Line, position.Column + 3);

                if (rookCanCastling(rookInRight)) {
                    // If the two positions between King and the Rook are empty the move is valid
                    Position left1 = new Position(position.Line, position.Column + 1);
                    Position left2 = new Position(position.Line, position.Column + 2);
                    
                    if(board.GetPiece(left1) == null && board.GetPiece(left2) == null) {
                        possibleMoviments[position.Line, position.Column + 2] = true;
                    }
                }

                // Castling Long
                Position rookInLeft = new Position(position.Line, position.Column - 4);

                if (rookCanCastling(rookInLeft)) {
                    // If the three positions between King and Rook are empty the move is valid
                    Position right1 = new Position(position.Line, position.Column - 1);
                    Position right2 = new Position(position.Line, position.Column - 2);
                    Position right3 = new Position(position.Line, position.Column - 3);
                    
                    if ((board.GetPiece(right1) == null) && (board.GetPiece(right2) == null) && (board.GetPiece(right3) == null)) {
                        possibleMoviments[position.Line, position.Column - 2] = true;
                    }
                }
            }


            return possibleMoviments;
        }

    }
}
