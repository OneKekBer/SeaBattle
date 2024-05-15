using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeaBattle.Models;
using SeaBattle.Models.Abstarcts;
using SeaBattle.Values;

public enum PanelState
{
    Empty = 0,
    ContainsShip = 1,
    Shooted = 2,
    Miss = 3
}

namespace BoardNamespace
{
    public class Panel 
    {
        public PanelState panelState { get; private set; } = PanelState.Empty;
        public Ship Ship { get; set; } 

        public void PlaceShip(Ship ship)
        {
            if (Ship is not null) 
                throw new Exception("");
            panelState = PanelState.ContainsShip;
            Ship = ship;
        }

        public void RegisterShot()
        {
            if(Ship is not null)
                panelState = PanelState.Shooted;
            else 
                panelState = PanelState.Miss;
        }
    }

    public class Board
    {
        // переделать борду так чтобы это был не Ship[] лучше использовать панели(одна клетка на поле)
        public Panel[,] board = new Panel[9, 9];

        public Panel this[Coordinates coords]
        {
            get => board[coords.Y, coords.X];
            set => board[coords.Y, coords.X] = value;
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

        public void GetItemOnTitle(Coordinates coords)
        {
            Console.WriteLine(board[coords.Y - 1, coords.X - 1].panelState);
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
