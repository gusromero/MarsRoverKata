using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class MarsRover
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public OrientationDirection Orientation { get; set; }

        private Dictionary<char, ICommand> _availableCommands;

        public MarsRover()
            : this(0, 0, OrientationDirection.North)
        {

        }

        public MarsRover(int x, int y, OrientationDirection orientation)
        {
            PositionX = x;
            PositionY = y;
            Orientation = orientation;

            InitializeAvailableCommands();
        }

        private void InitializeAvailableCommands()
        {
            _availableCommands = new Dictionary<char, ICommand>
            {
                ['f'] = new ForwardCommand(),
                ['b'] = new BackwardCommand(),
                ['r'] = new TurnRightCommand(),
                ['l'] = new TurnLeftCommand()
            };
        }

        public void ExecuteCommands(string commands)
        {
            foreach (var command in commands)
            {
                _availableCommands[command].Execute(this);
            }

        }

   
    }
}
