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
        public static Ship[,] board = new Ship[9, 9];

        

        //public void PlaceShip(Ship ship)
        //{
        //    (int x, int y)[] allDirections = { (1, 0), (0, 1), (-1, 0), (0, -1) };

        //    Console.WriteLine();

        //    (int x, int y) randomCords = (random.Next(0, board.GetLength(0)), random.Next(0, board.GetLength(0)));

        //    Console.WriteLine("random coords 42 " + randomCords);

        //    List<(int x, int y)> cache = new List<(int x, int y)>();



        //    if(board[randomCords.y, randomCords.x] == null) GenerateNewCoords(ref randomCords);

        //    board[randomCords.y, randomCords.x] = ship;

        //    int counter = 0; // для смены направления корбалей
        //    int oneShipCounter = 0; // для постепенного увелечения корабля 

        //    bool mainFlag = true;
        //    bool secondFlag = true;


        //    while (mainFlag)
        //    {

        //        //обнуление 
        //        secondFlag = true;
        //        oneShipCounter = 0;

        //        if (counter > 4) GenerateNewCoords(ref randomCords);
        //        (int x, int y) currDirection = allDirections[counter];

        //        while (secondFlag)
        //        {
        //            if (oneShipCounter == ship.Size) mainFlag = false;
        //            (int x, int y) nextStep = (randomCords.x + currDirection.x * oneShipCounter, randomCords.y + currDirection.y * oneShipCounter);

        //            Console.WriteLine("next step 61 " + nextStep);

        //            if (nextStep.x >= 9 || nextStep.y >= 9 )
        //            {
        //                Console.WriteLine();
        //                Console.WriteLine("вне границ ");
        //                ClearCache(cache);
        //                counter++;
        //                secondFlag = false;
        //            }

        //            board[nextStep.y, nextStep.x] = ship;
        //            cache.Add(nextStep);
        //            oneShipCounter++;
        //        }

        //    }

        //}


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

        public void ShootToTtile((int x, int y) coords) 
        {
            if (board[coords.y - 1, coords.x - 1] != null)
            {
                board[coords.y - 1, coords.x - 1] = new Ruin(1);
                
                Console.WriteLine("gotcha");

                return;
            }
            Console.WriteLine("unluck!!!");
        }

        public void PrintBoard()
        {
            Console.WriteLine(" 1  2  3  4  5  6  7  8  9 ");
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for(int j = 0; j < board.GetLength(1); j++) 
                {
                    if (board[i, j] != null && board[i, j] is Ruin )
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
