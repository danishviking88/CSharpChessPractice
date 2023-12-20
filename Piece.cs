using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpChessRemake
{
    public abstract class Piece
    {

        private Nullable<int> startingPosition;
        private Nullable<int> currentPosition;
        protected bool[] potentialMoves;
        protected bool[] potentialCaptures;
        private GlobalVars.PieceType type;
        private GlobalVars.Color color;
        public string textIcon;

        // I wonder if there is value is having a "previousPosition"? in order to rewind a board state?
        // Or perhaps every piece should have an ArrayList of its positions through the game,
        // in order to rewind the game to any give state? Just a thought. Might be impressive to implement. 


        public Piece(int startingPosition, GlobalVars.Color color) 
        {
            this.startingPosition = startingPosition;
            this.currentPosition = this.startingPosition;
            this.potentialMoves = new bool[64];
            this.potentialCaptures = new bool[64];
            this.resetPotentialMovesAndCaptures();
            this.type = GlobalVars.PieceType.UNASSIGNED;
            this.color = color;
            this.textIcon = "";
        }


        // Records the piece's potential moves and stores them. 
        public abstract void recordPiecePotentialMoves(Chessboard board);


        // This adds all potential moves of this piece to the Chessboard globalPotentialMoves[] array;
        public void addPotentialMovesToGlobal(Chessboard board)
        {
            for (int i = 0; i < GlobalVars.NUM_OF_SQUARES; i++)
            {
                if (this.potentialMoves[i] == true)
                {
                    board.globalPotentialMoves[i] = true;
                }
            }
        }


        // This adds all potential moves of this piece to the Chessboard globalPotentialMoves[] array;
        public void addPotentialCapturesToGlobal(Chessboard board)
        {
            for (int i = 0; i < GlobalVars.NUM_OF_SQUARES; i++)
            {
                if (this.potentialCaptures[i] == true)
                {
                    board.globalPotentialCaptures[i] = true;
                }
            }
        }


        // Reset all Potential Moves.
        public void resetPotentialMovesAndCaptures()
        {
            for (int i = 0; i < GlobalVars.NUM_OF_SQUARES; i++)
            {
                this.potentialMoves[i] = false;   
                this.potentialCaptures[i] = false;
            }
        }


        // Getters and setters.
        public Nullable<int> getCurrentHorPos() 
        {
            return this.currentPosition % 8;
        }


        public int getCurrentVertPos() 
        {
            return (int)Math.Truncate((double)this.currentPosition / 8);
        }


        public Nullable<int> getCurrentPosition()
        {
            return this.currentPosition;
        }
        

        public void setCurrentPosition(int squareNumber)
        {
            // TODO, need to pass information to update the current position after a move. 
            this.currentPosition = squareNumber;
        }


        public void setCurrentPositionToNull()
        {
            this.currentPosition = null;
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

        public void addSinglePotentialCapture(int square)
        {
            this.potentialCaptures[square] = true;
        }


        public GlobalVars.Color getColor()
        {
            return this.color;
        }


        public Nullable<int> getStartingPosition()
        {
            return this.startingPosition;
        }

        
        public void tempMethodPrintAllPotentialMoves(Chessboard board)
        {
            this.recordPiecePotentialMoves(board);
            Console.WriteLine("--- " + this.GetType() + " ---");
            int counter = 0;
            for (int i = 0; i < GlobalVars.NUM_OF_SQUARES; i++)
            {                
                if (counter == 8)
                {
                    counter = 0;
                    Console.Write("\n");
                }

                if (this.potentialMoves[i] ==  true)
                {
                    Console.Write("X");
                }
                else
                {
                    Console.Write("+");
                }
                Console.Write(" ");
                counter++;
            }
        }
    }
}
