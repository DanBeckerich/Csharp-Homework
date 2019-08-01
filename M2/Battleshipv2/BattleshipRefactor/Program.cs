using System;


namespace BattleshipSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new BattleShipGame(10);
            ConsoleKeyInfo response;
            do
            {
                game.Play();

                Console.WriteLine("Do you want to play again (y/n)");
                response = Console.ReadKey();

            } while (response.Key == ConsoleKey.Y);
            
        }
    }
}
