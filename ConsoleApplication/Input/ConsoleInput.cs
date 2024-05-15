using SeaBattle.Input.inputHandler;
using SeaBattle.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication.Input
{
    public enum EnumInputType
    {
        X = 0,
        Y = 1,
    }

    internal class ConsoleInput : IInput
    {
        public Coordinates GetCoordinates()
        {
            // минус один изза разницы того что массив начинается с 0 
            // а доска начинается с еденицы
            int x1 = Input(EnumInputType.X) - 1;
            int y1 = Input(EnumInputType.Y) - 1;

            return new Coordinates(x1, y1);
        }

        public int Input(EnumInputType type)
        {
            do
            {
                Console.WriteLine($"Enter {type}");
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int userInt) && userInt < 9 && userInt > 0)
                {
                    return userInt;
                }
                else
                {
                    Console.WriteLine("Enter coordinate!");
                }
            } while (true);
        }
    }
}
