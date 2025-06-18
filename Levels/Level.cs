using SnakeGame.Structs;

namespace SnakeGame.Levels
{
    public abstract class Level
    {
        public int LevelNumber { get; private set; }
        public int ApplesToWin { get; private set; }
        public string[,] Map { get; private set; }
        protected readonly List<Point> _snakePoints;
        protected readonly ICellProcessor _cellProcessor;

        protected Level(int applesToWin, string[,] map, int levelNumber, ICellProcessor cellProcessor)
        {
            ApplesToWin = applesToWin;
            Map = map;
            LevelNumber = levelNumber;
            _cellProcessor = cellProcessor;
            _snakePoints = new List<Point>();
        }

        protected bool IsValidIndex(int rowIndex, int colulmnIndex) => rowIndex >= 0 && rowIndex < Map.GetLength(0) && colulmnIndex >= 0 && colulmnIndex < Map.GetLength(1);
        public abstract void ClearTheCell(int rowIndex, int columnIndex);

        public abstract void ClearTheLevelMap();
        public abstract List<Point> GetSnakePosition();
        protected abstract void CalculateSnakePosition();
    }
}