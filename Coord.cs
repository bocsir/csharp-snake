namespace Snake
{
 
    internal class Coord
    {
        private int x, y;
    
        public int X { get => x; }

        public int Y { get => y; }

        public Coord(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    
        public override bool Equals(object? obj)
        {
            //if object null or types dont match
            if (obj == null || !GetType().Equals(obj.GetType()))
                return false;

            Coord other = (Coord)obj;
            return x == other.x && y == other.y;
        }

        public void ApplyMovementDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    x--;
                    break;
                case Direction.Down:
                    x++;
                    break;
                case Direction.Left:
                    y--;
                    break;
                case Direction.Right:
                    y++;
                    break;
            }
        }
    }   
}