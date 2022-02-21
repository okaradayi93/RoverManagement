using RoverManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverManagement.States
{
    public class WestDirectionState : RoverDirectionState
    {
        public WestDirectionState(Point Coordinates) : base(Coordinates) { }

        public override void MoveForward()
        {
            Coordinates.SetX(Coordinates.X - 1);
        }

        public override RoverDirectionState TurnLeft()
        {
            return new SouthDirectionState(Coordinates);
        }

        public override RoverDirectionState TurnRight()
        {
            return new NorthDirectionState(Coordinates);
        }

        public override string ToString()
        {
            return Constants.Directions.West.ToString();
        }
    }
}
