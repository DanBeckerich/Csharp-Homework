// ***********************************************************************
// Assembly         : Project4
// Author           : Richard Lesh
// Created          : 11-23-2016
//
// Last Modified By : Daniel Beckerich
// Last Modified On : 11/18/2018
// ***********************************************************************
// <copyright file="Fleet.cs" company="">
//     Copyright ©  2016
// </copyright>
// <summary>Class to represent a fleet of ships.</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project4
{
    /// <summary>
    /// Class that represents a fleet of ships.
    /// </summary>
    class Fleet
    {
        // Need member called Ships to contain a list of ships using a 
        // generic container.
        internal List<Ship> Ships = new List<Ship>();

        /// <summary>
        /// Adds the specified ship to the fleet of ships.  Throws an
        /// ShipCollisionException if the new ship collides with an 
        /// existing ship in the fleet.
        /// </summary>
        /// <param name="newShip">The ship to add.</param>
        /// <exception cref="Project4.ShipCollisionException"></exception>
        public void Add(Ship newShip)
        {
            // Loop through all the ships in the fleet to see if they collide with newShip.
            // If none collide Add() to Fleet.

           //loop through the fleet, calling Collision() for each combination
           foreach(Ship ship in Ships)
            {
                if(Collision(ship, newShip))
                {
                    //if there is a collision, throw an exception
                    throw new CollisionException("collision between " + ship + " and " + newShip);
                }
                //if there are no collisions, add the ship.
                Ships.Add(newShip);
            }

        }

        /// <summary>
        /// Clears this instance of ships.
        /// </summary>
        public void Clear()
        {
            // Clear Fleet.
            Ships = new List<Ship>();
        }

        /// <summary>
        /// Indicates whether or not the BattleShip has been sunk.
        /// </summary>
        /// <value><c>true</c> if the BattleShip is sunk; otherwise, <c>false</c>.</value>
        public bool SunkMyBattleship() {
            // Loop through all the ships in the fleet to find the BattleShip.
            // Return true if the BattleShip is sunk.
            foreach(Ship ship in Ships)
            {
                if(ship.IsBattleShip)
                {
                    if (ship.Sunk) { return true; }
                }
            }

            return false;

        }

        /// <summary>
        /// Attacks the specified position.
        /// </summary>
        /// <param name="p">The Position to attack.</param>
        /// <returns><c>true</c> if a ship is hit, <c>false</c> otherwise.</returns>
        /// <exception cref="ArgumentException"></exception>
        public bool Attack(Position p)
        {
            // Check to see if position is valid, if not throw ArgumentException.
            // Loop through all the ships in the Fleet and
            // call the Attack method on the ship to see if the attack hits.

            //loop trough all the ships in the fleet and call Attack for each one
            foreach(Ship ship in Ships) {
                if (ship.Attack(p)) { return true; }
            }

            return false;
        
        }

        /// <summary>
        /// Determines if the two ships passed share a common
        /// position, i.e. they collide.
        /// </summary>
        /// <param name="ship1">The first ship</param>
        /// <param name="ship2">The second ship</param>
        /// <returns><c>true</c> if the ships have a common position, <c>false</c> otherwise.</returns>
        static public bool Collision(Ship ship1, Ship ship2)
        {
            //iterate through the positions of each ship.
            for(int ship1Pos = 0; ship1Pos < ship1.Length; ship1Pos++)
            {
                for (int ship2Pos = 0; ship2Pos < ship2.Length; ship2Pos++)
                {
                    //if they have a single position  in common, return true.
                    if(ship1.GetPosition(ship1Pos) == ship2.GetPosition(ship2Pos)) { return true; }
                }
            }

            //after checking every combination of the ships positions, return false if we haven't returned already.
            return false;
        }

        /// <summary>
        /// Prints the fleet of ships.  For each ship print the 
        /// ship itself (using ToString()) on one line followed by
        /// all the ships coordinates on a second line.
        /// </summary>
        public void Print()
        {
            foreach (Ship ship in Ships)
            {
                Console.WriteLine(ship);
                Console.Write("\t");
                for (int j = 0; j < ship.Length; ++j)
                {
                    Console.Write(ship.GetPosition(j));
                }
                Console.WriteLine();
            }
        }
    }
}
