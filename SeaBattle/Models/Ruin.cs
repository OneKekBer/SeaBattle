using SeaBattle.Models.Abstarcts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Models
{
    internal class Ruin : Ship
    {
        public const string name = "Ruin";
        public const int size = 1;
        public Ruin() : base(size, name)
        {
        }
    }
}
