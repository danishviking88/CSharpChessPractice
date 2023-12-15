using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpChessRemake
{
    public class GlobalStatMethods
    {
        public static void printChessboard(Chessboard board)
        {
            for (int i = 0; i < 64; i++)
            {
                if (board.pieceBoardPositions[i] != null)
                {
                    Piece piece = board.pieceBoardPositions[i];
                    Console.Write(piece.textIcon);
                }
                else
                {
                    string space1;
                    string space2;
                    if ((i / 8) % 2 == 0)
                    {
                        space1 = "+";
                        space2 = "#";
                    }
                    else
                    {
                        space1 = "#";
                        space2 = "+";
                    }
                 
                        if (i % 2 == 0)
                    {
                        Console.Write(space1);
                    }
                    else
                    {
                        Console.Write(space2);
                    }
                }
                
                Console.Write(" ");

                if (i % 8 == 7)
                {
                    Console.Write("\n");
                }
            }
        }
    }
}

