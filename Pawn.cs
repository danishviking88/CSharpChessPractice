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

        public Pawn(int startingPosition, GlobalVars.PieceColor color) : base(startingPosition, color)
        {
            this.pointValue = 1;
            this.textIcon = "Pa";
            this.setPieceType(GlobalVars.PieceType.Pawn);
        }


        public override void recordPiecePotentialMoves(Chessboard board)
        {
            this.resetPotentialMoves();
            PieceMoveChecks.recordPotentialPawnMoves(this, board);
        }



    }
}
