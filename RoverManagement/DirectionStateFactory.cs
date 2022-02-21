using RoverManagement.Entity;
using RoverManagement.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverManagement
{
    public class DirectionStateFactory
    {
        public static RoverDirectionState Create(Point coordinates, char direction)
        {
            var x = coordinates.X;
            var y = coordinates.Y;
            switch (direction)
            {
                case Constants.Directions.North:
                    return new NorthDirectionState(new Point(x, y));
                case Constants.Directions.South:
                    return new SouthDirectionState(new Point(x, y));
                case Constants.Directions.East:
                    return new EastDirectionState(new Point(x, y));
                case Constants.Directions.West:
                    return new WestDirectionState(new Point(x, y));
                default:
                    return new EastDirectionState(new Point(x, y));
            }
        }
    }
}
