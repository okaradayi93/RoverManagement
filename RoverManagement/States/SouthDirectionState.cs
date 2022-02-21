using RoverManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverManagement.States
{
    public class SouthDirectionState : RoverDirectionState
    {
        public SouthDirectionState(Point Coordinates) : base(Coordinates) { }

        public override void MoveForward()
        {
            Coordinates.SetY(Coordinates.Y - 1);
        }

        public override RoverDirectionState TurnLeft()
        {
            return new EastDirectionState(Coordinates);
        }

        public override RoverDirectionState TurnRight()
        {
            return new WestDirectionState(Coordinates);
        }

        public override string ToString()
        {
            return Constants.Directions.South.ToString();
        }
    }
}
