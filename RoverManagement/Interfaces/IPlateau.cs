using RoverManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverManagement.Interfaces
{
    public interface IPlateau
    {
        public List<IRover> Rovers { get; set; }
        bool IsValid();
        bool Initialize(string plateauInput);
        Point GetPlateauCoordinates();
        void SetPlateauCoordinates(Point plateauCoordinates);
    }
}
