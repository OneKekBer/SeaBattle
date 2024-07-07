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
using SeaBattle.Values;
using SeaBattle.Output;

namespace EngineNamespace
{
    public class Engine
    {
        Board board;
        IInput inputHandler;
        IOutput outputHandler;


        public Engine(Board Board, IInput InputHandler, IOutput OutputHandler)
        {
            board = Board;
            inputHandler = InputHandler;
            outputHandler = OutputHandler;
        }
        // использовать индексаторы с бордой 

        private void Turn()
        {
            Coordinates userCoords = inputHandler.GetCoordinates();
            ShootToTtile(userCoords);
            outputHandler.DisplayBoard();
        }

        private void ShootToTtile(Coordinates coords)
        {
            var currentPanel = board[coords];

            if (currentPanel.panelState == PanelState.ContainsShip)
            {
                HitShip(currentPanel, coords);
                return;
            }
            else if (currentPanel.panelState == PanelState.Empty)
            {
                Console.WriteLine("Miss");
                currentPanel.RegisterShot();
            }
            else
            {
                Console.WriteLine("You already shooted at this title!");
            }
        }

        private void HitShip(Panel currentPanel, Coordinates userCoords)
        {
            var ship = currentPanel.Ship;
            Console.WriteLine($"You hit {ship.Name}");
            ship.AddHit();

            if (ship.IsDestroyed)
            {
                //потом окружить корбаль (x)
                Console.WriteLine($"Ship {ship.Name} destroyed!!");
            }
            currentPanel.RegisterShot();
        }

        public void Start()
        {
            ShipPlacer shipPlacer = new ShipPlacer(board);
            board.FillBoard();

            shipPlacer.PlaceShip(new Cruiser());
            shipPlacer.PlaceShip(new Cruiser());
            shipPlacer.PlaceShip(new Cruiser());

            outputHandler.DisplayBoard();
          
            while (true)
            {
                Turn();
            }
        }
    }
}
