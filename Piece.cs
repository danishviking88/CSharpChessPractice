using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpChessRemake
{
    public abstract class Piece
    {
        private GlobalVars.PieceType type;
        private int startingPosition;
        private int currentPosition;
        private GlobalVars.PieceColor color;
        private bool[] potentialMoves;
        public string textIcon;
        // I wonder if there is value is having a "previousPosition"? in order to rewind a board state?
        // Or perhaps every piece should have an ArrayList of its positions through the game,
        // in order to rewind the game to any give state? Just a thought. Might be impressive to implement. 


        public Piece(int startingPosition, GlobalVars.PieceColor color) 
        {
            this.type = GlobalVars.PieceType.UNASSIGNED;
            this.startingPosition = startingPosition;
            this.currentPosition = this.startingPosition;
            this.color = color;
            this.potentialMoves = new bool[64];
            this.resetPotentialMoves();
            this.textIcon = "";
        }


        public abstract void recordPiecePotentialMoves(Chessboard board);

        public void resetPotentialMoves()
        {
            for (int i = 0; i < GlobalVars.NUM_OF_SQUARES; i++)
            {
                this.potentialMoves[i] = false;    
            }
        }


        // Getters and setters.
        public int getCurrentHorPos() 
        {
            return this.currentPosition % 8;
        }


        public int getCurrentVertPos() 
        {
            return (int)Math.Truncate((double)this.currentPosition / 8);
        }


        public int getCurrentPosition()
        {
            return this.currentPosition;
        }
        

        public void setCurrentPosition(int squareNumber)
        {
            // TODO, need to pass information to update the current position after a move. 
            this.currentPosition = squareNumber;
        }


        public GlobalVars.PieceType getPieceType()
        {
            return this.type;
        }


        public void setPieceType(GlobalVars.PieceType type)
        {
            this.type = type;
        }


        public void addSinglePotentialMove(int square)
        {
            this.potentialMoves[square] = true;
        }


        public GlobalVars.PieceColor getColor()
        {
            return this.color;
        }


        public int getStartingPosition()
        {
            return this.startingPosition;
        }
        
    }
}
