using SnakeGame.Structs;

namespace SnakeGame.Levels
{
    public class DefaultLevel : Level
    {
        public DefaultLevel(int applesToWin, string[,] map, int levelNumber, ICellProcessor cellProcessor)
        : base(applesToWin, map, levelNumber, cellProcessor)
        {
            CalculateSnakePosition();
        }

        public override void ClearTheCell(int rowIndex, int columnIndex)
        {
            if (IsValidIndex(rowIndex, columnIndex))
            {
                if (Map[rowIndex, columnIndex] == "●")
                    Map[rowIndex, columnIndex] = " ";
            }
        }
        public override void ClearTheLevelMap()
        {
            int rows = Map.GetLength(0);
            int columns = Map.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    var currCellInfo = new CellContext(i, j, Map[i, j], rows, columns);
                    Map[i, j] = _cellProcessor.Process(currCellInfo);
                }
            }
        }
        protected override void CalculateSnakePosition()
        {
            for (int row = 0; row < Map.GetLength(0); row++)
            {
                for (int col = 0; col < Map.GetLength(1); col++)
                {
                    string currSymbol = Map![row, col];
                    if (currSymbol == "@")
                    {
                        _snakePoints.Add(new Point(col, row));
                        do
                        {
                            row++;
                            currSymbol = Map[row, col];
                            if (currSymbol != "*")
                                break;

                            _snakePoints.Add(new Point(col, row));
                        }
                        while (true);

                        return;
                    }
                }
            }
        }
        public override List<Point> GetSnakePosition() => [.. _snakePoints];
    }
}