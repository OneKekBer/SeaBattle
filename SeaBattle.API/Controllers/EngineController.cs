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
        private readonly GameLogicService _gameLogicService;
        private readonly ILogger<GameController> _logger;

        public GameController(GameLogicService engine, ILogger<GameController> logger)
        {
            _gameLogicService = engine;
            _logger = logger;
        }

        [HttpPost("shoot")]
        public async Task<IActionResult> Shoot([FromBody] CoordinateDTO coords)
        {
            await _gameLogicService.SendCoordsToWebInput(new Coordinates(coords.x, coords.y));

            PanelState panelStateAfterShoot = await _gameLogicService.engine.HandleSendingCoordiantesAsync();
            return Ok(new   
            {
                state = panelStateAfterShoot.ToString() // logic of board was rebuilded,
                                                        // now user didnt get board, only information about panel which was shooted
            });
        }

        [HttpPut("restart")]
        public IActionResult RestartGame()
        {
            _gameLogicService.RestartGame();
            return Ok();
        }
    }

     
}
