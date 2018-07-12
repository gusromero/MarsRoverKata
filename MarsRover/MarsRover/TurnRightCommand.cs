using System.ComponentModel;

namespace MarsRover
{
    class TurnRightCommand : Command
    {
        public TurnRightCommand()
        {
        }

        public TurnRightCommand(ICommand rollbackCommand) : base(rollbackCommand)
        {
        }

        public override void Execute(MarsRover rover, IPlanet planet)
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
    }
}
