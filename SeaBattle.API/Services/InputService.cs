using SeaBattle.Engine.Interfaces;
using SeaBattle.Values;

namespace SeaBattle.API.Services
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
}
