


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



// нужны отдельные функции которые не будут зависить от импутов 
// сделать отдельную функцию для обработки состояния корабля при попдании 