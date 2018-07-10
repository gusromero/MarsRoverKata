using System.Collections.Generic;

namespace MarsRover
{
    public class MarsRover
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public OrientationDirection Orientation { get; set; }

        private IPlanet _planet;

        private Dictionary<char, ICommand> _availableCommands;

        public MarsRover()
            : this(0, 0, OrientationDirection.North)
        { }

        public MarsRover(IPlanet planet)
            : this(0, 0, OrientationDirection.North, planet)
        {

        }

        public MarsRover(int x, int y, OrientationDirection orientation, IPlanet planet = null)
        {
            PositionX = x;
            PositionY = y;
            Orientation = orientation;
            _planet = planet;

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
