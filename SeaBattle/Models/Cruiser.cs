using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using SeaBattle.Models.Abstarcts;

namespace SeaBattle.Models
{
    internal class Cruiser : Ship
    {
        public const int cruiserSize = 4;
        public Cruiser() : base(cruiserSize, "Cruiser")
        {

        }
    }
}
