using SnakeGame.Controllers;
using SnakeGame.UI.Renderers.Records;

namespace SnakeGame.UI.Renderers.Interfaces
{
    public interface IGameFrameRenderer
    {
        void DrawFrame(GameRenderData gameRenderData, SnakeGameController controller);
    }
}