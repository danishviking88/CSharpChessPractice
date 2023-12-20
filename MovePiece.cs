using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpChessRemake
{
    public class MovePiece
    {
        public static void movePiece(Piece movingPiece, int potentialMove, Chessboard board)
        {
            // Create a backup of the board in case you need to revert back (for example putting oneself in check).
            Piece[] backupPieceBoardPositions = MovePiece.createPieceArrayDeepCopy(board.pieceBoardPositions);
            
            // If space is occupied, capture the piece there.
            if (board.checkIfSquareIsOccupied(potentialMove) == true)
            {
                MovePiece.removeCapturedPiece(potentialMove, board);
            }

            // Move the piece to the potentialMove location.
            movingPiece.setCurrentPosition(potentialMove);

            if (PieceMoveChecks.checkIfActiveKingIsInCheck(board) == true)
            {
                // ********* Uh oh, the king is in check and need to revert back.
            }
        }


        public static void removeCapturedPiece(int potentialMove, Chessboard board)
        {
            board.pieceBoardPositions[potentialMove].setCurrentPositionToNull();
            board.pieceBoardPositions[potentialMove] = null;
        }


        public static Piece[] createPieceArrayDeepCopy(Piece[] pieceBoardPositions)
        {
            Piece[] backupPieceBoardPositions = new Piece[64];
            backupPieceBoardPositions = pieceBoardPositions;
            return backupPieceBoardPositions;
        }
       
    }
}
