using RoverManagement.Entity;
using RoverManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverManagement
{
    public class Plateau : IPlateau
    {
        private int xLimit { get; set; }
        private int yLimit { get; set; }
        private bool isValid { get; set; }
        public List<IRover> Rovers { get; set; }
        public Plateau()
        {
            Rovers = new List<IRover>();
        }
        public bool Initialize(string plateauInput)
        {
            isValid = false;
            if (!string.IsNullOrWhiteSpace(plateauInput))
            {
                var inputList = plateauInput.Split(' ');
                if (inputList.Length == 2)
                {
                    if (int.TryParse(inputList[0], out int x))
                    {
                        if (int.TryParse(inputList[1], out int y))
                        {
                            xLimit = x;
                            yLimit = y;
                            isValid = true;
                        }
                    }
                }
            }
            return isValid;
        }

        public Point GetPlateauCoordinates()
        {
            return new Point(xLimit, yLimit);
        }

        public void SetPlateauCoordinates(Point plateauCoordinates)
        {
            xLimit = plateauCoordinates.X;
            yLimit = plateauCoordinates.Y;
        }

        public bool IsValid()
        {
            return isValid;
        }
    }
}
