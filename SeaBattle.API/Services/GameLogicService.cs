using BoardNamespace;
using EngineNamespace;
using SeaBattle.API.Controllers;
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
        public readonly WebOutput _webOutput = new WebOutput();

        public GameLogicService(WebInput webInput)
        {
            _webInput = webInput;
            engine = new EngineNamespace.Engine(board, _webInput, _webOutput);
        }

        public async Task SendCoordsToWebInput(Coordinates coordinates)
        {
            await _webInput.GetCoordinatesFromController(coordinates);
        }

        public void RestartGame()
        {
            engine.Restart();
        }
    }
}
