using RoverManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverManagement.States
{
    public abstract class RoverDirectionState
    {
        public Point Coordinates { get; private set; }
        public RoverDirectionState(Point Coordinates)
        {
            this.Coordinates = Coordinates;
        }
        public abstract void MoveForward();
        public abstract RoverDirectionState TurnLeft();
        public abstract RoverDirectionState TurnRight();
    }
}
