using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpChessRemake
{
    public class PieceMoveChecks
    {
        // Checks and records all squares that a Rook could move (all 4 directions). ----------------------------------------------
        public static void recordPotentialOrthagonalMoves(Piece piece, Chessboard board)
        {
            int[] moveModifiers = { -8, -1, 8, 1 };
            foreach (int modifier in moveModifiers)
            {
                PieceMoveChecks.recordAllMovesInDirectionOfModifier(piece, board, modifier);
            }
        }


        // Checks and records all squares that a Bishop could move (all 4 diagonals). ----------------------------------------------
        public static void recordPotentialDiagonalMoves(Piece piece, Chessboard board)
        {
            int[] moveModifiers = { -9, -7, 9, 7 };

            foreach (int modifier in moveModifiers)
            {
                PieceMoveChecks.recordAllMovesInDirectionOfModifier(piece, board, modifier);
            }
        }


        // Record potential Knight Moves ------------------------------------------------------------------------------
        public static void recordPotentialKnightMoves(Piece piece, Chessboard board)
        {
            int[] moveModifiers = { -15, -6, 10, 17, 15, 6, -10, -17 };

            foreach (int modifier in moveModifiers)
            {
                Nullable<int> potentialMove = piece.getCurrentPosition() + modifier;
                Nullable<int> potentialMoveHorPos = potentialMove % 8;

                if (potentialMove < 0 || potentialMove > 63)
                {
                    continue;
                }
                else if (piece.getCurrentHorPos() == 0 && (potentialMoveHorPos == 6 || potentialMoveHorPos == 7))
                {
                    continue;
                }
                else if (piece.getCurrentHorPos() == 1 && potentialMoveHorPos == 7) 
                {
                    continue;
                }
                else if (piece.getCurrentHorPos() == 7 && (potentialMoveHorPos == 0 || potentialMoveHorPos == 1))
                {
                    continue;
                }
                else if (piece.getCurrentHorPos() == 6 && potentialMoveHorPos == 0)
                {
                    continue;
                }
                else if (board.checkIfSquareIsOccupied(potentialMove) == true)
                {
                    Piece pieceInOccupiedSquare = board.pieceBoardPositions[(int)potentialMove];
                    if (piece.getColor() != pieceInOccupiedSquare.getColor())
                    {
                        piece.addSinglePotentialMove((int)potentialMove);
                        piece.addSinglePotentialCapture((int)potentialMove);
                    }
                    continue;
                }
                else
                {
                    piece.addSinglePotentialMove((int)potentialMove);
                }
            }
        }


        // Checks and records all squares that a Pawn could move. ------------------------------------------------------
        public static void recordPotentialPawnMoves(Piece piece, Chessboard board)
            {
            // Create a move modifier that defaults to a White Pawn's movement direction.
            // The if-statement changes the modifier to the other direction if the Pawn is Black.
            int moveModifier = -8;
            if (piece.getColor() == GlobalVars.Color.Black)
            {
                moveModifier = 8;
            }

            int spaceDirectlyForward = (int)piece.getCurrentPosition() + moveModifier;
            // Checks pawn is in bounds.
            if (spaceDirectlyForward >= 0 && spaceDirectlyForward <= 63)
            {
                // Check if space directly forward is unoccupied. 
                if ((board.checkIfSquareIsOccupied(spaceDirectlyForward) == false))
                {
                    piece.addSinglePotentialMove(spaceDirectlyForward);
                }

                // Checks if capture diagonal forward and to the right is occupied, and if move goes off right edge.
                if (board.checkIfSquareIsOccupied(spaceDirectlyForward + 1) == true && (spaceDirectlyForward + 1) % 8 != 0)
                {
                    piece.addSinglePotentialMove(spaceDirectlyForward + 1);
                    piece.addSinglePotentialCapture(spaceDirectlyForward + 1);
                }

                // Checks if capture diagonal forward and to the left is occupied, and if move goes off left edge.
                if (board.checkIfSquareIsOccupied(spaceDirectlyForward - 1) == true && (spaceDirectlyForward - 1) % 8 != 7)
                {
                    piece.addSinglePotentialMove(spaceDirectlyForward - 1);
                    piece.addSinglePotentialCapture(spaceDirectlyForward - 1);
                } 

                // If the pawn is at starting position and the forward two spaces are empty, allow En Passant.
                if (piece.getCurrentPosition() == piece.getStartingPosition())
                {
                    if (board.checkIfSquareIsOccupied(spaceDirectlyForward) == false && board.checkIfSquareIsOccupied(spaceDirectlyForward + moveModifier) == false)
                    {
                        piece.addSinglePotentialMove(spaceDirectlyForward  + moveModifier);
                    }
                }
                // There is a section that will need to be added here
                // I need to write a section allowing pawn to pawn capture if an En Passant has occured on last turn.
                // Initial thoughts would be check to the left and right of this pawn for another pawn, then see if En Passant happened.
            }          
        }


        // Checks if a move is in bounds on the board. ---------------------------------------------------------------------------
        public static bool isMoveInBounds(Piece piece, int potentialMove) 
        {
            int potentialMoveHorPos = potentialMove % 8;
            int potentialMoveVertPos = (int)Math.Truncate((double)potentialMove / 8);

            // If potential move is smaller than 0 or bigger than 63, it is off the board.
            if (potentialMove < 0 || potentialMove > 63)
            {
                return false;
            }
            else if (piece.getCurrentVertPos() == potentialMoveVertPos)
            {
                return true;
            }
            else if (piece.getCurrentHorPos() + piece.getCurrentVertPos() == (potentialMoveHorPos + potentialMoveVertPos))

            {
                return true;
            }
            // If potential move is smaller, but Horizontal position is higher, an off the edge occurence has happened. 
            else if (potentialMove < piece.getCurrentPosition() && potentialMoveHorPos > piece.getCurrentHorPos())
            {
                return false;
            }
            // If potential move is bigger, but Horizontal position is lower, an off the edge occurence has happened. 
            else if (potentialMove > piece.getCurrentPosition() && potentialMoveHorPos < piece.getCurrentHorPos())
            {
                return false;
            }
            else
            {
                return true;
            }

        }


        // This checks all moves and records them starting on the current position and towards the direction of the modifier. 
        public static void recordAllMovesInDirectionOfModifier(Piece piece, Chessboard board, int modifier)
        {
            for (int i = 1; i < 8; i++)
            {
                int potentialMove = (int)piece.getCurrentPosition() + (i * modifier);
                int potentialMoveHorPos = potentialMove % 8;

                // Check if piece move is in bounds of the board.
                if (PieceMoveChecks.isMoveInBounds(piece, potentialMove) == false)
                {
                    break;
                }
                // Check if the square for the potential move it occupied. 
                else if (board.checkIfSquareIsOccupied(potentialMove) == true)
                {
                    Piece pieceInOccupiedSquare = board.pieceBoardPositions[potentialMove];
                    if (piece.getColor() != pieceInOccupiedSquare.getColor())
                    {
                        piece.addSinglePotentialMove(potentialMove);
                        piece.addSinglePotentialCapture(potentialMove);
                    }
                    break;
                }
                // Finally, record the potential move if all checks have been made. 
                else
                {
                    piece.addSinglePotentialMove(potentialMove);
                }

                // If the piece is a King, break after 1 for-loop cycle so that it only records in each direction once.
                if (piece.getPieceType() == GlobalVars.PieceType.King)
                {
                    break;
                }
                // This is a bit of goofy coding, but this was added have a Bishop stop once it hits the left or right edge.
                else if (piece.getPieceType() == GlobalVars.PieceType.Bishop && (potentialMoveHorPos == 0 || potentialMoveHorPos == 7))
                {
                    break;
                }
                // Same as above, but affecting the Queen in order to prevent off the board left or right edge movement.
                else if (piece.getPieceType() == GlobalVars.PieceType.Queen && (potentialMoveHorPos == 0 || potentialMoveHorPos == 7))
                {
                    break;
                }
            }
        }


        public static bool checkIfActiveKingIsInCheck(Chessboard board)
        {
            // Determine which King is the active king.
            Piece king;
            if (board.getWhoseTurnItIs() == GlobalVars.Color.White)
            {
                king = board.whiteKingReference;
            }
            else
            {
                king = board.blackKingReference;
            }

            // Record all the potential moves of the opposite color
            board.recordAllPotentialMovesAndCapturesOfOneColor(board.getOppositeOfWhoseTurnItIs());
            
            // Check if the King is in check.
            if (board.globalPotentialCaptures[(int)king.getCurrentPosition()] == true)
            {
                return true;
            }

            return false;
        }


    }
}
