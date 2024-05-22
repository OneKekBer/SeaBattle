using BoardNamespace;
using SeaBattle.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Output
{
    public class ConsoleOutput : IOutput
    {
        Board currentBoard;
        public ConsoleOutput(Board Board)
        {
            currentBoard = Board;
        }

        public void PrintBoard()
        {
            Console.WriteLine(" 1  2  3  4  5  6  7  8  9 ");
            for (int i = 0; i < currentBoard.board.GetLength(0); i++)
            {
                for (int j = 0; j < currentBoard.board.GetLength(1); j++)
                {
                    if (currentBoard.board[i, j].panelState == PanelState.Shooted)
                    {
                        Console.Write(" x ");
                        continue;
                    }
                    if (currentBoard.board[i, j].panelState == PanelState.ContainsShip)
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

        public void DisplayBoard()
        {
            PrintBoard();
        }
    }
}
