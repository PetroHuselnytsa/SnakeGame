using SnakeGame.Enums;
using SnakeGame.Audio;
using SnakeGame.UI.Renderers.Interfaces;


namespace SnakeGame.UI.Renderers.DefaultImplementations
{
    public class DefaultGameMenuRenderer : IGameMenuRenderer
    {
        private readonly ISoundManager _soundManager;
        public DefaultGameMenuRenderer(ISoundManager soundManager)
        {
            _soundManager = soundManager;
        }
        private void DrawMenu(List<MenuItem> items, int selectedIndex)
        {
            Console.Clear();
            Console.CursorVisible = false;

            for (int index = 0; index < items.Count; index++)
            {
                MenuItem currItem = items[index];

                int consoleCenterY = (Console.WindowHeight - 1) / 2 + index;
                int consoleCenterX = (Console.WindowWidth - currItem.Text.Length) / 2;

                Console.SetCursorPosition(consoleCenterX, consoleCenterY);
                Console.ForegroundColor = currItem.Color;
                Console.WriteLine(index == selectedIndex ? $"{currItem.Text} <" : $"{currItem.Text}");
            }

        }
        private int MenuInputHandle(int selectedIndex, int itemsCount)
        {
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (selectedIndex > 1)
                        {
                            _soundManager.PlaySound("90s-game-ui-3-185096.wav");
                            return selectedIndex - 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (selectedIndex < itemsCount - 1)
                        {
                            _soundManager.PlaySound("90s-game-ui-3-185096.wav");
                            return selectedIndex + 1;
                        }
                        break;
                    case ConsoleKey.Enter:
                        return -1;
                }
            }
        }
        public GameState ShowMenu()
        {
            List<MenuItem> menuItems = [
                new MenuItem("THE SNAKE GAME", ConsoleColor.DarkGreen, GameState.None),
                new MenuItem("PLAY", ConsoleColor.Yellow, GameState.Play),
                new MenuItem("SETTINGS", ConsoleColor.Gray, GameState.Settings),
                new MenuItem("EXIT", ConsoleColor.Red, GameState.Exit)
            ];

            int selectedIndex = 1;

            while (true)
            {
                DrawMenu(menuItems, selectedIndex);
                int inputIndexResult = MenuInputHandle(selectedIndex, menuItems.Count);

                if (inputIndexResult == -1)
                {
                    MenuItem choosenItem = menuItems[selectedIndex];
                    return choosenItem.GameState;
                }

                selectedIndex = inputIndexResult;
            }
        }
        private record MenuItem(string Text, ConsoleColor Color, GameState GameState);
    }
}