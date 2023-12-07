using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpChessRemake
{
    public class King : Piece
    {
        private int pointValue;

        public King(int startingPosition, GlobalVars.PieceColor color) : base(startingPosition, color)
        {
            this.pointValue = 0;
            this.textIcon = "KI";
            this.setPieceType(GlobalVars.PieceType.King);
        }


        public override void recordPiecePotentialMoves(Chessboard board)
        {

        }
    }
}
