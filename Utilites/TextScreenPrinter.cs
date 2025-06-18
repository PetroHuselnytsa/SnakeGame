using System.Text;


namespace SnakeGame.Utilites
{
    public static class TextScreenPrinter
    {
        public static void ShowCenteredLines(string[] lines, ConsoleColor consoleColor)
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.ForegroundColor = consoleColor;
            Console.OutputEncoding = Encoding.UTF8;

            int centerY = (Console.WindowHeight - lines.Length) / 2;
            foreach (var line in lines)
            {
                int centerX = (Console.WindowWidth - line.Length) / 2;
                Console.SetCursorPosition(centerX, centerY++);
                Console.Write(line);
            }
        }
    }
}