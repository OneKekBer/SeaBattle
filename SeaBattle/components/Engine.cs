using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoardNamespace;
using ShipNamespace;

enum EnumInputType
{
    X = 0,
    Y = 1,
}

namespace EngineNamespace
{
    class Engine
    {
        private int Input(EnumInputType type)
        {
            do
            {
                Console.WriteLine($"Enter {type}");
                string userInput = Console.ReadLine();
                if(int.TryParse(userInput, out int userInt))
                {
                    return userInt;
                }
                else 
                {
                    Console.WriteLine("Enter coordinate!");
                }  
            } while (true);
        }

        private (int x, int y) GetCoords()
        {
            int x1 = Input(EnumInputType.X);
            int y1 = Input(EnumInputType.Y);

            return (x1, y1);
        }

        public void Start()
        {
            Board board = new Board();

            board.FillBoard();

            board.PlaceShip(new Craiser(3));

            board.PrintBoard();   
            while (true)
            {
                (int x, int y) userCoords = GetCoords();

                board.GetItemOnTitle(userCoords);
            }
            
        }

    }
}
