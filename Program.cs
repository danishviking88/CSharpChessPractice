using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpChessRemake
{
    class Program 
    {
        public static void Main()
        {
            Chessboard board = new Chessboard();
            GlobalStatMethods.printChessboard(board);


            // for testing only, delete later
            int testSquare = 51;
            Piece piece = board.pieceBoardPositions[testSquare];
            piece.tempMethodPrintAllPotentialMoves(board);

            
            
            
        }
    }
}
