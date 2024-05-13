using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SeaBattle.Values;

public readonly struct Coordinates
{
    public int x { get; init; }
    public int y { get; init; }

    public Coordinates(int X, int Y)
    {
        x = X;
        y = Y;
    }

    public static Coordinates operator +(Coordinates coord1, Coordinates coord2)
    {
        return new Coordinates(coord1.x + coord2.x, coord1.y + coord2.y);
    }

    public void Deconstruct(out int X, out int Y) => (X, Y) = (x, y);

}
