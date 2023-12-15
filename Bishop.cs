using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpChessRemake
{
    public class Bishop : Piece
    {
        private int pointValue;

        public Bishop(int startingPosition, GlobalVars.Color color) : base(startingPosition, color)
        {
            this.pointValue = 3;
            if (this.getColor() == GlobalVars.Color.White)
            {
                this.textIcon = "B";
            }
            else
            {
                this.textIcon = "b";
            }
            this.setPieceType(GlobalVars.PieceType.Bishop);
        }


        public override void recordPiecePotentialMoves(Chessboard board)
        {
            this.resetPotentialMovesAndCaptures();
            PieceMoveChecks.recordPotentialDiagonalMoves(this, board);
        }
    }
}
