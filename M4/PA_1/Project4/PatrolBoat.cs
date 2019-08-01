// ***********************************************************************
// Assembly         : Project4
// Author           : Richard Lesh
// Created          : 11-23-2016
//
// Last Modified By : Daniel Beckerich
// Last Modified On : 11/18/2018
// ***********************************************************************
// <copyright file="Program.cs" company="">
//     Copyright ©  2016
// </copyright>
// <summary>Class to implement the Patrol boat class of ships for the game Battleship.</summary>
// ***********************************************************************
using System;

namespace Project4
{
    public class PatrolBoat : Ship
    {
        public PatrolBoat() :
            base(2)
        {
            Color = ConsoleColor.Yellow;
            ShipSymbol = 'P';
        }

        public override bool IsBattleShip
        {
            get
            {
                return false;
            }
        }
    }
}
