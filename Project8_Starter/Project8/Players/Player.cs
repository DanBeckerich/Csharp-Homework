// ***********************************************************************
// Assembly         : Project8
// Author           : Richard Lesh
// Created          : 11-23-2016
//
// Last Modified By : Richard Lesh
// Last Modified On : 12-01-2016
// ***********************************************************************
// <copyright file="Play.cs" company="">
//     Copyright ©  2016
// </copyright>
// <summary>Abstract class to implement basic parts of an AI player.</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project8
{
    public abstract class Player : IPlayer
    {
        public string Name { get; set; }
        public BattleShipGame Game { get; set; }

        /// <summary>
        /// Constructor for the AI Player
        /// </summary>
        /// <param name="name">Name to identify this player.</param>
        public Player(String name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets the player ready to play a new game.  In overridden
        /// methods be sure to call base.StartGame(game) to call this 
        /// base method.
        /// </summary>
        /// <param name="game">Game for the player to play.</param>
        public virtual void StartGame(BattleShipGame game)
        {
            Game = game;
        }

        public abstract Position Attack();
        public abstract void Hit(Position p);
    }
}
