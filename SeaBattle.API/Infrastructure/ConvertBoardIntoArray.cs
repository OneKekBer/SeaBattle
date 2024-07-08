using BoardNamespace;

namespace SeaBattle.API.Infrastructure
{
    public class ConvertBoardIntoArray
    {
        public static string ConvertBoardToArray(Panel[,] board)
        {
            string convertedBoard = string.Empty;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    convertedBoard += board[i, j].PanelState + " ";
                }
            }
            return convertedBoard;
        }
    }
}
