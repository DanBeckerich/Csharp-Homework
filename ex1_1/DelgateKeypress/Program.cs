// ***********************************************************************
// Assembly         : DelgateKeypress
// Author           : rlesh
// Created          : 11-12-2016
//
// Last Modified By : Daniel Beckerich
// Last Modified On : 11-21-2018
// ***********************************************************************

using System;
using System.Collections.Generic;


namespace DelgateKeypress
{
    class Program
    {
        private static int x=20;
        private static int y=20;

        public delegate void Del1();

        //==========================COMPLETE==========================
        //TBD: You will need to define a data structure to store the association 
        //between the KeyPress and the Action the key should perform
        //==========================COMPLETE==========================

        private static void Main(string[] args)
        {
            //==========================COMPLETE==========================
            //TBD: Set up your control scheme here. It should look something like this:
            //   myControls.Add(ConsoleKey.W, Up)
            //   myControls.Add(ConsoleKey.S, Down)
            //or you can ask the user which keys they want to use
            //==========================COMPLETE==========================


            //create a dictionary to store the key bindings.
            Dictionary<ConsoleKey, Delegate> myControls = new Dictionary<ConsoleKey, Delegate>();
            
            //get each key and add it to the dictionary.
            Console.Write("Press the key for Up: ");
            var temp = Console.ReadKey(true);
            myControls.Add(temp.Key, new Del1(Up));
            Console.Write(temp.Key);
            Console.WriteLine();

            Console.Write("Press the key for Down: ");
            temp = Console.ReadKey(true);
            myControls.Add(temp.Key, new Del1(Down));
            Console.Write(temp.Key);
            Console.WriteLine();

            Console.Write("Press the key for Left: ");
            temp = Console.ReadKey(true);
            myControls.Add(temp.Key, new Del1(Left));
            Console.Write(temp.Key);
            Console.WriteLine();

            Console.Write("Press the key for Right: ");
            temp = Console.ReadKey(true);
            myControls.Add(temp.Key, new Del1(Right));
            Console.Write(temp.Key);
            Console.WriteLine();

            while (true)
            {
                Console.SetCursorPosition(x, y);
                Console.Write("@");

                var key = Console.ReadKey(true);


                int oldX = x;
                int oldY = y;

                //==========================COMPLETE==========================
                //TBD: Replace the following 4 lines by looking up the key press in the data structure
                //and then performing the correct action
                //==========================COMPLETE==========================

                //if the dictionary has the key in it, perform the action.
                if (myControls.ContainsKey(key.Key))
                {
                    myControls[key.Key].DynamicInvoke();
                    Console.SetCursorPosition(oldX, oldY);
                    Console.Write("+");
                }


            }
        }

        private static void Right()
        {
            x++;
        }

        private static void Left()
        {
            x--;
        }

        private static void Down()
        {
            y++;
        }

        private static void Up()
        {
            y--;
        }
    }
}
