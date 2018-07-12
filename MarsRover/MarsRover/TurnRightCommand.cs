using System.ComponentModel;

namespace MarsRover
{
    class TurnRightCommand : ICommand
    {
        public void Execute(MarsRover rover, IPlanet planet)
        {
            switch (rover.Orientation)
            {
                case OrientationDirection.North:
                    rover.Orientation = OrientationDirection.East;
                    break;
                case OrientationDirection.South:
                    rover.Orientation = OrientationDirection.West;
                    break;
                case OrientationDirection.East:
                    rover.Orientation = OrientationDirection.South;
                    break;
                case OrientationDirection.West:
                    rover.Orientation = OrientationDirection.North;
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        public bool CanExecute(MarsRover rover, IPlanet planet)
        {
            return true;
        }
    }
}
