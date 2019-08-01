using System;

namespace Project8
{
    public class AircraftCarrier : Ship
    {
        public AircraftCarrier() :
            base(5)
        {
            Color = ConsoleColor.Green;
            ShipSymbol = 'A';
        }

        public override bool IsBattleShip
        {
            get
            {
                return false;
            }
        }

        public override object Clone()
        {
            AircraftCarrier newShip = new AircraftCarrier();
            newShip.Initialize(this);
            return newShip;
        }
    }
}
