using SnakeGame.Enums;
using SnakeGame.Extensions;
using SnakeGame.Levels;
using SnakeGame.Structs;

namespace SnakeGame.Entities.DefaultSnake
{
    public class SnakeMover
    {
        private readonly Level _level;
        private readonly IReadOnlyList<Point> _entityCoords;
        public SnakeMover(Level level, IReadOnlyList<Point> entityCoords)
        {
            _level = level;
            _entityCoords = entityCoords;
        }
        public List<Point> ShiftBody(Point newHeadPoint)
        {
            var newSnakeCoords = new List<Point>() { newHeadPoint };
            var prevCoord = _entityCoords[0];
            for (int i = 1; i < _entityCoords.Count; i++)
            {
                Point currCorrd = _entityCoords[i];
                newSnakeCoords.Add(prevCoord);
                prevCoord = currCorrd;
            }

            return newSnakeCoords;
        }
        public Point CalculateNewHead(MoveDirection d)
        {
            Point currentHead = _entityCoords[0];
            return d switch
            {
                MoveDirection.Up => ShouldInvertDirection(currentHead, d) // If we goes down but want to go up, if the star above head we continue goes down
                    ? new Point(currentHead.X, currentHead.Y + 1)
                    : new Point(currentHead.X, currentHead.Y - 1),

                MoveDirection.Down => ShouldInvertDirection(currentHead, d) // If we goes up but want to go down, if the star below head we continue goes up
                    ? new Point(currentHead.X, currentHead.Y - 1)
                    : new Point(currentHead.X, currentHead.Y + 1),

                MoveDirection.Left => ShouldInvertDirection(currentHead, d)
                    ? new Point(currentHead.X + 1, currentHead.Y)
                    : new Point(currentHead.X - 1, currentHead.Y),

                MoveDirection.Right => ShouldInvertDirection(currentHead, d)
                    ? new Point(currentHead.X - 1, currentHead.Y)
                    : new Point(currentHead.X + 1, currentHead.Y),

                _ => currentHead
            };
        }

        private bool ShouldInvertDirection(Point headPoint, MoveDirection moveDirection)
        {
            switch (moveDirection)
            {
                case MoveDirection.Up:
                    bool isStarAbove = IsBlockedUp(headPoint);
                    return isStarAbove;
                case MoveDirection.Down:
                    bool isStarBelow = IsBlockedDown(headPoint);
                    return isStarBelow;
                case MoveDirection.Left:
                    bool isStarLeft = IsBlockedLeft(headPoint);
                    if (isStarLeft)
                        return IsNeckLeft(headPoint);
                    return false;
                case MoveDirection.Right:
                    bool isStarRight = IsBlockedRight(headPoint);
                    if (isStarRight)
                        return IsNeckRight(headPoint);
                    return false;
            }

            return false;
        }
        private bool IsNeckLeft(Point headPoint)
        {
            int indexOfStar = _entityCoords.IndexOf(new Point(headPoint.X - 1, headPoint.Y));
            return indexOfStar == 1;
        }
        private bool IsNeckRight(Point headPoint)
        {
            int indexOfStar = _entityCoords.IndexOf(new Point(headPoint.X + 1, headPoint.Y));
            return indexOfStar == 1;
        }
        private bool IsBlockedUp(Point head) => _level.Map[head.Y - 1, head.X] == "*";
        private bool IsBlockedDown(Point head) => _level.Map[head.Y + 1, head.X] == "*";
        private bool IsBlockedLeft(Point head) => _level.Map[head.Y, head.X - 1] == "*";
        private bool IsBlockedRight(Point head) => _level.Map[head.Y, head.X + 1] == "*";
    }
}