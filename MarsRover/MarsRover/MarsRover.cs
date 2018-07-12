using System.Collections.Generic;

namespace MarsRover
{
    public class MarsRover
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public OrientationDirection Orientation { get; set; }

        private readonly IPlanet _planet;

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
                ['f'] = new ForwardCommand(new BackwardCommand()),
                ['b'] = new BackwardCommand(new ForwardCommand()),
                ['r'] = new TurnRightCommand(new TurnLeftCommand()),
                ['l'] = new TurnLeftCommand(new TurnRightCommand())
            };
        }

        public void ExecuteCommands(string commands)
        {
            foreach (var command in commands)
            {
                _availableCommands[command].Execute(this, _planet);
                if (_planet.IsObstacle(PositionX, PositionY))
                {
                    _availableCommands[command].Rollback(this, _planet);
                    break;
                }
            }
        }
    }
}
