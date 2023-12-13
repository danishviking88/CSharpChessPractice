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

        public Rook(int startingPosition, GlobalVars.PieceColor color) : base(startingPosition, color)
        {
            this.pointValue = 5;
            this.textIcon = "Ro";
            this.setPieceType(GlobalVars.PieceType.Rook);
        }


        public override void recordPiecePotentialMoves(Chessboard board)
        {
            this.resetPotentialMoves();
            PieceMoveChecks.recordPotentialOrthagonalMoves(this, board);
        }






    }
}
