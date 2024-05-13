using BoardNamespace;
using SeaBattle.Input.inputHandler;
using SeaBattle.Models.Abstarcts;
using SeaBattle.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public enum ShipDirections
{
    Top = 0,
    Down = 1,
    Left = 2,
    Right = 3,
}

namespace SeaBattle.Components
{
    internal class ShipPlacer
    {
        private Board board;
        Random random = new Random();
        List<Coordinates> allShipsPositions = new List<Coordinates>();

        public ShipPlacer(Board Board)
        {
            board = Board;
        }

        //public void PlaceShip(Ship ship)
        //{
        //    (int x, int y) randomCoords = (0, 0);

        //    GenerateNewCoords(ref randomCoords);

        //    Console.WriteLine("rnd" + (randomCoords.x + 1) + " " + (randomCoords.y + 1));

        //    if (IsSmthInCircle(randomCoords)) GenerateNewCoords(ref randomCoords);

        //    board[(randomCoords.y, randomCoords.x)].ship = ship;
        //    board[(randomCoords.y, randomCoords.x)].panelState = PanelState.ContainsShip;

        //    int i = 1;
        //    int counter = 0;//counter for change direction

        //    (int x, int y)[] directions = { (0, 1), (1, 0), (-1, 0), (0, -1) };//possibile ship directions 

        //    List<(int x, int y)> cache = new List<(int x, int y)>();// special list like cache, which contains all cells of ship.
        //                                                            // When ship impossible to place delete all cells 

        //    while (true)
        //    {
        //        try
        //        {
        //            (int x, int y) currentDirection = directions[counter];

        //            while (i != ship.Size)
        //            {
        //                (int x, int y) newCoords = (randomCoords.x + (currentDirection.x * i), randomCoords.y + (currentDirection.y * i)); // next step

        //                Console.WriteLine("new " + (newCoords.x + 1) + "  " + (newCoords.y + 1));

        //                if (board[(newCoords.y + currentDirection.y, newCoords.x + currentDirection.x)].panelState == PanelState.ContainsShip)
        //                {
        //                    throw new Exception("корабль заходит на чужую зону");
        //                }

        //                board[(newCoords.y, newCoords.x)].ship = ship;
        //                board[(randomCoords.y, randomCoords.x)].panelState = PanelState.ContainsShip;

        //                cache.Add(newCoords);// можно потом добавлять корабль 
        //                i++;
        //            }
        //            break;
        //        }
        //        catch
        //        {
        //            ClearCache(cache);

        //            Console.WriteLine("index error");

        //            i = 0;
        //            counter += 1;
        //        }
        //    }

        //    allShipsPositions.Add(randomCoords);
        //    foreach ((int x, int y) coords in cache)
        //    {
        //        allShipsPositions.Add(coords);
        //    }

        //    Console.WriteLine("--------------END--------------");
        //}

        //public bool IsSmthInCircle(Coordinates currentCoords)
        //{
        //    (int x, int y)[] circle = [(1, 0), (-1, 0), (0, 1), (0, -1), (1, 1), (-1, 1), (1, -1), (1, 1)];

        //    for (int i = 0; i < circle.Length; i++)
        //    {
        //        (int x, int y) checkCoords = (currentCoords.x + circle[i].x, currentCoords.y + circle[i].y);
        //        Console.WriteLine(board[(3, 2)]);
        //        try
        //        {
        //            if (board[(checkCoords.y, checkCoords.x)].panelState == PanelState.ContainsShip) return true;
        //            continue;
        //        }
        //        catch
        //        {
        //            continue;
        //        }
        //    }
        //    return false;
        //}


        public void PlaceShip(Ship ship)
        {
            List<Coordinates> options = GetShipOptions(ship);

            foreach (Coordinates coords in options)
            {
                board[coords].panelState = PanelState.ContainsShip;
                board[coords].ship = ship;
            }
        }

        public List<Coordinates> GetShipOptions(Ship ship)
        {
            Coordinates[] directions = {
                new Coordinates(0, 1),
                new Coordinates(1, 0),
                new Coordinates(-1, 0),
                new Coordinates(0, -1)
            };//possibile ship directions 

            var options = new List<Coordinates>();

            Coordinates randomCoords = new(0, 0);

            bool isShipPossibleToPlace = false;
            while (!isShipPossibleToPlace)
            {
                randomCoords = GenerateNewCoords(ref randomCoords);
                options.Add(randomCoords);

                //getting random direction
                int randomDirectionIndex = random.Next(0, directions.Length);
                Coordinates direction = directions[randomDirectionIndex];
                var (dirX, dirY) = direction;
                Console.WriteLine("direction " + dirX + " " + dirY);

                int i = 1;
                while (true)
                {
                    try
                    {
                        if (i == ship.Size)
                        {
                            isShipPossibleToPlace = true;
                            break;
                        }

                        if (board[options.Last()].panelState == PanelState.ContainsShip)
                            throw new Exception("impossible to place ship");

                        var nextCoords = GetNextStep(direction, options.Last());

                        if (IsShipAround(options, nextCoords))
                            throw new Exception("impossible to place ship");

                        options.Add(nextCoords);
                        Console.WriteLine("next coords " + nextCoords);
                        i++;
                    }
                    catch
                    {
                        options.Clear();
                        i = 1;
                        break;
                    }
                }
            }
            return options;
        }

        public bool IsShipAround(List<Coordinates> list, Coordinates currCoords)
        {
            Coordinates[] circle = [
                new Coordinates(1, 0),
                new Coordinates(-1, 0),
                new Coordinates(0, 1),
                new Coordinates(0, -1),
                new Coordinates(1, 1),
                new Coordinates(-1, 1),
                new Coordinates(1, -1),
                new Coordinates(1, 1)
            ];

            foreach(Coordinates coords in circle)
            {
                Coordinates circleCoords = currCoords + coords;
                if (board[circleCoords].panelState == PanelState.ContainsShip && !list.Contains(circleCoords))
                {
                    return true;
                }
            }
            return false;
        }

        public Coordinates GetNextStep(Coordinates direction, Coordinates currentPosition)
        {
            return direction switch
            {
                (0, 1) => new Coordinates(currentPosition.x, currentPosition.y + 1),
                (1, 0) => new Coordinates(currentPosition.x + 1, currentPosition.y),
                (-1, 0) => new Coordinates(currentPosition.x - 1, currentPosition.y),
                (0, -1) => new Coordinates(currentPosition.x, currentPosition.y - 1),
                _ => throw new Exception("bad random direction")
            };
        }

        private ref Coordinates GenerateNewCoords(ref Coordinates oldCoords)
        {
            oldCoords = new Coordinates(random.Next(0, board.board.GetLength(0)), random.Next(0, board.board.GetLength(0)));
            return ref oldCoords;
        }

        private void ClearCache(List<Coordinates> cache)
        {
            foreach (Coordinates cords in cache)
            {
                board[cords].panelState = PanelState.Empty;
                board[cords].ship = null;
            }
            cache.Clear();
        }
    
    }
}
