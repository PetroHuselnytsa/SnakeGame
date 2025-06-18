namespace SnakeGame.Entities
{
    public interface IGameEntityStateChecker
    {
        public bool IsWin(GameEntity gameEntity);
        public bool IsDead(GameEntity gameEntity);
    }
}