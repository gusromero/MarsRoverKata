using System.ComponentModel;

namespace MarsRover
{
    class TurnLeftCommand : ICommand
    {
        private ICommand _rollbackCommand;

        public TurnLeftCommand()
        {
        }
        public TurnLeftCommand(ICommand rollbackCommand)
        {
            _rollbackCommand = rollbackCommand;
        }

        public void Execute(MarsRover rover, IPlanet planet)
        {
            switch (rover.Orientation)
            {
                case OrientationDirection.North:
                    rover.Orientation = OrientationDirection.West;
                    break;
                case OrientationDirection.South:
                    rover.Orientation = OrientationDirection.East;
                    break;
                case OrientationDirection.East:
                    rover.Orientation = OrientationDirection.North;
                    break;
                case OrientationDirection.West:
                    rover.Orientation = OrientationDirection.South;
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
        public void Rollback(MarsRover rover, IPlanet planet)
        {
            _rollbackCommand?.Execute(rover, planet);
        }
    }
}
