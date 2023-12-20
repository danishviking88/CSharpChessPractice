using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpChessRemake
{
    public class Queen : Piece
    {
        private int pointValue;

        public Queen(int startingPosition, GlobalVars.Color color) : base(startingPosition, color)
        {
            this.pointValue = 9;
            if (this.getColor() == GlobalVars.Color.White)
            {
                this.textIcon = "Q";
            }
            else
            {
                this.textIcon = "q";
            }
            this.setPieceType(GlobalVars.PieceType.Queen);
        }


        public override void recordPiecePotentialMoves(Chessboard board)
        {
            this.resetPotentialMovesAndCaptures();
            PieceMoveChecks.recordPotentialDiagonalMoves(this, board);
            PieceMoveChecks.recordPotentialOrthagonalMoves(this, board);
        }
    }
}
