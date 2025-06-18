using SnakeGame.UI.Renderers.Records;

namespace SnakeGame.UI.Renderers.Interfaces
{
    public interface IGameEndScreenRenderer
    {
        void ShowLoseScreen(GameRenderData gameRenderData);
        void ShowWinScreen(GameRenderData gameRenderData);
    }
}