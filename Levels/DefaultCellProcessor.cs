namespace SnakeGame.Levels
{
    public class DefaultCellProcessor : ICellProcessor
    {
        public string Process(CellContext cellContext)
        {
            if (cellContext.Row == 0 || cellContext.Row == cellContext.TotalRows - 1
               || cellContext.Col == 0 || cellContext.Col == cellContext.TotalCols - 1)
                return "#";

            if (cellContext.CurrentSymbol != "#") return " ";

            return cellContext.CurrentSymbol;
        }
    }
}