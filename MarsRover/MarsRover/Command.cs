namespace MarsRover
{
    public abstract class Command : ICommand
    {
        private ICommand _rollbackCommand;

        public Command()
        {
        }

        public Command(ICommand rollbackCommand)
        {
            _rollbackCommand = rollbackCommand;
        }

        public abstract void Execute(MarsRover rover, IPlanet planet);

        public void Rollback(MarsRover rover, IPlanet planet)
        {
            _rollbackCommand?.Execute(rover, planet);
        }
    }
}
