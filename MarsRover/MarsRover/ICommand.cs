namespace MarsRover
{
    interface ICommand
    {
        void Execute(MarsRover rover, IPlanet planet);
    }
}
