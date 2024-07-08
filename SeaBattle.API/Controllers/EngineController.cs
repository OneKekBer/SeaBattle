using Microsoft.AspNetCore.Mvc;
using SeaBattle.API.Services;

namespace SeaBattle.API.Controllers
{
    [ApiController]
    public class EngineController : Controller
    {
        private readonly EngineService _engineService;

        public EngineController(EngineService engineService)
        {
            _engineService = engineService;
        }

        [HttpGet("/board")]
        public Task<IActionResult> GetBoard()
        {
            return Ok(_engineService.GetBoard());
        }
    }
}
