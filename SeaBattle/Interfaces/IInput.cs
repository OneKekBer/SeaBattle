using SeaBattle.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Engine.Interfaces
{
    public interface IInput
    {
        public Task<Coordinates> GetCoordinatesAsync();
    }
}
