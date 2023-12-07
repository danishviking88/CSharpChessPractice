using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpChessRemake
{
    public class PieceMoveChecks
    {

//----- Checks and records all squares to the left and right of the selected piece.  --------------------------------
        public static void recordPotentialHorizontalMoves(Piece piece, Chessboard board)
        {
            // Determine the left and rightmost squares are on the board.
            int leftEdgeSquare = piece.getCurrentPosition() - piece.getCurrentHorPos();
            int rightEdgeSquare = piece.getCurrentPosition() + (7 - piece.getCurrentHorPos());

            // Start a cursor at the start point and check potential moves to the left.
            // Stops and does not continue if a space is occupied.
            int cursor = piece.getCurrentPosition();
            while (cursor >= leftEdgeSquare)
            {
                cursor--;
                if (board.checkIfSquareIsOccupied(cursor) == false)
                {
                    piece.addSinglePotentialMove(cursor);
                }
                else
                {
                    break;
                }
            }
            // Same as above, but checks moves to right. 
            cursor = piece.getCurrentPosition();
            while (cursor <= rightEdgeSquare)
            {
                cursor++;
                if (board.checkIfSquareIsOccupied(cursor) == false)
                {
                    piece.addSinglePotentialMove(cursor);
                }
                else
                {
                    break;
                }
            }
        }


//----- Checks and records all squares vertically up and down of the selected piece. --------------------------------
        public static void recordPotentialVerticalMoves(Piece piece, Chessboard board)
        {
            int topEdgeSquare = piece.getCurrentHorPos();
            int bottomEdgeSquare = GlobalVars.NUM_OF_SQUARES - piece.getCurrentHorPos() - 2;

            // Start a cursor at the start point and check potential moves upward.
            // Stops and does not continue if a space is occupied.
            int cursor = piece.getCurrentPosition();
            while (cursor >= topEdgeSquare)
            {
                cursor -= 8;
                if (board.checkIfSquareIsOccupied(cursor) == false)
                {
                    piece.addSinglePotentialMove(cursor);
                }
                else
                {
                    break;
                }
            }
            // Same as above, but checks moves downward.
            cursor = piece.getCurrentPosition();
            while (cursor <= topEdgeSquare)
            {
                cursor += 8;
                if (board.checkIfSquareIsOccupied(cursor) == false)
                {
                    piece.addSinglePotentialMove(cursor);
                }
                else
                {
                    break;
                }
            }
        }


//----- Checks and records all squares that a Knight could move.  ------------------------------------------------
        public static void recordKnightPotentialMoves(Piece piece, Chessboard board)
        {
            int[] moveModifiers = { -17, -15, -6, 10, 17, 15, 6, -10 };
            foreach (int modifier in moveModifiers)
            {
                int potentialMove = piece.getCurrentPosition() + modifier;
                int potentialMoveHorPos = potentialMove % 8;

                // Check that the move is one of the 64 squares (between 0 and 63).
                if (potentialMove < 0 || potentialMove > 63)
                {
                    continue;
                }
                // Check if the square for the potential move it occupied. 
                else if (board.checkIfSquareIsOccupied(potentialMove) == true)
                {
                    continue;
                }
                // A check to see if the potential move crosses the left edge.
                else if (piece.getCurrentHorPos() - 2 == potentialMoveHorPos || piece.getCurrentHorPos() - 1 == potentialMoveHorPos)
                {
                    continue;
                }
                // A check to see if the potential move crosses the right edge.
                else if (piece.getCurrentHorPos() + 2 == potentialMoveHorPos || piece.getCurrentHorPos() + 1 == potentialMoveHorPos)
                {
                    continue;
                }
                else
                // Finally, record the potential move if all checks have been made. 
                {
                    piece.addSinglePotentialMove(potentialMove);
                }
            }
        }


//----- Checks and records all squares that a Bishop could move (all 4 diagonals). ----------------------------------------------
        public static void recordPotentialDiagonalMoves(Piece piece, Chessboard board)
        {
            int[] moveModifiers = { -9, -7, 9, 7 };
            for (int i = 1; i < 8; i++) 
            {
                 foreach(int modifier in moveModifiers)
                 {
                    int potentialMove = piece.getCurrentPosition() + (i * modifier);
                    int potentialMoveHorPos = potentialMove % 8;

                    // Check that the move is one of the 64 squares (between 0 and 63).
                    if (potentialMove < 0 || potentialMove > 63)
                    {
                        continue;
                    }
                    // Check if the square for the potential move it occupied. 
                    else if (board.checkIfSquareIsOccupied(potentialMove) == true)
                    {
                        continue;
                    }
                    // Checks if piece moves off edge of board one space to the left.
                    else if (piece.getCurrentHorPos() == 7 && potentialMoveHorPos == 0)
                    {
                        continue;
                    }
                    // Checks if piece moves off edge of board one space to the right.
                    else if (piece.getCurrentHorPos() == 0 && potentialMoveHorPos == 7)
                    {
                        continue;
                    }
                    else
                    // Finally, record the potential move if all checks have been made. 
                    {
                        piece.addSinglePotentialMove(potentialMove);
                    }
                 }
            }
        }


//----- Checks and records all squares that a Pawn could move. ------------------------------------------------------
        public static void potentialPawnMoves(Piece piece, Chessboard board)
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


        public static void potentialKingMoves(Piece piece, Chessboard board)
        {
            int[] moveModifier = { -9, -8, -7, -1, 1, 7, 8, 9 };

            foreach (int modifier in moveModifier)
            {
                int potentialMove = piece.getCurrentPosition() + modifier;
                int potentialMoveHorPos = potentialMove % 8;
                // Checks if potential move is actually a square on the board.
                if (potentialMove < 0 || potentialMove > 63)
                {
                    continue;
                }
                // Checks if the potential square is occupied.
                else if (board.checkIfSquareIsOccupied(potentialMove) == true)
                {
                    continue;
                }
                // Check if piece move off edge of board one spcae to the left.
                else if (piece.getCurrentHorPos() == 7 && potentialMoveHorPos == 0)
                {
                    continue;
                }
                // Checks if piece moves off edge of board one space to the right.
                else if (piece.getCurrentHorPos() == 0 && potentialMoveHorPos == 7)
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



    }
}
