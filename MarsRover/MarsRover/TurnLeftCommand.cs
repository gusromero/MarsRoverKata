using System.ComponentModel;

namespace MarsRover
{
    class TurnLeftCommand : Command
    {
        public TurnLeftCommand()
        {
        }

        public TurnLeftCommand(ICommand rollbackCommand) : base(rollbackCommand)
        {
        }

        public override void Execute(MarsRover rover, IPlanet planet)
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
    }
}
