namespace MarsRover
{
    public class MarsRover
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public string Orientation { get; set; }   //TODO: enum


        public MarsRover()
            : this(0, 0, "N")
        {

        }

        public MarsRover(int x, int y, string orientation)
        {
            PositionX = x;
            PositionY = y;
            Orientation = orientation;
        }

        public void Command(string commands)
        {
            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'f':
                        PositionX++;
                        break;
                }
                
            }
            
        }
    }
}
