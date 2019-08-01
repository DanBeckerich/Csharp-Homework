// ***********************************************************************
// Assembly         : TicTacToe
// Author           : rlesh
// Created          : 11-12-2016
//
// Last Modified By : Daniel Beckerich
// Last Modified On : 11-17-2018
// ***********************************************************************

using System;
using System.Security.Cryptography.X509Certificates;

namespace TicTacToe
{

    //define the exception
    [Serializable]
    public class BadMoveException : Exception
    {
        public BadMoveException(string message) : base(message)
        {
        }
        public BadMoveException() : base("That is not an acceptable action.")
        {
        }
    }

    internal class Game
    {
        char[,] grid = new char[3,3];
        public Game()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    grid[x, y] = '.';
                }
            }
        }

        public bool Ended()
        {
            //here is a quick hard coded win condition check
            //check to see if X wins
            // check rows
            if (grid[0, 0] == 'X' && grid[0, 1] == 'X' && grid[0, 2] == 'X') { return true; }
            if (grid[1, 0] == 'X' && grid[1, 1] == 'X' && grid[1, 2] == 'X') { return true; }
            if (grid[2, 0] == 'X' && grid[2, 1] == 'X' && grid[2, 2] == 'X') { return true; }

            // check columns
            if (grid[0, 0] == 'X' && grid[1, 0] == 'X' && grid[2, 0] == 'X') { return true; }
            if (grid[0, 1] == 'X' && grid[1, 1] == 'X' && grid[2, 1] == 'X') { return true; }
            if (grid[0, 2] == 'X' && grid[1, 2] == 'X' && grid[2, 2] == 'X') { return true; }

            // check diags
            if (grid[0, 0] == 'X' && grid[1, 1] == 'X' && grid[2, 2] == 'X') { return true; }
            if (grid[0, 2] == 'X' && grid[1, 1] == 'X' && grid[2, 0] == 'X') { return true; }

            //now check O
            if (grid[0, 0] == 'O' && grid[0, 1] == 'O' && grid[0, 2] == 'O') { return true; }
            if (grid[1, 0] == 'O' && grid[1, 1] == 'O' && grid[1, 2] == 'O') { return true; }
            if (grid[2, 0] == 'O' && grid[2, 1] == 'O' && grid[2, 2] == 'O') { return true; }

            // check columns
            if (grid[0, 0] == 'O' && grid[1, 0] == 'O' && grid[2, 0] == 'O') { return true; }
            if (grid[0, 1] == 'O' && grid[1, 1] == 'O' && grid[2, 1] == 'O') { return true; }
            if (grid[0, 2] == 'O' && grid[1, 2] == 'O' && grid[2, 2] == 'O') { return true; }

            // check diags
            if (grid[0, 0] == 'O' && grid[1, 1] == 'O' && grid[2, 2] == 'O') { return true; }
            if (grid[0, 2] == 'O' && grid[1, 1] == 'O' && grid[2, 0] == 'O') { return true; }

            return false;
        }


        internal void Move(int position, char player)
        {
            //=============================COMPLETED====================================
            //TBD: This function needs validation
            //1. Position needs to be in the range 0..9 - if not throw an ArgumentException
            //2. The grid cell needs to be unoccupied - if not throw a BadMoveException
            //    .Net does not have a BadMoveException so you must define a custom exception class
            //=============================COMPLETED====================================

            //if position is less than zero, or greater or equal to 9, throw the error.
            if (position < 0 | position >= 9)
            {
                throw new ArgumentException();
            }
            //if you are trying to play a move on a space that already has something there, throw the error.
            else if (grid[position % 3, (position / 3)] != '.')
            {
                throw new BadMoveException();
            }

            else
            {
                grid[position % 3, (position / 3)] = player;
            }
        }

        public void Print()
        {
            Console.Clear();

            Console.WriteLine("Key");
            int cell = 0;
            for (int y = 0; y < 3; y++)
            {
                if (y >= 1) Console.WriteLine("---+---+---");
                for (int x = 0; x < 3; x++)
                {
                    if (x >= 1) Console.Write("|");
                    Console.Write(" {0} ", cell++);
                }
                Console.WriteLine();
            }


            Console.WriteLine();
            for (int y = 0; y < 3; y++)
            {
                if (y >= 1) Console.WriteLine("---+---+---");
                for (int x = 0; x < 3; x++)
                {
                    if (x >= 1) Console.Write("|");
                    Console.Write(" {0} ", grid[x,y]);
                }
                Console.WriteLine();
            }





        }

    }
}