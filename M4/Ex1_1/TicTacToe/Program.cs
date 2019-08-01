// ***********************************************************************
// Assembly         : TicTacToe
// Author           : rlesh
// Created          : 11-12-2016
//
// Last Modified By : Daniel Beckerich
// Last Modified On : 11-17-2018
// ***********************************************************************

using System;


namespace TicTacToe
{
    class Program
    {
        static void Main()
        {
            bool isDataValid = false;
            var game = new Game();
            var player = 'X';
            while (!game.Ended())
            {
                game.Print();

                //a quick do while loop to make sure we are getting valid data
                do
                {
                    isDataValid = false;
                    //Get an integer position
                    Console.Write("Enter your move:");
                    string input;
                    int position;
                    do
                    {
                        input = Console.ReadLine();
                    } while (!int.TryParse(input, out position));

                    //=============================COMPLETED====================================
                    //TBD: Handle the Exceptions:
                    //1. Once you have implemented exceptions in game.Move() you must catch the ones you expect to see here 
                    //and handle them with suitable error messages
                    //2. Also handle any unexpected exceptions with an "Unknown Error" message. Work out a way to test that code!
                    //=============================COMPLETED====================================


                    //catch any errors.
                    try
                    {
                        //try to execute the move.
                        game.Move(position, player);
                        isDataValid = true;
                    }

                    //if its a problem, repeat the data input.
                    catch (ArgumentException e)
                    {
                        Console.WriteLine("That is not an acceptable move, please try again");
                        isDataValid = false;
                    }
                    catch (BadMoveException e)
                    {
                        Console.WriteLine("That is not an acceptable move, please try again");
                    }

                } while (isDataValid == false);

                //Switch players
                player = (player == 'X') ? 'O' : 'X';
            }
            //because the player flag was switched before the end of the loop we have to flip it again.
            player = (player == 'X') ? 'O' : 'X';
            //print the last version of the board
            game.Print();
            //print the winner
            Console.WriteLine("{0} Wins!", player);


            Console.ReadLine();
        }
    }
}
