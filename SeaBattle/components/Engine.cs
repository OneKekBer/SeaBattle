using System;
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
        Board board;
        IInput inputHandler;

        public Engine(Board Board, IInput InputHandler)
        {
            //inputHanlder
            board = Board;
            inputHandler = InputHandler;
        }
        // использовать индексаторы с бордой 

        public void Turn()
        {
            (int x, int y) userCoords = inputHandler.GetCoordinates();
            ShootToTtile(userCoords);
            board.PrintBoard();
        }

        public void ShootToTtile((int x, int y) coords)
        {
            var currentPanel = board[(coords.y, coords.x)];

            if (currentPanel.panelState == PanelState.ContainsShip)
            {
                HitShip(currentPanel, coords);
                return;
            }
            else if (currentPanel.panelState == PanelState.Empty)
            {
                Console.WriteLine("Miss");
                currentPanel.panelState = PanelState.Shooted;
            }
            else
            {
                Console.WriteLine("You already shooted at this title!");
            }
        }

        public void HitShip(Panel currentPanel, (int x, int y) userCoords)
        {
            var ship = currentPanel.ship;
            Console.WriteLine($"You hit {ship.Name}");
            ship.AddHit();

            if (ship.IsDestroyed)
            {
                //потом окружить корбаль (x)
                Console.WriteLine($"Ship {ship.Name} destroyed!!");
            }
            currentPanel.panelState = PanelState.Shooted;
        }

        public void Start()
        {
            ShipPlacer shipPlacer = new ShipPlacer(board);
            board.FillBoard();

            shipPlacer.PlaceShip(new Cruiser());
            shipPlacer.PlaceShip(new Cruiser());
            shipPlacer.PlaceShip(new Cruiser());

            board.PrintBoard();

            
            //foreach ((int x, int y) coords in allShipsPositions
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
