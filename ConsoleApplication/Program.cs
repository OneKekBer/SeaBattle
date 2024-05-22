

using BoardNamespace;
using ConsoleApplication.Input;
using ConsoleApplication.Output;
using EngineNamespace;
using SeaBattle.Input.inputHandler;
using SeaBattle.Output;
using System.Text;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Board board = new Board();

        IInput inputHandler = new ConsoleInput();
        IOutput outputHandler = new ConsoleOutput(board);
    
        Engine engine = new Engine(board, inputHandler, outputHandler);

        engine.Start();
    }
}