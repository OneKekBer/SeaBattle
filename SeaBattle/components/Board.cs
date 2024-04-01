using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShipNamespace;

namespace BoardNamespace
{
    class Board
    {
        Random random = new Random();

        Ship[,] board = new Ship[5, 5];
   
        public void PlaceShip(Ship ship)
        {
            int randomX = random.Next(0, board.GetLength(0));
            int randomY = random.Next(0, board.GetLength(0));

            (int x, int y) randomCoords = (randomY, randomX);

            Console.WriteLine(randomCoords);
            Console.WriteLine(ship.size);

            board[randomY, randomX] = ship;

            

            (int x, int y)[] directions = { (0, 1), (1, 0), (-1, 0), (0, -1) };

            List<(int x, int y)> deleteList = new List<(int x, int y)>();

            
            while (true) 
            {
                int i = 1;
                int counter = 0;

                try
                {
                    (int x, int y) currentDirection = directions[counter];

                    while (true)
                    {
                        if (i == ship.size )
                            break;

                        (int x, int y) newCoords = (randomY + (currentDirection.y * i), randomX + (currentDirection.x * i));
                        Console.WriteLine("NEW " + newCoords.x + " " + newCoords.y);
                        
                        board[newCoords.y, newCoords.x] = ship;

                        i++;
                    }
                    break;
                }
                catch
                {
                    
                    Console.WriteLine("index error");
                    //deleteList.Clear();
                    counter += 1;
                }
                if (i == ship.size)
                    break;
            }
        }

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

        public Ship ShootToTtile((int x, int y) coords) 
        {
            try
            {
                return board[coords.y - 1, coords.x - 1];
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Incorrect action!!! {ex}");
            }
            return null;
        }

        public void PrintBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for(int j = 0; j < board.GetLength(1); j++) 
                {
                    if (board[i, j] != null)
                    {
                        Console.Write("x \t");
                        continue;
                    }
                    Console.Write("o \t");
                }
                Console.WriteLine();
            }
        }
    }
}
