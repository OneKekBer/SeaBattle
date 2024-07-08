using Microsoft.AspNetCore.Mvc;
using SeaBattle.WebApplication.Domain.Seabattle.Models;
using SeaBattle.WebApplication.Services;
using Microsoft.Extensions.Logging;

namespace SeaBattle.WebApplication.Controllers
{
    [ApiController]
    [Route("/seabattle")]
    public class CoreController : ControllerBase
    {
        private readonly EngineService _engineService;
        private readonly ILogger<CoreController> _logger;

        public CoreController(EngineService engineService, ILogger<CoreController> logger)
        {
            _engineService = engineService;
            _engineService.StartEngine();
            _logger = logger;
        }

        [HttpPost("shoot")]
        public IActionResult ShootToTitle([FromBody] CoordinatesDTO coordinatesDTO)
        {
            
            return Ok();
        }

        [HttpGet("board")]
        public IActionResult GetBoard()
        {
            _logger.LogInformation("Fetching the game board");
            var board = _engineService.GetBoard();

            return Ok(board);
        }
    }
}
