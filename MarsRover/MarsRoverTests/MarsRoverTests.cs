using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MarsRoverTests
{
    [TestClass]
    public class MarsRoverTests
    {
        private MarsRover.MarsRover _rover;
        private Mock<IPlanet> _planetMock;

        [TestInitialize]
        public void Setup()
        {
            _planetMock = new Mock<IPlanet>();
            _planetMock.Setup(x => x.GetSizeX()).Returns(10);
            _planetMock.Setup(x => x.GetSizeY()).Returns(10);

            _rover = new MarsRover.MarsRover(_planetMock.Object);
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
            Assert.AreEqual(_rover.PositionY, 9);
            Assert.AreEqual(_rover.Orientation, OrientationDirection.North);
        }

        [TestMethod]
        public void MSTurnsLeftMovesForward()
        {
            _rover.ExecuteCommands("lf");

            Assert.AreEqual(_rover.PositionX, 9);
            Assert.AreEqual(_rover.PositionY, 0);
            Assert.AreEqual(_rover.Orientation, OrientationDirection.West);
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
            Assert.AreEqual(_rover.PositionY, 9);
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

        [TestMethod]
        public void MSGoesRoundThePlanetVertically()
        {
            _rover.ExecuteCommands("ffffffffff");

            Assert.AreEqual(_rover.PositionX, 0);
            Assert.AreEqual(_rover.PositionY, 0);
            Assert.AreEqual(_rover.Orientation, OrientationDirection.North);
        }

        [TestMethod]
        public void MSGoesRoundThePlanetHorizontally()
        {
            _rover.ExecuteCommands("rffffffffff");

            Assert.AreEqual(_rover.PositionX, 0);
            Assert.AreEqual(_rover.PositionY, 0);
            Assert.AreEqual(_rover.Orientation, OrientationDirection.East);
        }

        [TestMethod]
        public void MSFindsAnObstacle()
        {
            _planetMock.Setup(b => b.IsObstacle(It.IsAny<int>(), It.IsAny<int>())).Returns(false);
            _planetMock.Setup(b => b.IsObstacle(3, 0)).Returns(true);

            _rover.ExecuteCommands("ffffffffff");

            Assert.AreEqual(_rover.PositionX, 0);
            Assert.AreEqual(_rover.PositionY, 2);
            Assert.AreEqual(_rover.Orientation, OrientationDirection.North);
        }
    }
}
