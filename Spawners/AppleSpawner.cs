using SnakeGame.Checkers;
using SnakeGame.Entities;
using SnakeGame.Levels;
using SnakeGame.Structs;


namespace SnakeGame.Spawners
{
    public class AppleSpawner : ISpawner
    {
        public Point SpawnedItemPosition { get; private set; }
        private readonly IChecker _checker;
        private static readonly Random _random = new Random();
        public AppleSpawner(IChecker checker) => _checker = checker;
        public Point Spawn(Level level, GameEntity snake)
        {
            bool isAppleFound = _checker.CheckIsSpawned(level);
            if (!isAppleFound)
            {
                while (true)
                {
                    int spawnX = _random.Next(1, snake.CurrEntityLevel.Map.GetLength(1) - 1);
                    int spawnY = _random.Next(1, snake.CurrEntityLevel.Map.GetLength(0) - 1);

                    Point spawnPoint = new Point(spawnX, spawnY);

                    bool onSnake = snake.EntityCoords
                                         .Any(point => point.X == spawnPoint.X && point.Y == spawnPoint.Y);
                    if (!onSnake)
                    {
                        SpawnedItemPosition = spawnPoint;
                        return spawnPoint;
                    }

                }
            }
            else return new Point(-1, -1);
        }
    }
}