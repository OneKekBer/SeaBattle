using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Input.inputHandler
{
    public enum EnumInputType
    {
        X = 0,
        Y = 1,
    }

    public class InputHandler
    {
        public static int Input(EnumInputType type)
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

        public static (int x, int y) GetCoords()
        {
            // минус один изза разницы того что массив начинается с 0 
            // а доска начинается с еденицы
            int x1 = InputHandler.Input(EnumInputType.X) - 1;
            int y1 = InputHandler.Input(EnumInputType.Y) - 1;

            return (x1, y1);
        }


    }
}
