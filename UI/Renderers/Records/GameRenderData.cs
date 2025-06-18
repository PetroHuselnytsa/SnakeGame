using SnakeGame.Structs;


namespace SnakeGame.UI.Renderers.Records
{
    // LEVELS

    // UI
    public record GameRenderData(
       string[,] Map,
       IReadOnlyList<Point> EntityCoords,
       int ApplesCollected,
       int ApplesToWin,
       int LevelNumber
    );
}