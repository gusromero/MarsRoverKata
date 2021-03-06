﻿using System.ComponentModel;

namespace MarsRover
{
    public class ForwardCommand : Command
    {
        public ForwardCommand()
        {
        }

        public ForwardCommand(ICommand rollbackCommand) : base(rollbackCommand)
        {
        }

        public override void Execute(MarsRover rover, IPlanet planet)
        {
            switch (rover.Orientation)
            {
                case OrientationDirection.North:
                    rover.PositionY = (rover.PositionY + 1) % planet.GetSizeY();
                    break;
                case OrientationDirection.South:
                    if (rover.PositionY == 0)
                        rover.PositionY = planet.GetSizeY() - 1;
                    else
                        rover.PositionY--;
                    break;
                case OrientationDirection.East:
                    rover.PositionX = (rover.PositionX + 1) % planet.GetSizeX();
                    break;
                case OrientationDirection.West:
                    if (rover.PositionX == 0)
                        rover.PositionX = planet.GetSizeX() - 1;
                    else
                        rover.PositionX--;
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

    }
}
