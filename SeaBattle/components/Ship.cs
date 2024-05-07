using System;

namespace ShipNamespace
{
    public abstract class Ship
    {
        public int Size { get; protected set; }

        protected Ship(int size)
        {
            Size = size;
        }
    }

    class Craiser : Ship
    {
        public Craiser(int size) : base(size)
        {
            
        }
    }

    class Ruin : Ship
    {
        public Ruin(int size) : base(size)
        {
            
        }
    }
}

//public abstract class Ship
//{
//    public int size;
//    public bool isDestroyed;

//    public virtual void ShipWasDestroyed() 
//    {
//        isDestroyed = true;
//    }

//    public Ship(int size)
//    {
//        this.size = size;
//    }
//}
