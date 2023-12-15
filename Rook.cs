using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpChessRemake
{
    public class Rook : Piece
    {
        private int pointValue;

        public Rook(int startingPosition, GlobalVars.Color color) : base(startingPosition, color)
        {
            this.pointValue = 5;
            if (this.getColor() == GlobalVars.Color.White)
            {
                this.textIcon = "R";
            }
            else
            {
                this.textIcon = "r";
            }
            this.setPieceType(GlobalVars.PieceType.Rook);
        }


        public override void recordPiecePotentialMoves(Chessboard board)
        {
            this.resetPotentialMovesAndCaptures();
            PieceMoveChecks.recordPotentialOrthagonalMoves(this, board);
        }






    }
}
