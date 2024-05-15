

using BoardNamespace;
using ConsoleApplication.Input;
using EngineNamespace;
using SeaBattle.Input.inputHandler;
using System.Text;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        IInput inputHandler = new ConsoleInput();

        Engine engine = new Engine(new Board(), inputHandler);

        engine.Start();
    }
}