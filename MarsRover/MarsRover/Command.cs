namespace MarsRover
{
    public abstract class Command : ICommand
    {
        private readonly ICommand _rollbackCommand;

        protected Command()
        {
        }

        protected Command(ICommand rollbackCommand)
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
