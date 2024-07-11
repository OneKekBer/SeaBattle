using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EngineNamespace;
using BoardNamespace;
using SeaBattle.Engine.Interfaces;
using SeaBattle.Values;
using SeaBattle.API.Infrastructure;
using Microsoft.AspNetCore.Cors;
using SeaBattle.API.Services;
using SeaBattle.API.Domains.Engine.Models;
using SeaBattle.API.Controllers;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/seabattle")]
    [EnableCors("AllowSpecificOrigin")]
    public class GameController : ControllerBase
    {
        private readonly EngineService _engineService;
        private readonly ILogger<GameController> _logger;

        public GameController(ILogger<GameController> logger, EngineService engine)
        {
            _engineService = engine;
            _logger = logger;
            
        }

        [HttpPost("shoot")]
        public async Task<IActionResult> Shoot([FromBody] CoordinateDTO coords)
        {
            var inputHandler = new WebInput(new Coordinates(coords.x, coords.y));
            _engineService.engine.SetInputHandler(inputHandler); // Добавьте метод SetInputHandler в Engine

            await _engineService.engine.GetCoordinatesAsync();
            return Ok();
        }

        [HttpGet("restart")]
        public IActionResult RestartGame()
        {
            _engineService.RestartGame();
            return Ok();
        }

        [HttpGet("board")]
        public IActionResult GetBoard()
        {
            _logger.LogInformation(ConvertBoardIntoArray.ConvertBoardToArray(_engineService.board.board));

            return Ok(new
            {
                board = ConvertBoardIntoArray.ConvertBoardToArray(_engineService.board.board),
            });
        }
    }

     
}
