using SnakeGame.Entities;
using SnakeGame.Levels;
using SnakeGame.Spawners;
using SnakeGame.Structs;


namespace SnakeGame.Checkers
{
    public interface IChecker
    {
        public bool CheckIsSpawned(Level level);
        public bool CheckIsCollectedItem(Point itemPos, GameEntity entity);
    }
}