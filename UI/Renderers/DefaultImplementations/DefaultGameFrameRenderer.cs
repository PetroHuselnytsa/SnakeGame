using System.Text;
using SnakeGame.Controllers;
using SnakeGame.Structs;
using SnakeGame.UI.Renderers.Interfaces;
using SnakeGame.UI.Renderers.Records;


namespace SnakeGame.UI.Renderers.DefaultImplementations
{
    public class DefaultGameFrameRenderer : IGameFrameRenderer
    {
        private static void ClearSnakeFromMap(string[,] map)
        {
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (map[y, x] == "@" || map[y, x] == "*")
                        map[y, x] = " ";
                    if (y == 0 || x == 0 || y == map.GetLength(0) - 1 || x == map.GetLength(1) - 1)
                        map[y, x] = "#";

                }
            }
        }
        private static void PlaceApple(string[,] map, Point applePoint)
        {
            if (applePoint.X == -1 || applePoint.Y == -1) return;
            map[applePoint.Y, applePoint.X] = "●";
        }
        private static void PlaceSnake(string[,] map, IReadOnlyList<Point> snakeCoords)
        {
            for (int i = 0; i < snakeCoords.Count; i++)
            {
                int y = snakeCoords[i].Y;
                int x = snakeCoords[i].X;
                map[y, x] = i == 0 ? "@" : "*";
            }
        }
        private static void DrawMap(string[,] map, int levelNumber)
        {
            int consoleCenterX = (Console.WindowWidth - map.GetLength(1) * 2) / 2;
            int consoleCenterY = (Console.WindowHeight - map.GetLength(0)) / 2;

            Console.ResetColor();
            Console.SetCursorPosition(consoleCenterX, consoleCenterY - 2);
            Console.WriteLine($"\t \"LEVEL {levelNumber}\"");
            for (int i = 0; i < map.GetLength(0); i++)
            {
                Console.SetCursorPosition(consoleCenterX, consoleCenterY + i);
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    string curr = map[i, j];

                    Console.ForegroundColor = curr switch
                    {
                        "*" => ConsoleColor.DarkGreen,
                        "@" => ConsoleColor.Green,
                        "●" => ConsoleColor.Red,
                        _ => ConsoleColor.White
                    };
                    Console.Write($"{curr} ");
                }
                Console.WriteLine();
            }
        }
        private static void DrawScore(int applesCollected, int applesToWin, int mapRows)
        {
            string scoreText = $"Apples collected: {applesCollected}/{applesToWin}";
            int scoreTextPosX = (Console.WindowWidth - scoreText.Length) / 2;
            int consoleCenterY = (Console.WindowHeight - mapRows) / 2;

            Console.SetCursorPosition(scoreTextPosX, consoleCenterY + mapRows + 1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(scoreText);
        }
        public void DrawFrame(GameRenderData gameRenderData, SnakeGameController controller)
        {
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.UTF8;
            Console.Clear();
            ClearSnakeFromMap(gameRenderData.Map);
            PlaceApple(gameRenderData.Map, controller.TrySpawnApple());
            PlaceSnake(gameRenderData.Map, gameRenderData.EntityCoords);
            DrawMap(gameRenderData.Map, gameRenderData.LevelNumber);
            DrawScore(gameRenderData.ApplesCollected, gameRenderData.ApplesToWin, gameRenderData.Map.GetLength(0));
        }
    }
}