using MarsRover;
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
            Assert.AreEqual(rover.Orientation, OrientationDirection.North);
        }

        [TestMethod]
        public void MSIsSetInTheCorrectPositionAndOrientation()
        {
            var rover = new MarsRover.MarsRover(3, 4, OrientationDirection.South);

            Assert.AreEqual(rover.PositionX, 3);
            Assert.AreEqual(rover.PositionY, 4);
            Assert.AreEqual(rover.Orientation, OrientationDirection.South);
        }

        [TestMethod]
        public void MSMovesForward()
        {
            var rover = new MarsRover.MarsRover();
            rover.Command("f");

            Assert.AreEqual(rover.PositionX, 0);
            Assert.AreEqual(rover.PositionY, 1);
            Assert.AreEqual(rover.Orientation, OrientationDirection.North);
        }

        [TestMethod]
        public void MSMovesBackward()
        {
            var rover = new MarsRover.MarsRover();
            rover.Command("b");

            Assert.AreEqual(rover.PositionX, 0);
            Assert.AreEqual(rover.PositionY, -1);
            Assert.AreEqual(rover.Orientation, OrientationDirection.North);
        }

        [TestMethod]
        public void MSTurnsRightAndMovesForward()
        {
            var rover = new MarsRover.MarsRover();
            rover.Command("rf");

            Assert.AreEqual(rover.PositionX, 1);
            Assert.AreEqual(rover.PositionY, 0);
            Assert.AreEqual(rover.Orientation, OrientationDirection.East);
        }

        [TestMethod]
        public void MSTurnsRightTwiceAndMovesForward()
        {
            var rover = new MarsRover.MarsRover();
            rover.Command("rrf");

            Assert.AreEqual(rover.PositionX, 0);
            Assert.AreEqual(rover.PositionY, -1);
            Assert.AreEqual(rover.Orientation, OrientationDirection.South);
        }

        [TestMethod]
        public void MSFourTurnsRightAndMovesForward()
        {
            var rover = new MarsRover.MarsRover();
            rover.Command("rrrrf");

            Assert.AreEqual(rover.PositionX, 0);
            Assert.AreEqual(rover.PositionY, 1);
            Assert.AreEqual(rover.Orientation, OrientationDirection.North);
        }
    }
}
