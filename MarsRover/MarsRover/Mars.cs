namespace MarsRover
{
    public class Mars : IPlanet
    {
        private readonly int _sizeX;
        private readonly int _sizeY;

        public Mars()
        {
            _sizeX = 10;
            _sizeY = 10;
        }
        public int GetSizeX()
        {
            return _sizeX;
        }

        public int GetSizeY()
        {
            return _sizeY;
        }

        public bool IsObstacle(int x, int y)
        {
            throw new System.NotImplementedException();
        }
    }
}
