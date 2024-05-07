using System;

namespace SeaBattle.Models.Abstarcts
{
    public abstract class Ship
    {
        private int hitCount;

        public string Name { get; init; }
        public int Size { get; init; }

        public bool IsDestroyed => hitCount == Size;

        public void AddHit()
        {
            if (IsDestroyed)
                return;
            hitCount++;
        }

        protected Ship(int size, string name)
        {
            Size = size;
            Name = name;
        }
    }
}
