using BoardNamespace;
using EngineNamespace;
using SeaBattle.Engine.Interfaces;
using SeaBattle.Values;
using WebApp.Controllers;

namespace SeaBattle.API.Services
{
    public class GameLogicService
    {
        public readonly Board board = new Board();
        public readonly EngineNamespace.Engine engine;
        public readonly WebInput _webInput;

        public GameLogicService(WebInput webInput)
        {
            _webInput = webInput;
            engine = new EngineNamespace.Engine(board, _webInput, null);
        }

        public async Task SendCoordsToWebInput(Coordinates coordinates)
        {
            await _webInput.GetCoordinatesFromController(coordinates);
        }

        public void StartGame()
        {
            engine.Start();
        }

    }
}
