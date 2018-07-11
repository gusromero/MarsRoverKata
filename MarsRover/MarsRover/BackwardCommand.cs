using System.ComponentModel;

namespace MarsRover
{
    class BackwardCommand : ICommand
    {
        public void Execute(MarsRover rover, IPlanet planet)
        {
            switch (rover.Orientation)
            {
                case OrientationDirection.North:
                    if (rover.PositionY == 0)
                        rover.PositionY = planet.GetSizeY() - 1;
                    else
                        rover.PositionY--;
                    break;
                case OrientationDirection.South:
                    rover.PositionY = (rover.PositionY + 1) % planet.GetSizeY();
                    break;
                case OrientationDirection.East:
                    if (rover.PositionX == 0)
                        rover.PositionX = planet.GetSizeX() - 1;
                    else
                        rover.PositionX--;
                    break;
                case OrientationDirection.West:
                    rover.PositionX = (rover.PositionX + 1) % planet.GetSizeX();
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
    }
}
