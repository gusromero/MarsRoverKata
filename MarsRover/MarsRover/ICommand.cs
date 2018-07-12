namespace MarsRover
{
    interface ICommand
    {
        void Execute(MarsRover rover, IPlanet planet);
        bool CanExecute(MarsRover rover, IPlanet planet);
    }
}
