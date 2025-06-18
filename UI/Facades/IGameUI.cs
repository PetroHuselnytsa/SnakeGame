using SnakeGame.Controllers;
using SnakeGame.Enums;
using SnakeGame.UI.Renderers.Records;


namespace SnakeGame.UI.Facades
{
    public interface IGameUI
    {
        public void DrawFrame(GameRenderData renderData, SnakeGameController controller);
        public GameState ShowMenu();
        public void ShowSettings();
        public void ShowWinScreen(GameRenderData renderData);
        public void ShowLoseScreen(GameRenderData renderData);
    }
}