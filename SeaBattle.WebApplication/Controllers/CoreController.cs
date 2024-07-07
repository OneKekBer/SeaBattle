using Microsoft.AspNetCore.Mvc;
using SeaBattle.WebApplication.Domain.Seabattle.Models;
using SeaBattle.WebApplication.Services;

namespace SeaBattle.WebApplication.Controllers
{
    [ApiController]
    [Route("/seabatlle")]
    public class CoreController : Controller
    {
        private readonly EngineService _engineService;
        public CoreController(EngineService engine) 
        {
            _engineService = engine;
        }

        [HttpPost]
        public IActionResult ShootToTitle([FromBody] CoordinatesDTO coordinatesDTO)
        {
            
            return Ok();
        }



    }
}
