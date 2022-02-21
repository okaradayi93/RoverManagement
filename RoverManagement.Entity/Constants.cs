using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverManagement.Entity
{
    public static class Constants
    {
        public sealed class Directions
        {
            public const char North = 'N';
            public const char South = 'S';
            public const char East = 'E';
            public const char West = 'W';
        }

        public sealed class Commands
        {
            public const char MoveForward = 'M';
            public const char TurnLeft = 'L';
            public const char TurnRight = 'R';
        }
    }
}
