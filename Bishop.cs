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

        public Bishop(int startingPosition, GlobalVars.PieceColor color) : base(startingPosition, color)
        {
            this.pointValue = 3;
            this.textIcon = "Bi";
            this.setPieceType(GlobalVars.PieceType.Bishop);
        }


        public override void recordPiecePotentialMoves(Chessboard board)
        {
            this.resetPotentialMoves();
            PieceMoveChecks.recordPotentialDiagonalMoves(this, board);
        }
    }
}
