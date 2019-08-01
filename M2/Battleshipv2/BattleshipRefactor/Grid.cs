using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Written by Daniel Beckerich on 3/28/2018
//this class is designed to handle the data pertaining to the game space

namespace BattleshipSimple
{
    class Grid
    {
        //variables for parsing the different console colors
        ConsoleColor planeForground = Console.ForegroundColor;
        Dictionary<char, ConsoleColor> ShipColors = new Dictionary<char, ConsoleColor>();
        //variable for holding the master, unaltered grid.
        internal char[,] masterGrid;
        internal int size;

        //initialize the grid and put the colors in the dictionary.
        public Grid(int gridSize) {
            //load the colors into the dictionary
            ShipColors.Add('S', ConsoleColor.Blue);
            ShipColors.Add('P', ConsoleColor.Cyan);
            ShipColors.Add('A', ConsoleColor.Green);
            ShipColors.Add('B', ConsoleColor.Yellow);
            ShipColors.Add('C', ConsoleColor.Magenta);
            ShipColors.Add('.', planeForground);
            masterGrid = new char[gridSize, gridSize];
            size = gridSize;

        }

        //if it is now Hit, Miss, or '.' then 
        internal void DropBomb(int X, int Y)
        {
            if (masterGrid[X, Y] != 'H' | masterGrid[X, Y] != 'M' | masterGrid[X, Y] != '.')
            {   //than mark it as a hit.
                masterGrid[X, Y] = 'H'; 
            }
            else
            {   //else mark it as a miss
                masterGrid[X, Y] = 'M';
            }
        }

        //draws the current information from "workingGrid" onto the console. 
        public void Draw()
        {
            //first clear the console
            Console.Clear();

            //write the top letter guide
            Console.Write("  ");
            for(int i = 0; i < size; i++)
            {   //write the correct alphabetical char to the spot on the grid
                Console.Write(Convert.ToChar(65 + i));
                if(i != size - 1)
                {   //if we are not at the end, add a '-'
                    Console.Write("-");
                }

            }

            Console.WriteLine();
            //iterate through the rows
            for (int row = 0; row < size; row++)
            {
                //and columns
                for (int column = 0; column < size; column++)
                {
                    //if we are on the first column of the line, add the row number.
                    if (column == 0)
                    {
                        Console.Write("{0,2}", row + 1);
                    }

                    //if there is a hit at that location, set it to red and print an X
                    if (masterGrid[row, column] == 'H')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("X");
                        Console.ForegroundColor = planeForground;
                    }
                    else if (masterGrid[row, column] == 'M')
                    {
                        Console.Write("X");
                    }
                    //if there is a miss at the location, set the color to 
                    else
                    {

                        Console.ForegroundColor = ShipColors[masterGrid[row, column]];
                        Console.Write(masterGrid[row, column]);
                        Console.ForegroundColor = planeForground;

                    }

                    //add the last piece of the grid to the row
                    Console.Write("|");
                }
                //end the current line and print the next bar to the console.
                Console.WriteLine();
            }

            //now print the lower part of the grid.
            Console.Write("  ");
            for (int i = 0; i < size; i++)
            {
                Console.Write("#");
                if (i != size - 1)
                {
                    Console.Write("-");
                }

            }

        }

        //replace every value inside the grid with '.'
        public void Reset()
        {
            for (int row = 0; row < size; row++) {
                for (int col = 0; col < size; col++) {
                    masterGrid[row, col] = '.';
                }
            }
        }

        //checks to see if the grid has anything other than '.', 'H', or 'M' left.
        public bool HasShipsLeft()
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                   if (masterGrid[row, col] != '.' | masterGrid[row,col] != 'H' | masterGrid[row,col] != 'M' )
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //returns true if the ship will fit in the horizontal direction
        bool horizontalCheck(int x, int y, int length)
        {
            try
            {
                for (int i = 0; i < length; i++)
                {
                    if (masterGrid[x, y + i] != '.')
                    {
                        return false;
                    }
                }
                return true;
            }

            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        //returns true if the ship will fit in the vertical direction
        bool verticalCheck(int x, int y, int length)
        {
            try
            {
                for (int i = 0; i < length; i++)
                {
                    if (masterGrid[x + i, y] != '.')
                    {
                        return false;
                    }
                }
                return true;
            }

            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        //populate generates a given number of ships onto the grid in random locations.
        public void populate(int shipCount)
        {
            Reset(); //first, reset the grid to be empty.
            Random rng = new Random(); //ship placement will be random.
            int row = 0; //variables for the row and column
            int col = 0;         
            bool vertHor = false; //vert is true, hor is false.
            int shipNum = 0; //this variable holds what ship we are working on out of our total ships.
            int shipSize = 1; //shipSize holds the amount of squares the ship takes. initialized to 1 because you cant have a ship of size 0
            char shipChar = 'S'; //shipChar holds the char that the ship will be. initialized to 'S' by default.


            //iterate for each ship that needs placing.
            do
            {
                //get a random location and direction for the ship
                row = rng.Next(0, size);
                col = rng.Next(0, size);
                //generate a random true or false.
                vertHor = (rng.Next(100) >= 50);

                switch (shipNum + 1)
                {
                    case 1: shipSize = 1; shipChar = 'S'; break;
                    case 2: shipSize = 2; shipChar = 'P'; break;
                    case 3: shipSize = 3; shipChar = 'A'; break;
                    case 4: shipSize = 4; shipChar = 'B'; break;
                    case 5: shipSize = 5; shipChar = 'C'; break;
                    default: shipSize = 1; shipChar = 'S'; break;
                }
                
                //first check to see if the desired location is available
                if(masterGrid[row,col] == '.')
                {
                    //make sure the ship has room.
                    if(horizontalCheck(row,col,shipSize) == true & verticalCheck(row, col, shipSize) == true)
                    {
                        //if there is room, increment the counter. if there is not room, the counter does not get incremented.

                        for(int i = 0; i < shipSize; i++)
                        {
                            if (vertHor)
                            {
                                masterGrid[row, col + i] = shipChar;
                            }
                            else
                            {
                                masterGrid[row + i, col] = shipChar;
                            }
                        }
                        shipNum++;
                    }
                }
            } while (shipNum < shipCount);
        }
    }
}
