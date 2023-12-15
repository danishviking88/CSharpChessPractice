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
        public bool[] globalPotentialMoves;
        public bool[] globalPotentialCaptures;
        private GlobalVars.Color whoseTurnItIs;
        public Piece blackKingReference;
        public Piece whiteKingReference;


        // Constructor
        public Chessboard()
        {
            this.pieceBoardPositions = new Piece[64];
            this.globalPotentialMoves = new bool[64];
            this.globalPotentialCaptures = new bool[64];
            this.resetBoardToStartPositions();
            this.resetGlobalPotentialMovesAndCaptures();
            blackKingReference = this.pieceBoardPositions[4];
            whiteKingReference = this.pieceBoardPositions[60];
        }


        // Reset board to the starting game position.
        public void resetBoardToStartPositions()
        {
            // Set the current player to White.
            this.setWhoseTurnItIsToWhite();

            // Reset all squares to null, to represent an empty board.
            for (int i = 0; i < GlobalVars.NUM_OF_SQUARES; i++)
            {
                this.pieceBoardPositions[i] = null;
            }

            // Add the starting 8 pawn for both sides.
            for (int blackPawnSquare = 8; blackPawnSquare <= 15; blackPawnSquare++)
            {
                int whitePawnSquare = blackPawnSquare + 40;
                pieceBoardPositions[whitePawnSquare] = new Pawn(whitePawnSquare, GlobalVars.Color.White);
                pieceBoardPositions[blackPawnSquare] = new Pawn(blackPawnSquare, GlobalVars.Color.Black);
            }

            // Add all Black non-pawn pieces.
            pieceBoardPositions[0] = new Rook(0, GlobalVars.Color.Black);
            pieceBoardPositions[1] = new Knight(1, GlobalVars.Color.Black);
            pieceBoardPositions[2] = new Bishop(2, GlobalVars.Color.Black);
            pieceBoardPositions[3] = new Queen(3, GlobalVars.Color.Black);
            pieceBoardPositions[4] = new King(4, GlobalVars.Color.Black);
            pieceBoardPositions[5] = new Bishop(5, GlobalVars.Color.Black);
            pieceBoardPositions[6] = new Knight(6, GlobalVars.Color.Black);
            pieceBoardPositions[7] = new Rook(7, GlobalVars.Color.Black);

            // Add all White non-pawn pieces.
            pieceBoardPositions[56] = new Rook(56, GlobalVars.Color.White);
            pieceBoardPositions[57] = new Knight(57, GlobalVars.Color.White);
            pieceBoardPositions[58] = new Bishop(58, GlobalVars.Color.White);
            pieceBoardPositions[59] = new Queen(59, GlobalVars.Color.White);
            pieceBoardPositions[60] = new King(60, GlobalVars.Color.White);
            pieceBoardPositions[61] = new Bishop(61, GlobalVars.Color.White);
            pieceBoardPositions[62] = new Knight(62, GlobalVars.Color.White);
            pieceBoardPositions[63] = new Rook(63, GlobalVars.Color.White);

        }


        // Checks if the boardspace is occupied. 
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


        // Getters and Setters.
        public GlobalVars.Color getWhoseTurnItIs()
        {
            return whoseTurnItIs;
        }


        public GlobalVars.Color getOppositeOfWhoseTurnItIs()
        {
            if (this.getWhoseTurnItIs() == GlobalVars.Color.White)
            {
                return GlobalVars.Color.Black;
            }
            else 
            {
                return GlobalVars.Color.White;
            }
        }


        // Set the player to White.
        public void setWhoseTurnItIsToWhite()
        {
            this.whoseTurnItIs = GlobalVars.Color.White;
        }


        // Change whose turn it is.
        public void changeWhichPlayersTurn()
        {
            if (this.getWhoseTurnItIs() == GlobalVars.Color.White)
            {
                this.whoseTurnItIs = GlobalVars.Color.Black;
            }
            else if(this.getWhoseTurnItIs() == GlobalVars.Color.Black)
            {
                this.whoseTurnItIs = GlobalVars.Color.White;
            }
        }

        
        // Record all potential moves of the chosen color. 
        public void recordAllPotentialMovesOfOneColor(GlobalVars.Color chosenColor)
        {
            this.resetGlobalPotentialMovesAndCaptures();

            for (int i = 0; i < GlobalVars.NUM_OF_SQUARES; i++)
            {
                // Checks if there is a piece present on each square, and if its the correct color then record its moves.
                if (this.pieceBoardPositions[i] != null)
                {
                    Piece piece = this.pieceBoardPositions[i];
                    if (piece.getColor() == chosenColor)
                    {
                        piece.recordPiecePotentialMoves(this);
                        piece.addPotentialMovesToGlobal(this);
                    }
                }
            }
        }


        // Reset all globalPotentialMoves to false.
        public void resetGlobalPotentialMovesAndCaptures()
        {
            for (int i = 0; i < GlobalVars.NUM_OF_SQUARES; i++)
            {
                this.globalPotentialMoves[i] = false;
                this.globalPotentialCaptures[i] = false;
            }
        }


    }
}
