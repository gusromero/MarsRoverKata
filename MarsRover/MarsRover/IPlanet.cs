namespace MarsRover
{
    public interface IPlanet
    {
        int GetSizeX();
        int GetSizeY();

        bool IsObstacle(int x, int y);
    }
}
