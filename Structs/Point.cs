namespace SnakeGame.Structs
{
    // SOUND

    public struct Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override readonly bool Equals(object? obj)
        {
            if (obj is Point otherPointToCompare)
            {
                bool equalX = X == otherPointToCompare.X;
                bool equalY = Y == otherPointToCompare.Y;
                return equalX && equalY;
            }

            return false;
        }
        public override readonly int GetHashCode() => X ^ Y;
    }
}