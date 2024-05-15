using SeaBattle.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Input.inputHandler
{
    public interface IInput
    {
        public Coordinates GetCoordinates();
    }
}
