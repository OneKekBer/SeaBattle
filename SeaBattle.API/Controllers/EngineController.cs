using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EngineNamespace;
using BoardNamespace;
using SeaBattle.Engine.Interfaces;
using SeaBattle.Values;
using SeaBattle.API.Infrastructure;
using Microsoft.AspNetCore.Cors;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/seabattle")]
    [EnableCors("AllowSpecificOrigin")]
    public class GameController : ControllerBase
    {
        private readonly Board _board = new Board();
        private readonly Engine _engine;
        private readonly ILogger<GameController> _logger;

        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
            var outputHandler = new WebOutput(_board.board);
            _engine = new Engine(_board, null, outputHandler);
            _engine.Start();
            _engine.PlaceShips();
        }

        [HttpPost("shoot")]
        public async Task<IActionResult> Shoot([FromBody] Coordinates coords)
        {
            var inputHandler = new WebInput(coords);
            _engine.SetInputHandler(inputHandler); // Добавьте метод SetInputHandler в Engine

            await _engine.GetCoordinatesAsync();
            return Ok();
        }

        [HttpGet("board")]
        public IActionResult GetBoard()
        {
            _logger.LogInformation(ConvertBoardIntoArray.ConvertBoardToArray(_board.board));
            return Ok(new
            {
                board = ConvertBoardIntoArray.ConvertBoardToArray(_board.board),
            });
        }
    }

    public class WebInput : IInput
    {
        private Coordinates _coords;

        public WebInput(Coordinates coords)
        {
            _coords = coords;
        }

        public Task<Coordinates> GetCoordinatesAsync()
        {
            return Task.FromResult(_coords);
        }
    }

    public class WebOutput : IOutput
    {
        private readonly Panel[,] _board;

        public WebOutput(Panel[,] board)
        {
            _board = board;
        }

        public void DisplayBoard()
        {
            return;
        }
    }
}
