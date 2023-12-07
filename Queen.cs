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

        public Queen(int startingPosition, GlobalVars.PieceColor color) : base(startingPosition, color)
        {
            this.pointValue = 9;
            this.textIcon = "Qu";
            this.setPieceType(GlobalVars.PieceType.Queen);
        }


        public override void recordPiecePotentialMoves(Chessboard board)
        {
            this.resetPotentialMoves();
            PieceMoveChecks.recordPotentialDiagonalMoves(this, board);
            PieceMoveChecks.recordPotentialHorizontalMoves(this, board);
            PieceMoveChecks.recordPotentialVerticalMoves(this, board);
        }
    }
}
