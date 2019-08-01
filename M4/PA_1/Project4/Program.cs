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
// <summary>Program to test the ship fleet class Fleet.</summary>
// ***********************************************************************
using System;

namespace Project4
{
    class Program
    {
        static void Main(string[] args)
        {
            int gridSize = 10;
            Fleet fleet = new Fleet();
            Ship[] shipsToPlace = 
            {
                new AircraftCarrier(),
                new BattleShip(),
                new Cruiser(),
                new Submarine(),
                new PatrolBoat(),
                new PatrolBoat()
            };

            foreach (Ship s in shipsToPlace)
            {
                bool shipAddedFlag = false;
                do
                {
                    try
                    {
                        shipAddedFlag = false;
                        s.RandomPlace(gridSize);
                        Console.WriteLine("Trying: {0}", s);
                        fleet.Add(s); // Might throw exception here
                        shipAddedFlag = true;
                    }
                    catch (Exception ex)
                    {
                        // do nothing
                    }
                } while (!shipAddedFlag);
                Console.WriteLine("Added to Fleet: {0}",s);
            }

            Console.WriteLine("My Fleet:");
            fleet.Print();

            Grid grid = new Grid(gridSize);
            grid.SetFleet(fleet);

            grid.Draw();

            bool isBattleShipSunk = false;
            for (int i = 0; i < gridSize; ++i)
            {
                for (int j = 0; j < gridSize; ++j)
                {
                    Console.Write("Trying {0}{1} ", Grid.ColumnLabels[j], i + 1);
                    Position p = new Position(i, j);
                    bool isHit = fleet.Attack(p);
                    Console.WriteLine(isHit ? "Hit" : "Miss");
                    if (isHit)
                    {
                        grid.SetCell(p, ConsoleColor.Red, 'X');
                    } else
                    {
                        grid.SetCell(p, ConsoleColor.Black, 'X');
                    }
                    if (fleet.SunkMyBattleship())
                    {
                        Console.WriteLine("You sunk my BattleShip!");
                        isBattleShipSunk = true;
                        break;
                    }
                }
                if (isBattleShipSunk) break;
            }

            grid.Draw();

            Console.WriteLine("My Fleet:");
            fleet.Print();

            System.Console.ReadLine();
        }
    }
}
