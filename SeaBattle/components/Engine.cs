using BoardNamespace;
using SeaBattle.Components;
using SeaBattle.Engine.Interfaces;
using SeaBattle.Models;
using SeaBattle.Values;

namespace EngineNamespace
{
    public class Engine
    {
        private readonly Board _board;
        private readonly IInput _inputHandler;
        private readonly IOutput _outputHandler;

        public Engine(Board board, IInput inputHandler, IOutput outputHandler)
        {
            _board = board;
            _inputHandler = inputHandler;
            _outputHandler = outputHandler;
        }

        private void HitShip(Panel currentPanel, Coordinates userCoords)
        {
            var ship = currentPanel.Ship;
            Console.WriteLine($"You hit {ship.Name}");
            ship.AddHit();

            if (ship.IsDestroyed)
            {
                Console.WriteLine($"Ship {ship.Name} destroyed!!");
            }
            currentPanel.RegisterShot();
        }

        private void ShootToTtile(Coordinates coords)
        {
            var currentPanel = _board[coords];

            if (currentPanel.PanelState == PanelState.ContainsShip)
            {
                HitShip(currentPanel, coords);
            }
            else if (currentPanel.PanelState == PanelState.Empty)
            {
                Console.WriteLine("Miss");
                currentPanel.RegisterShot();
            }
            else
            {
                Console.WriteLine("You already shot at this tile!");
            }
        }

        public void DisplayBoard()
        {
            _outputHandler.DisplayBoard();
        }

        public async Task GetCoordinatesAsync()
        {
            Coordinates userCoords = await _inputHandler.GetCoordinatesAsync();
            ShootToTtile(userCoords);
        }

        public void PlaceShips()
        {
            ShipPlacer shipPlacer = new ShipPlacer(_board);

            shipPlacer.PlaceShip(new Cruiser());
            shipPlacer.PlaceShip(new Cruiser());
            shipPlacer.PlaceShip(new Cruiser());
        }

        public void Start()
        {
            _board.FillBoard();
            PlaceShips();
        }
    }
}
