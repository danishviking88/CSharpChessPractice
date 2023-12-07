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

        public Knight(int startingPosition, GlobalVars.PieceColor color) : base(startingPosition, color)
        {
            this.pointValue = 3;
            this.textIcon = "Kn";
            this.setPieceType(GlobalVars.PieceType.Knight);
        }

        public override void recordPiecePotentialMoves(Chessboard board)
        {
            this.resetPotentialMoves();
            PieceMoveChecks.recordKnightPotentialMoves(this, board);
        }


        
    }
}

