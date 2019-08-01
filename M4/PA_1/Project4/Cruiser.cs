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
// <summary>Class to implement the Cruiser class of ships for the game Battleship.</summary>
// ***********************************************************************
using System;

namespace Project4
{
    public class Cruiser : Ship
    {
        public Cruiser() :
            base(3)
        {
            Color = ConsoleColor.Cyan;
            ShipSymbol = 'C';
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
