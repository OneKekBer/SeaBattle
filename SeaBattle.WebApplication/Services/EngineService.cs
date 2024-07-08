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
            return;
        }
    }

    class Input : IInput
    {
        public Coordinates GetCoordinates()
        {
            return new Coordinates(2,3);
        }
    }


    public class EngineService
    {
        public Board board { get; init; }
        Output outputHandler { get; init; }
        Input inputHandler { get; init; }

        public Engine engine;

        public EngineService()
        {
            board = new Board();
            outputHandler = new Output();
            inputHandler = new Input();
            engine = new Engine(board, inputHandler, outputHandler);
        }

        public void StartEngine()
        {
            engine.Start();
        }

        public Panel[,] GetBoard()
        {
            return board.board;
        }

    }
}
