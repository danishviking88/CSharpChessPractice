using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpChessRemake
{
    public class King : Piece
    {
        private int pointValue;


        public King(int startingPosition, GlobalVars.Color color) : base(startingPosition, color)
        {
            this.pointValue = 0;
            if (this.getColor() == GlobalVars.Color.White)
            {
                this.textIcon = "K";
            }
            else
            {
                this.textIcon = "k";
            }
            this.setPieceType(GlobalVars.PieceType.King);
        }

      
        public override void recordPiecePotentialMoves(Chessboard board)
        {
            this.resetPotentialMovesAndCaptures();
            // NOTE: The methods that record diagonal and orthagonal moves will only record 1 square away if the piece type is King.
            PieceMoveChecks.recordPotentialDiagonalMoves(this, board);
            PieceMoveChecks.recordPotentialOrthagonalMoves(this, board);

            // Only execute if it is the active King's turn.
            if (this.getColor() == board.getWhoseTurnItIs())
            {
                this.deleteMovesPuttingKingInCheck(board);
            }
        }


        private void deleteMovesPuttingKingInCheck(Chessboard board)
        {
            GlobalVars.Color colorOfEnemyPieces = board.getOppositeOfWhoseTurnItIs();
            board.recordAllPotentialMovesAndCapturesOfOneColor(colorOfEnemyPieces);
            for (int i = 0; i < GlobalVars.NUM_OF_SQUARES; i++)
            {
                if (this.potentialMoves[i] == true && board.globalPotentialCaptures[i] == true)
                {
                    this.potentialMoves[i] = false;
                    this.potentialCaptures[i] = false;
                }
            }
        }
    }
}
