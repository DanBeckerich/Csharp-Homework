using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project4
{
    class FireAlgo
    {
        internal char[,] shotGrid;
        internal Position PreviousShotPosition;
        internal String PreviousShotResult;
        int SizeOfGrid;
        Position TargetLoc;
        bool TargetMode = false;
        

        public FireAlgo(int GridSize,ref Fleet CurrentFleet)
        {
            
            shotGrid = new char[GridSize, GridSize];
            SizeOfGrid = GridSize;
            //assign a '.' to each position to denote an un altered location
            for(int iRow = 0; iRow < GridSize; iRow++)
            {
                for(int iCol = 0; iCol < GridSize; iCol++)
                {
                    shotGrid[iRow, iCol] = '.';
                }
            } 
            //take in the current fleet.
        }

        public void RegisterShot(Position shotPos, String Response)
        {
            if(Response.ToLower() == "hit")
            {
                shotGrid[shotPos.Row, shotPos.Column] = 'X';
                //if there was a hit anywhere on the board, turn on target mode and set the position
                TargetLoc = shotPos;
                TargetMode = true;
            }

            if(Response.ToLower() == "miss")
            {
                shotGrid[shotPos.Row, shotPos.Column] = 'M';
            }

            if(Response.ToLower() == "sank")
            {
                shotGrid[shotPos.Row, shotPos.Column] = 'S';
            }
        }

        public String FireAt(Position shotPos,Fleet CurrentFleet)
        {
            bool result = CurrentFleet.Attack(shotPos);
            bool isSunk = CurrentFleet.ShipAt(shotPos).Sunk;

            if(result) { return "HIT"; }
            else if (isSunk) { return "SUNK"; }
            else { return "MISS"; }
        }

        public void MakeShot()
        {

            //if this is the first shot, fire at (0,0).
            if (PreviousShotPosition == null & PreviousShotResult == null)
            {
                //Make shot at (0,0)
                //break out of the function, because we dont want to do anything else.
                return;
            }

            //if something was hit, set it to target mode.
            if(PreviousShotResult.ToLower() == "hit")
            {
                TargetMode = true;
                TargetLoc = PreviousShotPosition;
            }

            //************************
            //TARGET MODE STARTS HERE
            //************************
            //if its not the first shot, check if we need to target fire.
            if (TargetMode)
            {
                //check if the location to the left of the targetloc is empty 
                if (shotGrid[TargetLoc.Row - 1, TargetLoc.Column] == '.')
                {
                    //Make shot at (TargetLoc.Row - 1, TargetLoc.Column)
                    //break out of the function, because we dont want to do anything else.
                    return;
                }
                //if the location to the right is empty, make a shot there.
                else if (shotGrid[TargetLoc.Row - 1, TargetLoc.Column] == '.')
                {
                    //MakeShot shot Make shot at(TargetLoc.Row + 1, TargetLoc.Column)
                    //break out of the function, because we dont want to do anything else.
                    return;
                }
                //if the location above is empty, make a shot there
                else if (shotGrid[TargetLoc.Row, TargetLoc.Column + 1] == '.')
                {
                    //make shot at (TargetLoc.Row, TargetLoc.Column + 1)
                    //break out of the function, because we dont want to do anything else.
                    return;
                }
                //if the location below is empty, make the shot there
                else if (shotGrid[TargetLoc.Row, TargetLoc.Column - 1] == '.')
                {
                    //make shot at (TargetLoc.Row, TargetLoc.Column - 1)
                    //break out of the function, because we dont want to do anything else.
                    return;
                }
                //if all 4 of the locations are not empty, switch to hunt mode.
                else
                {
                    TargetMode = false;
                    TargetLoc = new Position(0,0);
                }
                //************************
                //TARGET MODE ENDS HERE
                //************************
            }
            //****************
            //HUNT STARTS HERE
            //****************
            if (!TargetMode)
            {
                //if we are not at the end of a diagonal
                        //fire at the next position of the diagonal

                //if we are at the end of the diagonal 
                        //move the coursor (new BattleShip.Length - 1) spaces to the right.
                
                return;
            }
            //****************
            //HUNT ENDS HERE
            //****************
        }
    }
}
