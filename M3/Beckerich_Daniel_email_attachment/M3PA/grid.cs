using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3PA
{
    class Grid
    {
        //Grid size and contents.
        int GridSizeX;
        int GridSizeY;
        List<Ship> Contents = new List<Ship>();

        //Grid constructors
        public Grid(int X, int Y)
        {
            //if X is less or equal to 5, set it 5. else set it to X. same for Y
            GridSizeX = X <= 5 ? 5 : X;
            GridSizeY = Y <= 5 ? 5 : Y;

        }

       public Grid()
        {
            GridSizeX = 5;
            GridSizeY = 5;
        }

        public bool IsSpaceEmpty(Position newPos)
        {
            //first see if there is anything there.
            //iterate through each ship on the Grid
            for (int ship = 0; ship < Contents.Count; ship++)
            {
                //then iterate through all the locations of each ship.
                for (int shipPos = 0; shipPos < Contents[ship].locations.Count; shipPos++)
                {
                    if (newPos == Contents[ship].locations[shipPos])
                    {
                        //if there is something there, we can stop looking and return false.
                        return false;
                    }
                
                }
            }
            //return the result.
            return true;
        }

        public Ship getShipAt(Position newPos)
        {

            //first see if there is anything there.
            //iterate through each ship on the Grid
            for (int ship = 0; ship < Contents.Count; ship++)
            {
                //then iterate through all the locations of each ship.
                for (int shipPos = 0; shipPos < Contents[ship].locations.Count; shipPos++)
                {
                    if (newPos == Contents[ship].locations[shipPos])
                    {
                        //if there is something there, we can stop looking and return false.
                        return Contents[ship];
                    }

                }
            }

            return null;
        }

        public bool AddShip(Ship newShip)
        {
            bool hasRoom = false;

            //if its empty, place it anyways
            if(Contents.Count == 0)
            {
                Contents.Add(newShip);
                return true;
            }
            
            //if its not there, see if there is room
            //iterate through each ship on the Grid
            for(int i = 0; i < Contents.Count; i++)
            {
                //then iterate through all the locations of each ship.
                for(int x = 0; x < Contents[i].locations.Count; x++)
                {
                    //check the locations of the current ship with the locations of the new ship
                    for (int y = 0; y < newShip.locations.Count; y++)
                    {
                        if (newShip.locations[y] == Contents[i].locations[x])
                        {
                            hasRoom = false;
                        }
                        else
                        {

                            hasRoom = true;
                        }
                    }
                }
            }
            if (hasRoom)
            {
                //if we have room. add the ship
                Contents.Add(newShip);
                return true;
            }
            //if not, return false.
            else return false;

        }

        //draw the Grid.
        public void draw()
        {
            char currentChar = 'a';
            //define the top row.
            string topRow = " #A#B#C#D#E#F#G#H#I#J#K#L#M#N#O#P#Q#R#S#T#U#V#X#Y#Z#";

            Ship currentShip;

            //iterate through the rows
            for (int row = 0; row < GridSizeX; row++)
            {
                //if its the first row, print the Grid locations
                if (row == 0)
                {
                    Console.WriteLine(topRow.Substring(0, (GridSizeY * 2) + 1) + "#");
                }

                //and columns
                for (int column = 0; column < GridSizeY; column++)
                {
                    //if we are on the first column of the line, add the row number.
                    if (column == 0)
                    {
                        Console.Write("{0,2}", row + 1);
                    }

                    currentShip = getShipAt(new Position(row, column));
                    if (currentShip != null)
                    {
                        currentChar = currentShip.ShipChar;
                    }
                    else currentChar = ' ';
                    
                    //this is the statement that draws each cell
                    Console.Write("{0}|", currentChar);
                }
                //end the current line and print the next bar to the console.
                Console.WriteLine();
                Console.WriteLine(" #" + new StringBuilder().Insert(0, "-#", GridSizeY));
            }

            //now populate the Grid with ships.

        }
    }
}
