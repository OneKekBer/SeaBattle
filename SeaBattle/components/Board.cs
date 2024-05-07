using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeaBattle.Models;
using SeaBattle.Models.Abstarcts;


namespace BoardNamespace
{
    class Board
    {
        public static Ship[,] board = new Ship[9, 9];

        public void FillBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = null;
                }
            }
        }

        public void GetItemOnTitle((int x, int y) coords)
        {
            Console.WriteLine(board[coords.y - 1, coords.x - 1]);
        }

        

        public void PrintBoard()
        {
            Console.WriteLine(" 1  2  3  4  5  6  7  8  9 ");
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for(int j = 0; j < board.GetLength(1); j++) 
                {
                    if (board[i, j] != null && board[i, j] is Ruin)
                    {
                        Console.Write(" x ");
                        continue;
                    }
                    if (board[i, j] != null)
                    {
                        Console.Write(" u ");
                        continue;
                    }
                    Console.Write(" o ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(" 1  2  3  4  5  6  7  8  9 ");
        }
    }
}
