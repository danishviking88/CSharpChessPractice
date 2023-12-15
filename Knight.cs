using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpChessRemake
{
    public class Knight : Piece
    {
        private int pointValue;

        public Knight(int startingPosition, GlobalVars.Color color) : base(startingPosition, color)
        {
            this.pointValue = 3;
            if (this.getColor() == GlobalVars.Color.White)
            {
                this.textIcon = "N";
            }
            else
            {
                this.textIcon = "n";
            }
            this.setPieceType(GlobalVars.PieceType.Knight);
        }

        public override void recordPiecePotentialMoves(Chessboard board)
        {
            this.resetPotentialMovesAndCaptures();
            PieceMoveChecks.recordPotentialKnightMoves(this, board);
        }


        
    }
}


