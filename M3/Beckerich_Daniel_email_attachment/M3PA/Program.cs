using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3PA
{
    class Program
    {
        static void Main(string[] args)
        {

            Carrier ac = new Carrier();
            ac.place(new Position(0, 0), Ship.Direction.Horizontal);
            ac.reset();

            Grid main = new Grid(10, 10);
            main.AddShip(ac);
            main.draw();


            Console.ReadLine();
        }
    }
}
