using NAudio.Wave;
using SnakeGame.Entities;
using SnakeGame.Structs;

namespace SnakeGame.Entities.DefaultSnake
{
    public class SnakeChecker : IGameEntityStateChecker
    {
        public bool IsDead(GameEntity gameEntity)
        {
            Point headPoint = gameEntity.EntityCoords[0];
            var bodyPoints = gameEntity.EntityCoords.Skip(1);

            bool bumpedIntoUpOrDownWall = headPoint.Y == 0 || headPoint.Y == gameEntity.CurrEntityLevel.Map.GetLength(0) - 1;
            bool bumpedIntoRightOrLeftWall = headPoint.X == 0 || headPoint.X == gameEntity.CurrEntityLevel.Map.GetLength(1) - 1;
            bool bumpedIntoTheBody = bodyPoints.Any(bodyPoint => bodyPoint.X == headPoint.X && bodyPoint.Y == headPoint.Y);

            if (bumpedIntoRightOrLeftWall || bumpedIntoUpOrDownWall || bumpedIntoTheBody)
                return true;

            return false;
        }
        public bool IsWin(GameEntity gameEntity) => gameEntity.CurrApplesCollected == gameEntity.CurrEntityLevel.ApplesToWin;
    }
}