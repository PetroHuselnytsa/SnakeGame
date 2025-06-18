using SnakeGame.Entities;
using SnakeGame.Levels;
using SnakeGame.Structs;


namespace SnakeGame.Spawners
{
    public interface ISpawner
    {
        public Point Spawn(Level level, GameEntity snake);
        public Point SpawnedItemPosition { get; }
    }
}