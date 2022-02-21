using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverManagement.Entity.Exceptions
{
    public class OutOfLimitException : Exception
    {
        public OutOfLimitException(int plateauLimit, int actual, string axis)
           : base($"Out of limit on axis {axis}. (Plateau limit: {plateauLimit}, Actual: {actual})")
        { }
    }
}
