


using EngineNamespace;

using SeaBattle.Input.inputHandler;
using System.Text;

using BoardNamespace;
class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        IInput inputHandler = new ConsoleInput();

        Engine engine = new Engine(new Board(), inputHandler);

        engine.Start();
    }
}



// нужны отдельные функции которые не будут зависить от импутов 
// сделать отдельную функцию для обработки состояния корабля при попдании 