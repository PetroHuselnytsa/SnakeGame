namespace SnakeGame.Levels
{
    // GAME ENTITY


    // LEVELS
    public record CellContext(
       int Row,
       int Col,
       string CurrentSymbol,
       int TotalRows,
       int TotalCols
   );
}