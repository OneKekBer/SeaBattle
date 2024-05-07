


using EngineNamespace;

using SeaBattle.Input.inputHandler;
using System.Text;

class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Engine engine = new Engine();

        engine.Start();
    }
}