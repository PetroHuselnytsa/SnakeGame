namespace SnakeGame.Utilites
{
    public static class ArrayHelper
    {
        public static string[,] CloneMap(string[,] map)
        {
            int rows = map.GetLength(0);
            int cols = map.GetLength(1);
            string[,] copy = new string[rows, cols];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    copy[i, j] = map[i, j];

            return copy;
        }
    }
}