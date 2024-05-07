﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoardNamespace;
using SeaBattle.Input.inputHandler;
using SeaBattle.Models.Abstarcts;
using SeaBattle.Models;
using SeaBattle.Components;

namespace EngineNamespace
{


    class Engine
    {
        Board board = new Board();
        
        public void Turn()
        {
            (int x, int y) userCoords = InputHandler.GetCoords();
            ShootToTtile(userCoords);
            board.PrintBoard();
        }

        public void ShootToTtile((int x, int y) coords)
        {
            if (Board.board[coords.y, coords.x] != null)
            {
                var ship = Board.board[coords.y, coords.x];
                Console.WriteLine("gotcha");
                HitShip(ship, coords, Board.board);
                return;
            }
            Console.WriteLine("unluck!!!");
        }

        public void HitShip(Ship ship, (int x, int y) userCoords, Ship[,] board)
        {
            if (ship.IsDestroyed)
            {
            }
            ship.AddHit();

            board[userCoords.y, userCoords.x] = new Ruin();
        }

        public void Start()
        {
            ShipPlacer shipPlacer = new ShipPlacer(Board.board);
            board.FillBoard();

            shipPlacer.PlaceShip(new Cruiser());
            shipPlacer.PlaceShip(new Cruiser());
            shipPlacer.PlaceShip(new Cruiser());

            board.PrintBoard();

            //foreach ((int x, int y) coords in allShipsPositions)
            //{
            //    Console.WriteLine((coords.x + 1, coords.y + 1));
            //}


            while (true)
            {
                Turn();
            }

        }

    }
}
