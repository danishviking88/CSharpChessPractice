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
            for (int i = 1; i < 8; i++)
            {
                foreach (int modifier in moveModifiers)
                {
                    int potentialMove = piece.getCurrentPosition() + (i * modifier);

                    // Check if piece move is in bounds of the board.
                    if (PieceMoveChecks.isMoveInBounds(piece, potentialMove) == false)
                    {
                        continue;
                    }
                    // Check if the square for the potential move it occupied. 
                    else if (board.checkIfSquareIsOccupied(potentialMove) == true)
                    {
                        continue;
                    }
                    // Finally, record the potential move if all checks have been made. 
                    else
                    {
                        piece.addSinglePotentialMove(potentialMove);
                    }
                }

                // If the piece is a King, break after 1 for-loop cycle so that it only records 1 orthagonal square away. 
                if (piece.getPieceType() == GlobalVars.PieceType.King)
                {
                    break;
                }

            }
        }


        // Checks and records all squares that a Bishop could move (all 4 diagonals). ----------------------------------------------
        public static void recordPotentialDiagonalMoves(Piece piece, Chessboard board)
        {
            int[] moveModifiers = { -9, -7, 9, 7 };
            for (int i = 1; i < 8; i++) 
            {
                foreach(int modifier in moveModifiers)
                {
                    int potentialMove = piece.getCurrentPosition() + (i * modifier);

                    // Check if piece move is in bounds of the board.
                    if (PieceMoveChecks.isMoveInBounds(piece, potentialMove) == false)
                    {
                        continue;
                    }
                    // Check if the square for the potential move it occupied. 
                    else if (board.checkIfSquareIsOccupied(potentialMove) == true)
                    {
                        continue;
                    }
                    else
                    // Finally, record the potential move if all checks have been made. 
                    {
                        piece.addSinglePotentialMove(potentialMove);
                    }
                }

                // If the piece is a King, break after 1 for-loop cycle so that it only records 1 diagonal square away. 
                if (piece.getPieceType() == GlobalVars.PieceType.King)
                {
                    break;
                }

            }
        }


        // Checks and records all squares that a Pawn could move. ------------------------------------------------------
        public static void recordPotentialPawnMoves(Piece piece, Chessboard board)
        {
            // Create a move modifier that defaults to a White Pawn's movement direction.
            // The if-statement changes the modifier to the other direction if the Pawn is Black.
            int moveModifier = -8;
            if (piece.getColor() == GlobalVars.PieceColor.Black)
            {
                moveModifier = 8;
            }

            int spaceDirectlyForward = piece.getCurrentPosition() + moveModifier;
            // Checks pawn is in bounds.
            if (spaceDirectlyForward >= 0 && spaceDirectlyForward <= 63)
            {
                // Check if space directly forward is unoccupied. 
                if ((board.checkIfSquareIsOccupied(spaceDirectlyForward) == false))
                {
                    piece.addSinglePotentialMove(spaceDirectlyForward);
                }
                // Checks if capture diagonal forward and to the right is occupied, and if move goes off right edge.
                else if (board.checkIfSquareIsOccupied(spaceDirectlyForward + 1) == true && (spaceDirectlyForward + 1) % 8 != 0)
                {
                    piece.addSinglePotentialMove(spaceDirectlyForward);
                }
                // Checks if capture diagonal forward and to the left is occupied, and if move goes off left edge.
                else if (board.checkIfSquareIsOccupied(spaceDirectlyForward - 1) == true && (spaceDirectlyForward - 1) % 8 != 7)
                {
                    piece.addSinglePotentialMove(spaceDirectlyForward);
                } 
                // If the pawn is at starting position and the forward two spaces are empty, allow En Passant.
                else if (piece.getCurrentPosition() == piece.getStartingPosition())
                {
                    if (board.checkIfSquareIsOccupied(spaceDirectlyForward) == false && board.checkIfSquareIsOccupied(spaceDirectlyForward + moveModifier) == false)
                    {
                        piece.addSinglePotentialMove(spaceDirectlyForward);
                    }
                }
                // There is a section that will need to be added here
                // I need to write a section allowing pawn to pawn capture if an En Passant has occured on last turn.
                // Initial thoughts would be check to the left and right of this pawn for another pawn, then see if En Passant happened.
            }          
        }


        // Record potential Knight Moves ------------------------------------------------------------------------------
        public static void recordPotentialKnightMoves(Piece piece, Chessboard board) 
        {
            int[] moveModifier = { -9, -8, -7, -1, 1, 7, 8, 9 };

            foreach (int modifier in moveModifier)
            {
                int potentialMove = piece.getCurrentPosition() + modifier;

                // Check if piece move is in bounds of the board.
                if (PieceMoveChecks.isMoveInBounds(piece, potentialMove) == false)
                {
                    continue;
                }
                //Checks if the potential square is occupied.
                else if (board.checkIfSquareIsOccupied(potentialMove) == true)
                {
                    continue;
                }
                // If it passes all checks, record the potential move.
                else
                {
                    piece.addSinglePotentialMove(potentialMove);
                }
                
            }
        }


        // Checks if a move is in bounds on the board. ---------------------------------------------------------------------------
        public static bool isMoveInBounds(Piece piece, int potentialMove) 
        {
            int potentialMoveHorPos = potentialMove % 8;

            // If potential move is smaller than 0 or bigger than 63, it is off the board.
            if (potentialMove < 0 || potentialMove > 63)
            {
                return false;
            }
            // If potential move is smaller, but Horizontal position is higher, an off the edge occurence has happened. 
            else if(potentialMove < piece.getCurrentPosition() && potentialMoveHorPos > piece.getCurrentHorPos())
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


        






    }
}
