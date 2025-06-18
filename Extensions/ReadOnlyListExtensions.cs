namespace SnakeGame.Extensions
{
    // STATIC
    public static class ReadOnlyListExtensions
    {
        public static int IndexOf<T>(this IReadOnlyList<T> list, T item)
        {
            ArgumentNullException.ThrowIfNull(list);
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;

            for (int i = 0; i < list.Count; i++)
            {
                if (comparer.Equals(list[i], item))
                    return i;
            }

            return -1;
        }
    }
}