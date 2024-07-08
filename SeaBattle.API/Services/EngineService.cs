using BoardNamespace;
using SeaBattle.Engine.Interfaces;
using SeaBattle.Values;

namespace SeaBattle.API.Services
{

    class GetBoard : IOutput
    {
        public void DisplayBoard()
        {
            return;
        }
    }

    class ShootToTitle : IInput
    {
        public Task<Coordinates> GetCoordinatesAsync()
        {
            throw new NotImplementedException();
        }
    }

    public class EngineService
    {
        EngineNamespace.Engine engine { get; init; }
        Board board { get; init; }
        IOutput outputHandler { get; init; }
        IInput inputHandler { get; init; }


        public EngineService()
        {
            board = new Board();
            inputHandler = new ShootToTitle();
            outputHandler = new GetBoard();
            engine = new EngineNamespace.Engine(board, inputHandler, outputHandler);
        }

        public void StartGame()
        {
            engine.Start();
        }

        public Panel[,] GetBoard()
        {
            return board.board;
        }
    }
}
