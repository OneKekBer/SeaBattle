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
                if (int.TryParse(userInput, out int userInt))
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
