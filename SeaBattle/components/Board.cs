using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeaBattle.Models;
using SeaBattle.Models.Abstarcts;


public enum PanelState
{
    Empty = 0,
    ContainsShip = 1,
    Shooted = 2
}

namespace BoardNamespace
{
    class Panel 
    {
        public PanelState panelState = PanelState.Empty;

        public Ship ship;
    }
            
    class Board
    {
        // переделать борду так чтобы это был не Ship[] лучше использовать панели(одна клетка на поле)
        public Panel[,] board = new Panel[9, 9];

        public Panel this[(int x, int y) coords]
        {
            get => board[coords.y, coords.x];
            set => board[coords.y, coords.x] = value;
        }

        public void FillBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = new Panel();
                }
            }
        }

        public void GetItemOnTitle((int x, int y) coords)
        {
            Console.WriteLine(board[coords.y - 1, coords.x - 1].panelState);
        }

        public void PrintBoard()
        {
            Console.WriteLine(" 1  2  3  4  5  6  7  8  9 ");
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for(int j = 0; j < board.GetLength(1); j++) 
                {
                    if (board[i, j].panelState == PanelState.Shooted)
                    {
                        Console.Write(" x ");
                        continue;
                    }
                    if (board[i, j].panelState == PanelState.ContainsShip)
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
