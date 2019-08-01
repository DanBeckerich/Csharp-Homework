// ***********************************************************************
// Assembly         : Project8
// Author           : Richard Lesh
// Created          : 11-17-2016
//
// Last Modified By : Richard Lesh
// Last Modified On : 12-01-2016
// ***********************************************************************
// <copyright file="BattleShipGame.cs" company="">
//     Copyright ©  2016
// </copyright>
// <summary>This class implements logic to play a BattleShip game.</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project8
{
    /// <summary>
    /// Class that represents a BattleShip game.
    /// </summary>
    public class BattleShipGame
    {
        public int GridSize { get; protected set; }
        private IPlayer Player;
        private Grid GameGrid;
        private Fleet Fleet;
        private HitOrMissEnum[,] HitsAndMisses;
        public WinCriteriaEnum WinCriteria { get; protected set; }

        public enum HitOrMissEnum { UNKNOWN, MISS, HIT};
        public enum WinCriteriaEnum { ALL, BATTLESHIP};

        /// <summary>
        /// Constructor for the BattleShip Game.
        /// </summary>
        /// <param name="gridSize">The size of the battle area.</param>
        /// <param name="player">The AI player for this game.</param>
        /// <param name="ships">Array of ships that have already been positioned.</param>
        /// <param name="win">The win mode.</param>
        public BattleShipGame(int gridSize, IPlayer player, Ship[] ships, WinCriteriaEnum win)
        {
            GridSize = gridSize;
            GameGrid = new Grid(gridSize);
            HitsAndMisses = new HitOrMissEnum[gridSize, gridSize];
            Fleet = new Fleet();
            foreach (Ship s in ships)
            {
                Fleet.AddClone(s);
            }
            GameGrid.SetFleet(Fleet);
            Player = player;
            WinCriteria = win;
        }

        /// <summary>
        /// Execute one turn in the game.
        /// </summary>
        public void Turn()
        {
            Position p = Player.Attack();
            bool isHit = Fleet.Attack(p);

            if (isHit)
            {
                Player.Hit(p);
                HitsAndMisses[p.Row, p.Column] = HitOrMissEnum.HIT;
                GameGrid.SetCell(p, ConsoleColor.Red, 'X');
            }
            else
            {
                HitsAndMisses[p.Row, p.Column] = HitOrMissEnum.MISS;
                GameGrid.SetCell(p, ConsoleColor.Black, 'X');
            }
        }

        /// <summary>
        /// Determines if the game is over, i.e. has been won.
        /// </summary>
        /// <returns><b>true</b> if the game has been won.</returns>
        public bool GameOver()
        {
            bool result = false;

            switch (WinCriteria) {
                case WinCriteriaEnum.BATTLESHIP:
                    result = Fleet.SunkMyBattleship;
                    break;
                default:
                    result = Fleet.AllSunk;
                    break;
            }
            return result;
        }

        /// <summary>
        /// Determines if a game position has been played and
        /// what the outcome was.
        /// </summary>
        /// <param name="p">Position to check.</param>
        /// <returns>UNKNOWN, HIT or MISS.</returns>
        public HitOrMissEnum HitOrMissAt(Position p)
        {
            return HitsAndMisses[p.Row, p.Column];
        }

        /// <summary>
        /// Determines if the ship at a given position has been sunk.
        /// </summary>
        /// <returns><b>true</b> if the ship conatining the position is sunk.</returns>
        public bool ShipSunkAt(Position p)
        {
            return Fleet.ShipSunkAt(p);
        }

        /// <summary>
        /// Determines the size of the BattleShip.
        /// </summary>
        /// <returns>The Length property of the BattleShip.</returns>
        public int BattleShipSize()
        {
            return Fleet.BattleShipSize();
        }

        /// <summary>
        /// Draws the game grid.
        /// </summary>
        public void Draw()
        {
            GameGrid.Draw();
        }
    }
}
