using RoverManagement.Entity;
using RoverManagement.Entity.Exceptions;
using RoverManagement.Interfaces;
using RoverManagement.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverManagement
{
    public class Rover : IRover
    {
        private RoverDirectionState _roverState;
        public string Commands { get; set; }

        public string GetRoverInfo()
        {
            return $"{_roverState.Coordinates} {_roverState}";
        }

        public bool Initialize(string roverInitializeCoordinates)
        {
            var roverPositions = roverInitializeCoordinates.Split(' ');
            if (roverPositions.Length == 3)
            {
                try
                {
                    var x = int.Parse(roverPositions[0]);
                    var y = int.Parse(roverPositions[1]);

                    var direction = roverPositions[2].ToUpper();
                    if (direction == "N" || direction == "S" || direction == "E" || direction == "W")
                    {
                        _roverState = DirectionStateFactory.Create(new Point(x, y), char.Parse(direction));
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid input value");
                    Console.ReadLine();
                    throw;
                }
            }
            return false;
        }

        public void ProcessCommand(int plateauXLimit, int plateauYLimit)
        {
            char[] commandArray = Commands.ToCharArray();

            foreach (var command in commandArray)
            {
                switch (command)
                {
                    case Constants.Commands.MoveForward:
                        CheckCommandToOutOfLimit(plateauXLimit, plateauYLimit);
                        _roverState.MoveForward();
                        break;
                    case Constants.Commands.TurnLeft:
                        _roverState = _roverState.TurnLeft();
                        break;
                    case Constants.Commands.TurnRight:
                        _roverState = _roverState.TurnRight();
                        break;
                }
            }
        }

        private void CheckCommandToOutOfLimit(int plateauXLimit, int plateauYLimit)
        {
            var direction = _roverState.ToString();
            if ((direction == Constants.Directions.East.ToString() && _roverState.Coordinates.X == plateauXLimit)
                || (direction == Constants.Directions.West.ToString() && _roverState.Coordinates.X == 0))
            {
                throw new OutOfLimitException(plateauXLimit, _roverState.Coordinates.X, "X");
            }
            else if ((direction == Constants.Directions.North.ToString() && _roverState.Coordinates.Y == plateauYLimit)
                    || direction == Constants.Directions.South.ToString() && _roverState.Coordinates.Y == 0)
            {
                throw new OutOfLimitException(plateauYLimit, _roverState.Coordinates.Y, "Y");

            }
        }
    }
}
