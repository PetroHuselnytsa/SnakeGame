namespace SnakeGame.Levels
{
    public abstract class LevelFactory
    {
        public abstract Level GenerateNewLevel(int appleNeed, int levelNumber);
    }
}