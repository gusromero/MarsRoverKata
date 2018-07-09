using System;

namespace MarsRover
{
    public class MarsRover
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public OrientationDirection Orientation { get; set; }   //TODO: enum


        public MarsRover()
            : this(0, 0, OrientationDirection.North)
        {

        }

        public MarsRover(int x, int y, OrientationDirection orientation)
        {
            PositionX = x;
            PositionY = y;
            Orientation = orientation;
        }

        public void ExecuteCommands(string commands)
        {
            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'f':
                        MoveForward();
                        break;
                    case 'b':
                        MoveBackward();
                        break;
                    case 'l':
                        TurnLeft();
                        break;
                    case 'r':
                        TurnRight();
                        break;
                    default:
                        throw new ArgumentException();

                }

            }

        }

        private void MoveForward()
        {
            switch (Orientation)
            {
                case OrientationDirection.North:
                    PositionY++;
                    break;
                case OrientationDirection.South:
                    PositionY--;
                    break;
                case OrientationDirection.East:
                    PositionX++;
                    break;
                case OrientationDirection.West:
                    PositionX--;
                    break;
                default:
                    throw new ArgumentException();
            }

        }

        private void MoveBackward()
        {
            switch (Orientation)
            {
                case OrientationDirection.North:
                    PositionY--;
                    break;
                case OrientationDirection.South:
                    PositionY++;
                    break;
                case OrientationDirection.East:
                    PositionX--;
                    break;
                case OrientationDirection.West:
                    PositionX++;
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        private void TurnRight()
        {
            switch (Orientation)
            {
                case OrientationDirection.North:
                    Orientation = OrientationDirection.East;
                    break;
                case OrientationDirection.South:
                    Orientation = OrientationDirection.West;
                    break;
                case OrientationDirection.East:
                    Orientation = OrientationDirection.South;
                    break;
                case OrientationDirection.West:
                    Orientation = OrientationDirection.North;
                    break;
            }
        }

        private void TurnLeft()
        {
            switch (Orientation)
            {
                case OrientationDirection.North:
                    Orientation = OrientationDirection.West;
                    break;
                case OrientationDirection.South:
                    Orientation = OrientationDirection.East;
                    break;
                case OrientationDirection.East:
                    Orientation = OrientationDirection.North;
                    break;
                case OrientationDirection.West:
                    Orientation = OrientationDirection.South;
                    break;
            }
        }
    }
}
