namespace SnakeGame.Levels
{
    public interface ICellProcessor
    {
        public string Process(CellContext cellContext);
    }
}