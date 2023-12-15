using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpChessRemake
{
    public class Pawn : Piece
    {
        private int pointValue;

        public Pawn(int startingPosition, GlobalVars.Color color) : base(startingPosition, color)
        {
            this.pointValue = 1;
            if (this.getColor() == GlobalVars.Color.White)
            {
                this.textIcon = "P";
            }
            else
            {
                this.textIcon = "p";
            }
            this.setPieceType(GlobalVars.PieceType.Pawn);
        }


        public override void recordPiecePotentialMoves(Chessboard board)
        {
            this.resetPotentialMovesAndCaptures();
            PieceMoveChecks.recordPotentialPawnMoves(this, board);
        }



    }
}
