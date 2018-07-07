using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTests
{
    [TestClass]
    public class MarsRoverTests
    {
        [TestMethod]
        public void MSIsInitiallySetInOriginFacingNorth()
        {
            var rover = new MarsRover.MarsRover();

            Assert.AreEqual(rover.PositionX, 0);
            Assert.AreEqual(rover.PositionY, 0);
            Assert.AreEqual(rover.Orientation, "N");
        }

        [TestMethod]
        public void MSIsSetInTheCorrectPositionAndOrientation()
        {
            var rover = new MarsRover.MarsRover(3, 4, "S");

            Assert.AreEqual(rover.PositionX, 3);
            Assert.AreEqual(rover.PositionY, 4);
            Assert.AreEqual(rover.Orientation, "S");
        }

        [TestMethod]
        public void MSMovesForward()
        {
            var rover = new MarsRover.MarsRover();
            rover.Command("f");

            Assert.AreEqual(rover.PositionX, 0);
            Assert.AreEqual(rover.PositionY, 1);
            Assert.AreEqual(rover.Orientation, "N");
        }
    }
}
