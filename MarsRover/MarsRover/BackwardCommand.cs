using System.ComponentModel;

namespace MarsRover
{
    class BackwardCommand : ICommand
    {
        public void Execute(MarsRover rover)
        {
            switch (rover.Orientation)
            {
                case OrientationDirection.North:
                    rover.PositionY--;
                    break;
                case OrientationDirection.South:
                    rover.PositionY++;
                    break;
                case OrientationDirection.East:
                    rover.PositionX--;
                    break;
                case OrientationDirection.West:
                    rover.PositionX++;
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
    }
}
