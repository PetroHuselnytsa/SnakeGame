using SnakeGame.Entities;
using SnakeGame.Audio;
using SnakeGame.Spawners;
using SnakeGame.Structs;
using SnakeGame.Levels;


namespace SnakeGame.Checkers
{
    public class AppleChecker : IChecker
    {
        private readonly ISoundManager _soundManager;
        public AppleChecker(ISoundManager soundManager) => _soundManager = soundManager;
        public bool CheckIsSpawned(Level level)
        {
            bool appleIsFound = false;
            for (int row = 0; row < level.Map.GetLength(0) && !appleIsFound; row++)
            {
                for (int column = 0; column < level.Map.GetLength(1); column++)
                {
                    if (level.Map[row, column] == "●")
                    {
                        appleIsFound = true;
                        break;
                    }
                }
            }
            return appleIsFound;
        }
        public bool CheckIsCollectedItem(Point itemPos, GameEntity entity)
        {
            Point headCoords = entity.EntityCoords[0];
            bool coincide = headCoords.X == itemPos.X && headCoords.Y == itemPos.Y;
            if (coincide)
            {
                _soundManager.PlaySound("mixkit-winning-a-coin-video-game-2069.wav");
                entity.CurrEntityLevel.ClearTheCell(itemPos.Y, itemPos.X);
            }
            return coincide;
        }
    }
}