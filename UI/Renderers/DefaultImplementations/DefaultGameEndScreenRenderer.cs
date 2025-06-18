using SnakeGame.Utilites;
using SnakeGame.Audio;
using SnakeGame.UI.Renderers.Interfaces;
using SnakeGame.UI.Renderers.Records;


namespace SnakeGame.UI.Renderers.DefaultImplementations
{
    public class DefaultGameEndScreenRenderer : IGameEndScreenRenderer
    {
        private readonly ISoundManager _soundManager;
        public DefaultGameEndScreenRenderer(ISoundManager soundManager)
        {
            _soundManager = soundManager;
        }
        public void ShowLoseScreen(GameRenderData gameRenderData)
        {
            _soundManager.PlaySound("mixkit-losing-bleeps-2026.wav");
            string[] lines =
            {
                "YOU LOSE!",
                $"Apples Collected: {gameRenderData.ApplesCollected}",
                $"Apples Need: {gameRenderData.ApplesToWin}"
            };
            TextScreenPrinter.ShowCenteredLines(lines, ConsoleColor.Red);
            Thread.Sleep(2000);
        }
        public void ShowWinScreen(GameRenderData gameRenderData)
        {
            _soundManager.PlaySound("level-win-6416.wav");
            string[] lines =
            [
                $"YOU COMPLETED THE LEVEL {gameRenderData.LevelNumber}!",
                $"Apples Collected: {gameRenderData.ApplesCollected}",
                $"Apples Need: {gameRenderData.ApplesToWin}"
            ];
            TextScreenPrinter.ShowCenteredLines(lines, ConsoleColor.Green);
            Thread.Sleep(2500);
        }
    }
}