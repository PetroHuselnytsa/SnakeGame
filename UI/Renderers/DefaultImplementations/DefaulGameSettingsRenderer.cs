using SnakeGame.Utilites;
using SnakeGame.UI.Renderers.Interfaces;


namespace SnakeGame.UI.Renderers.DefaultImplementations
{
    public class DefaulGameSettingsRenderer : IGameSettingsRenderer
    {
        public void ShowSettings()
        {
            string[] rules = {
            "SNAKE GAME RULES:",
            "",
            "1. Complete levels to reach the highest rank",
            "2. Collect apples (●) to grow your snake",
            "3. Avoid crashing into walls or yourself",
            "",
            "CONTROLS:",
            "",
            "    W    ",
            "  A + D   ",
            "    S    ",
            "",
            "W - Move Up",
            "A - Move Left",
            "S - Move Down",
            "D - Move Right",
            };
            TextScreenPrinter.ShowCenteredLines(rules, ConsoleColor.Cyan);
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.Write("Press any key to return to menu...");
            Console.ReadKey(intercept: true);
        }
    }
}