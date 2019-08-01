using System;


namespace BattleshipSimple
{
    internal class BattleShipGame
    {
        private Grid grid;

        public BattleShipGame(int gridSize)
        {
            grid = new Grid(gridSize);
            grid.populate(5);
            
        }

        internal void Reset()
        {
            grid.Reset();
        }

        //quick function to convert chars 'a' through 'z' to an int 0 - 24 (25? off by one errors always confuse me) 
        private int letterToInt(string letter)
        {
            return letter[0] - 65;
        }

        internal void Play()
        {
            while (grid.HasShipsLeft())
            {
                grid.Draw();

                //get the input from the user
                string[] raw;
                Console.WriteLine("\nEnter a coordinate in the format A:1");
                //parse it, and execute dropbomb
                raw = Console.ReadLine().Split(':');
                grid.DropBomb(Int32.Parse(raw[1]) - 1, letterToInt(raw[0]));

            }
        }
    }
}