using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpChessRemake
{
    internal class GlobalStatMethods
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
                    if (i < 10)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(i);
                }

            Console.Write("  ");

                if (i % 8 == 7)
                {
                    Console.Write("\n\n");
                }
            }
            Console.WriteLine();
        }
    }
}

