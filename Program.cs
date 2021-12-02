using System;
using Puissance4;

namespace Puissance4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Error Exception
            //            var game = new Connect4(4, 3);
            var game = new Connect4(10, 10);


            do
            {

                Display(game);
                for (int i=0; i< game.ColCount * game.LineCount; i++ )
                {
                    Console.WriteLine($"Player {game.PlayerNumber} : Which column 1-{game.ColCount} ?");

                    var turn = Console.ReadLine();

                    int column;

                    if (int.TryParse(turn, out column))
                    {
                        if (column > game.ColCount-1)
                        {
                            Console.Error.WriteLine("Try Again : Out of Range ... Tap less than column number.");

                            break;
                        }
                        game.Play(column);
                        break;
                    }
                    Console.Error.WriteLine("Invalid column number.");

                
                }
            }
            while (!game.Ended);


            Display(game);

            if (game.Winner == 0)
            {
                Console.WriteLine("Draw");
            }
            if (game.Winner ==1)
            {
                Console.WriteLine($"Player {game.Winner} wins.");
            }
            else
            {
                Console.WriteLine($"Player {game.Winner} wins.");
            }
        }



        private static void Display(Connect4 game)
        {
            for (int y = 0; y < game.LineCount; y++)
            {

                for (int x = 0; x < game.ColCount; x++)
                {
                    Console.Write($"| {game.GetPawn(x, y)} ");
                }
                Console.WriteLine( "|");
                for (int x = 0; x < game.ColCount; x++)
                {
                    Console.Write($"+---");
                }
                Console.WriteLine("+");
            }
            for (int x = 0; x < game.ColCount; x++)
            {
                Console.Write($"  {x + 1} ");
            }
            Console.WriteLine();
        }
    }
}