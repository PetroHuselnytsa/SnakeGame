using SnakeGame.Entities;
using SnakeGame.Enums;
using SnakeGame.Levels;
using SnakeGame.Structs;

namespace SnakeGame.Entities.DefaultSnake
{
    public class Snake : GameEntity
    {
        public Snake(Level initalLevel, IGameEntityStateChecker checker) : base(initalLevel, checker) { }
        private bool IsWin()
        {
            if (_stateChecker!.IsWin(this))
            {
                OnWin();
                CurrApplesCollected = 0;
                PrevApplesCollected = 0;
                return true;
            }

            return false;
        }
        private bool IsDead()
        {
            if (_stateChecker!.IsDead(this))
            {
                CurrEntityLevel.ClearTheLevelMap();
                OnDead();
                PrevApplesCollected = CurrApplesCollected;
                CurrApplesCollected = 0;
                _entityCoords = CurrEntityLevel.GetSnakePosition();
                return true;
            }
            return false;
        }

        public override void Move(MoveDirection d)
        {
            if (IsWin()) return;
            if (IsDead()) return;

            SnakeMover snakeMover = new(CurrEntityLevel, EntityCoords);
            Point newHead = snakeMover.CalculateNewHead(d);
            List<Point> newCoords = snakeMover.ShiftBody(newHead);

            _entityCoords = newCoords;
        }
        public override void Grow()
        {
            CurrApplesCollected++;
            Point lastCoords = EntityCoords[^1];
            _entityCoords.Add(new Point(lastCoords.X, lastCoords.Y + 1));
        }
    }
}