using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3PA
{
    internal class Position
    {
        public int Xpos;
        public int Ypos;
        public Position(int newX, int newY)
        {
            this.Xpos = newX;
            this.Ypos = newY;
        }

        public Position(Position newPosition)
        {
            this.Xpos = newPosition.Xpos;
            this.Ypos = newPosition.Ypos;
        }

        public Position()
        {
            Xpos = 0;
            Ypos = 0;
        }

        public static bool operator== (Position posA, Position posB){
            return (posA.Xpos == posB.Xpos & posA.Ypos == posB.Ypos) ;
           
        }

        public static bool operator!= (Position posA, Position posB)
        {
            return (posA.Xpos != posB.Xpos | posA.Ypos != posB.Ypos);
            
        }

        public override string ToString()
        {
            return "(" + Xpos + "," + Ypos + ")";
        }

        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Position p = (Position)obj;
                return (Xpos == p.Xpos) && (Ypos == p.Ypos);
            }
        }

        public override int GetHashCode()
        {
            return (Xpos << 2) ^ Ypos;
        }
    }


    //ship class
    class Ship
    {
        public int length { set; get; }
        ConsoleColor Color;
        public bool isSunk = false;
        public bool isBattleship = false;
        public List<Position> locations = new List<Position>();
        public char ShipChar = ' ';

        internal enum Direction
        {
            Vertical,
            Horizontal
        };

        public int getLength()
        {
            return length;
        }

        public ConsoleColor getColor()
        {
            return Color;
        }

       public void reset()
        {
            Color = ConsoleColor.Gray;
            isSunk = false;
            isBattleship = false;
        }

        public List<Position> place(Position start, Direction facing)
        {
            //add the first location
            locations.Add(new Position(start));
            //add the rest of the locations
            for (int i = 0; i < length; i++)
            {
                if (facing == Direction.Horizontal) {

                    locations.Add(new Position(start.Xpos , start.Ypos + i));
                }
                else
                {
                
                    locations.Add(new Position(start.Xpos + i , start.Ypos));
                }
            }
            //return the list
            return locations; 
        }


    }

    class Destroyer : Ship
    {
        public Destroyer()
        {
            length = 2;
            ShipChar = 'D';
        }
    }

    class Submarine : Ship
    {
        public Submarine()
        {
            length = 3;
            ShipChar = 'S';
        }
    }

    class Cruiser : Ship
    {
        public Cruiser()
        {
            length = 3;
            ShipChar = 'c';
        }
    }

    class Battleship : Ship
    {
        public Battleship()
        {
            length = 4;
            isBattleship = true;
            ShipChar = 'B';
        }
    }

    class Carrier : Ship
    {
        public Carrier()
        {
            length = 5;
            ShipChar = 'C';
        }
    }
}
