﻿// ***********************************************************************
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
// <summary>Class to implement the Battleship class of ships for the game Battleship.</summary>
// ***********************************************************************
using System;

namespace Project4
{
    public class BattleShip : Ship
    {
        public BattleShip() :
            base(4)
        {
            Color = ConsoleColor.Blue;
            ShipSymbol = 'B';
        }

        public override bool IsBattleShip
        {
            get
            {
                return true;
            }
        }
    }
}
