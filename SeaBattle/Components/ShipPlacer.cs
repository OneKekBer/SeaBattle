using BoardNamespace;
using SeaBattle.Input.inputHandler;
using SeaBattle.Models.Abstarcts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Components
{
    internal class ShipPlacer
    {
        private Board board; 
        Random random = new Random();
        List<(int x, int y)> allShipsPositions = new List<(int x, int y)>();

        public ShipPlacer(Board Board)
        {
            board = Board;
        }

        public void PlaceShip(Ship ship)
        {
            (int x, int y) randomCoords = (0, 0);

            GenerateNewCoords(ref randomCoords);

            Console.WriteLine("rnd" + (randomCoords.x + 1) + " " + (randomCoords.y + 1));

            if (IsSmthInCircle(randomCoords)) GenerateNewCoords(ref randomCoords);

            board[(randomCoords.y, randomCoords.x)].ship = ship;
            board[(randomCoords.y, randomCoords.x)].panelState = PanelState.ContainsShip;

            int i = 1;
            int counter = 0;//counter for change direction

            (int x, int y)[] directions = { (0, 1), (1, 0), (-1, 0), (0, -1) };//possibile ship directions 

            List<(int x, int y)> cache = new List<(int x, int y)>();// special list like cache, which contains all cells of ship.
                                                                    // When ship impossible to place delete all cells 

            while (true)
            {
                try
                {
                    (int x, int y) currentDirection = directions[counter];

                    while (i != ship.Size)
                    {
                        (int x, int y) newCoords = (randomCoords.x + (currentDirection.x * i), randomCoords.y + (currentDirection.y * i)); // next step

                        Console.WriteLine("new " + (newCoords.x + 1) + "  " + (newCoords.y + 1));

                        if (board[(newCoords.y + currentDirection.y, newCoords.x + currentDirection.x)].panelState == PanelState.ContainsShip)
                        {
                            throw new Exception("корабль заходит на чужую зону");
                        }

                        board[(newCoords.y, newCoords.x)].ship = ship;
                        board[(randomCoords.y, randomCoords.x)].panelState = PanelState.ContainsShip;

                        cache.Add(newCoords);// можно потом добавлять корабль 
                        i++;
                    }
                    break;
                }   
                catch
                {
                    ClearCache(cache);

                    Console.WriteLine("index error");

                    i = 0;
                    counter += 1;
                }
            }

            allShipsPositions.Add(randomCoords);
            foreach ((int x, int y) coords in cache)
            {
                allShipsPositions.Add(coords);
            }

            Console.WriteLine("--------------END--------------");
        }

        public bool IsSmthInCircle((int x, int y) currentCoords)
        {
            (int x, int y)[] circle = [(1, 0), (-1, 0), (0, 1), (0, -1), (1, 1), (-1, 1), (1, -1), (1, 1)];

            for (int i = 0; i < circle.Length; i++)
            {
                (int x, int y) checkCoords = (currentCoords.x + circle[i].x, currentCoords.y + circle[i].y);
                Console.WriteLine(board[(3,2)]);
                try
                {
                    if (board[(checkCoords.y, checkCoords.x)].panelState == PanelState.ContainsShip) return true;
                    continue;
                }
                catch
                {
                    continue;
                }
            }
            return false;
        }


        public void PlaceShip(Ship ship)
        {
            List<(int x, int y)> options = GetShipOptions();

            foreach(var coords in options)
            {
                board[coords].panelState = PanelState.ContainsShip;
                board[coords].ship = ship;
            }
        }

        public List<(int x, int y)> GetShipOptions()
        {
            return new List<(int x, int y)>() { (2, 3) };
        }

        private ref (int x, int y) GenerateNewCoords(ref (int x, int y) oldCoords)
        {
            oldCoords = (random.Next(0, board.board.GetLength(0)), random.Next(0, board.board.GetLength(0)));
            return ref oldCoords;
        }

        private void ClearCache(List<(int x, int y)> cache)
        {
            foreach (var cords in cache)
            {
                board[(cords.y, cords.x)].panelState = PanelState.Empty;
                board[(cords.y, cords.x)].ship = null;
            }
            cache.Clear();
        }
    
    }
}
