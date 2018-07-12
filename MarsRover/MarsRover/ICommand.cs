namespace MarsRover
{
    public interface ICommand
    {
        void Execute(MarsRover rover, IPlanet planet);
        void Rollback(MarsRover rover, IPlanet planet);
    }
}
