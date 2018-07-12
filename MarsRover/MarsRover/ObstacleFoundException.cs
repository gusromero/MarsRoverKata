using System;

namespace MarsRover
{
    public class ObstacleFoundException : Exception
    {
        public ObstacleFoundException(string message) : base(message)
        {
        }
    }
}
