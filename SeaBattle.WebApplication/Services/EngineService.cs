using EngineNamespace;
using BoardNamespace;
using SeaBattle.Output;
using SeaBattle.Input.inputHandler;
using SeaBattle.Values;

namespace SeaBattle.WebApplication.Services
{
    class Output : IOutput
    {
        public void DisplayBoard()
        {
            throw new NotImplementedException();
        }
    }

    class Input : IInput
    {
        public Coordinates GetCoordinates()
        {
            throw new NotImplementedException();
        }
    }


    public class EngineService
    {
        static Board board = new Board();
        static Output outputHandler = new Output();
        static Input inputHandler = new Input();


        public Engine engine = new Engine(board, inputHandler, outputHandler);
    }
}
