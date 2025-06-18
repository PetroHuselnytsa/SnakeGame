using SnakeGame.Controllers;
using SnakeGame.Enums;
using SnakeGame.UI.Renderers.Interfaces;
using SnakeGame.UI.Renderers.Records;


namespace SnakeGame.UI.Facades
{
    public class DefaultGameUIFacade : IGameUI
    {
        private readonly IGameFrameRenderer _frameRenderer;
        private readonly IGameMenuRenderer _menuRenderer;
        private readonly IGameSettingsRenderer _settingsRenderer;
        private readonly IGameEndScreenRenderer _endRenderer;
        public DefaultGameUIFacade(
            IGameFrameRenderer frameRenderer, 
            IGameMenuRenderer menuRenderer, 
            IGameSettingsRenderer settingsRenderer, 
            IGameEndScreenRenderer endRenderer)
        {
            _frameRenderer = frameRenderer;
            _menuRenderer = menuRenderer;
            _settingsRenderer = settingsRenderer;
            _endRenderer = endRenderer;
        }

        public void DrawFrame(GameRenderData renderData, SnakeGameController controller) => _frameRenderer.DrawFrame(renderData, controller);
        public void ShowLoseScreen(GameRenderData renderData) => _endRenderer.ShowLoseScreen(renderData);
        public void ShowWinScreen(GameRenderData renderData) => _endRenderer.ShowWinScreen(renderData);
        public GameState ShowMenu() => _menuRenderer.ShowMenu();
        public void ShowSettings() => _settingsRenderer.ShowSettings();
    }
}