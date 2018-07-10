using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTests
{
    [TestClass]
    public class MarsRoverTests
    {
        private MarsRover.MarsRover _rover;

        [TestInitialize]
        public void Setup()
        {
            _rover = new MarsRover.MarsRover();
        }

        [TestMethod]
        public void MSIsInitiallySetInOriginFacingNorth()
        {
            Assert.AreEqual(_rover.PositionX, 0);
            Assert.AreEqual(_rover.PositionY, 0);
            Assert.AreEqual(_rover.Orientation, OrientationDirection.North);
        }

        [TestMethod]
        public void MSIsSetInTheCorrectPositionAndOrientation()
        {
            _rover = new MarsRover.MarsRover(3, 4, OrientationDirection.South);

            Assert.AreEqual(_rover.PositionX, 3);
            Assert.AreEqual(_rover.PositionY, 4);
            Assert.AreEqual(_rover.Orientation, OrientationDirection.South);
        }

        [TestMethod]
        public void MSMovesForward()
        {
            _rover.ExecuteCommands("f");

            Assert.AreEqual(_rover.PositionX, 0);
            Assert.AreEqual(_rover.PositionY, 1);
            Assert.AreEqual(_rover.Orientation, OrientationDirection.North);
        }

        [TestMethod]
        public void MSMovesBackward()
        {
            _rover.ExecuteCommands("b");

            Assert.AreEqual(_rover.PositionX, 0);
            Assert.AreEqual(_rover.PositionY, -1);
            Assert.AreEqual(_rover.Orientation, OrientationDirection.North);
        }

        [TestMethod]
        public void MSTurnsRightAndMovesForward()
        {
            _rover.ExecuteCommands("rf");

            Assert.AreEqual(_rover.PositionX, 1);
            Assert.AreEqual(_rover.PositionY, 0);
            Assert.AreEqual(_rover.Orientation, OrientationDirection.East);
        }

        [TestMethod]
        public void MSTurnsRightTwiceAndMovesForward()
        {
            _rover.ExecuteCommands("rrf");

            Assert.AreEqual(_rover.PositionX, 0);
            Assert.AreEqual(_rover.PositionY, -1);
            Assert.AreEqual(_rover.Orientation, OrientationDirection.South);
        }

        [TestMethod]
        public void MSFourTurnsRightAndMovesForward()
        {
            _rover.ExecuteCommands("rrrrf");

            Assert.AreEqual(_rover.PositionX, 0);
            Assert.AreEqual(_rover.PositionY, 1);
            Assert.AreEqual(_rover.Orientation, OrientationDirection.North);
        }
    }
}
