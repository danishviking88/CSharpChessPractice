using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpChessRemake
{
    public class GlobalVars
    {
        public enum PieceType
        {
            King,
            Queen,
            Rook,
            Bishop,
            Knight,
            Pawn,
            UNASSIGNED
        }


        public enum PieceColor
        {
            Black,
            White
        }

        public enum Direction 
        { 
            Up = -8,
            Down = 8,
            Left= -1,
            Right = 1
        }


        public const int NUM_OF_SQUARES = 64;

        public const int STARTING_16_SQUARES = 16;
    }
}
