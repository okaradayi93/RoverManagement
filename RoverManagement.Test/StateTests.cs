using NUnit.Framework;
using RoverManagement.States;

namespace RoverManagement.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NortStateMovementTest()
        {
            var rover = new Rover();
            rover.Initialize("1 2 N");
            rover.Commands = "LMLMLMLMM";
            rover.ProcessCommand(5, 5);

            Assert.AreEqual(rover.GetRoverInfo(), "1 3 N");

        }
    }
}