using SnakeGame.Entities;
using SnakeGame.Levels;
using SnakeGame.Spawners;


namespace SnakeGame.Checkers
{
    public interface IChecker
    {
        public bool CheckIsSpawned(Level level);
        public bool CheckIsCollectedItem(ISpawner spawner, GameEntity snake);
    }
}