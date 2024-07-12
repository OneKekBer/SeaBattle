using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EngineNamespace;
using BoardNamespace;
using SeaBattle.Engine.Interfaces;
using SeaBattle.Values;
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

        public GameController(EngineService engine, ILogger<GameController> logger)
        {
            _engineService = engine;
            _logger = logger;
            
        }

        [HttpPost("shoot")]
        public async Task<IActionResult> Shoot([FromBody] CoordinateDTO coords)
        {
            var inputHandler = new WebInput(new Coordinates(coords.x, coords.y));
            _engineService.engine.SetInputHandler(inputHandler); // Добавьте метод SetInputHandler в Engine

            PanelState panelStateAfterShoot = await _engineService.engine.GetCoordinatesAsync();
            return Ok(new   
            {
                state = panelStateAfterShoot.ToString() // logic of board was rebuilded,
                                                        // now user didnt get board, only information about panel which was shooted
            });
        }

        [HttpPut("restart")]
        public IActionResult RestartGame()
        {
            _engineService.RestartGame();
            return Ok();
        }
    }

     
}
