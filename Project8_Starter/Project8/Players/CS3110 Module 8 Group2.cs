using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project8
{
    class CS3110_Module_8_Group2 : Player
    {
        private Stack<Position> plannedShots;
        private Position ShotCursor;
        //step size is the length of the battleship.
        private int StepSize = 4;
        private int offset = 0;
        //for some reason i cannot get the grid size declared in Program.cs so we need it as a parameter

        public CS3110_Module_8_Group2(String name) :
            base(name)
        {

        }

        /// <summary>
        /// Gets the player ready to play a new game.  Since the
        /// player can be reused for mutliple games this method
        /// must initialize all needed data structures.
        /// </summary>
        /// <param name="game">Game for the player to play.</param>
        public override void StartGame(BattleShipGame game)
        {
            base.StartGame(game);
            // Initialize the player data structures.
            plannedShots = new Stack<Position>();
            ShotCursor = new Position(0, 0);
            offset = StepSize;

            plannedShots.Push(new Position(0, 0));

        }

        /// <summary>
        /// Returns the next Position to attack from the target list.
        /// Check to make sure that the Position hasn't already been
        /// played due to logic in Hit() processing.
        /// </summary>
        /// <returns>Position to attack for the turn.</returns>
        public override Position Attack()
        {
            //first, check if we have any shots planned.
            if (plannedShots.Count > 0)
            {   //if it is, pop the top one off and return it.
                return plannedShots.Pop();
            }

            //assuming we haven't returned already, find the next shot.
            //do
            //{
                //check if our potential shot would be out of bounds.
                if (ShotCursor.Column + StepSize >= Game.GridSize)

                {
                    if (offset - 1 < 0)
                    {
                        offset = StepSize;
                    }
                    else
                    {
                        offset = offset - 1;
                    }
                    if (ShotCursor.Row + 1 <= Game.GridSize)
                    {
                        ShotCursor = new Position(ShotCursor.Row + 1, offset);
                    }
                }
                else
                {
                    ShotCursor = new Position(ShotCursor.Row, ShotCursor.Column + StepSize);
                }



            //} while (Game.HitOrMissAt(ShotCursor) != BattleShipGame.HitOrMissEnum.UNKNOWN);
            return ShotCursor;
        }

        /// <summary>
        /// Notifies the player that the Position was a hit.  To
        /// optimize the chances of future hits we should have
        /// a strategy for trying neighboring Positions when
        /// Attack() is called next.
        /// </summary>
        /// <param name="p">Hit position</param>
        public override void Hit(Position p)
        {
            if (!Game.ShipSunkAt(p))
            {
                if (p.Row > 0)
                    plannedShots.Push(new Position(p.Row - 1, p.Column));
                if (p.Row < Game.GridSize - 1)
                    plannedShots.Push(new Position(p.Row + 1, p.Column));
                if (p.Column > 0)
                    plannedShots.Push(new Position(p.Row, p.Column - 1));
                if (p.Column < Game.GridSize - 1)
                    plannedShots.Push(new Position(p.Row, p.Column + 1));
            }
        }
    }
}
