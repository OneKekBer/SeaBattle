using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipNamespace
{
    class Ship
    {
        public int size;

        public Ship(int size)
        {
            this.size = size;
        }
    }


    class Craiser : Ship
    {
       
        public Craiser(int size) : base(size)
        {
            
        }
    }




}
