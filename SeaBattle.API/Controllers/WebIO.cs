using BoardNamespace;
using SeaBattle.Engine.Interfaces;
using SeaBattle.Values;

namespace SeaBattle.API.Controllers
{
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
        public void DisplayBoard()
        {
            return;
        }
    }
}
