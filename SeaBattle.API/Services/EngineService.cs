using BoardNamespace;
using EngineNamespace;
using WebApp.Controllers;

namespace SeaBattle.API.Services
{
    public class EngineService
    {
        public readonly Board board = new Board();
        public readonly EngineNamespace.Engine engine;

        public EngineService()
        {
            var outputHandler = new WebOutput(board.board);
            engine = new EngineNamespace.Engine(board, null, outputHandler);
            engine.Start();
            engine.PlaceShips();
        }

        public void RestartGame()
        {
            engine.Restart();
        }
    }
}
