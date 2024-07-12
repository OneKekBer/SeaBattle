using BoardNamespace;
using EngineNamespace;
using SeaBattle.API.Controllers;
using SeaBattle.Engine.Interfaces;
using SeaBattle.Values;
using WebApp.Controllers;

namespace SeaBattle.API.Services
{
    public class EngineService
    {
        public readonly Board board = new Board();
        public readonly EngineNamespace.Engine engine;
        //public readonly WebInput _webInput;

        public EngineService()
        {
            var outputHandler = new WebOutput();
            //_webInput = webInput;
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
