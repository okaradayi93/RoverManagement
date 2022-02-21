using RoverManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverManagement.Interfaces
{
    public interface IRover
    {
        bool Initialize(string roverInitializeCoordinates);
        string Commands { get; set; }
        

        void ProcessCommand(int xLimit, int yLimit);
        string GetRoverInfo();
    }
}
