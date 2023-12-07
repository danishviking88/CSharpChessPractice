using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpChessRemake
{
    public class Chessboard
    {
        public Piece[] pieceBoardPositions;

        // Constructor
        public Chessboard()
        {
            this.pieceBoardPositions = new Piece[64];
            this.resetBoardToStartPositions();
        }

        public void resetBoardToStartPositions()
        {
            // Reset all squares to null, to represent an empty board.
            for (int i = 0; i < GlobalVars.NUM_OF_SQUARES; i++)
            {
                this.pieceBoardPositions[i] = null;
            }

            // Add the starting 8 pawn for both sides.
            for (int blackPawnSquare = 8; blackPawnSquare <= 15; blackPawnSquare++)
            {
                int whitePawnSquare = blackPawnSquare + 40;
                pieceBoardPositions[whitePawnSquare] = new Pawn(whitePawnSquare, GlobalVars.PieceColor.White);
                pieceBoardPositions[blackPawnSquare] = new Pawn(blackPawnSquare, GlobalVars.PieceColor.Black);
            }

            // Add all Black non-pawn pieces.
            pieceBoardPositions[0] = new Rook(0, GlobalVars.PieceColor.Black);
            pieceBoardPositions[1] = new Knight(1, GlobalVars.PieceColor.Black);
            pieceBoardPositions[2] = new Bishop(2, GlobalVars.PieceColor.Black);
            pieceBoardPositions[3] = new Queen(3, GlobalVars.PieceColor.Black);
            pieceBoardPositions[4] = new King(4, GlobalVars.PieceColor.Black);
            pieceBoardPositions[5] = new Bishop(5, GlobalVars.PieceColor.Black);
            pieceBoardPositions[6] = new Knight(6, GlobalVars.PieceColor.Black);
            pieceBoardPositions[7] = new Rook(7, GlobalVars.PieceColor.Black);

            // Add all White non-pawn pieces.
            pieceBoardPositions[56] = new Rook(56, GlobalVars.PieceColor.White);
            pieceBoardPositions[57] = new Knight(57, GlobalVars.PieceColor.White);
            pieceBoardPositions[58] = new Bishop(58, GlobalVars.PieceColor.White);
            pieceBoardPositions[59] = new Queen(59, GlobalVars.PieceColor.White);
            pieceBoardPositions[60] = new King(60, GlobalVars.PieceColor.White);
            pieceBoardPositions[61] = new Bishop(61, GlobalVars.PieceColor.White);
            pieceBoardPositions[62] = new Knight(62, GlobalVars.PieceColor.White);
            pieceBoardPositions[63] = new Rook(63, GlobalVars.PieceColor.White);

        }

        public bool checkIfSquareIsOccupied(int square)
        {
            if (this.pieceBoardPositions[square] != null)
            {
                return true;
            } 
            else
            {
                return false;
            }
        }

        // Getters and Setters
       
    }
}
