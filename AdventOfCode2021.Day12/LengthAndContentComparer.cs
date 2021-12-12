namespace AdventOfCode2021.Day12
{
    public static partial class PartTwo
    {
        private class LengthAndContentComparer<T> : IComparer<IEnumerable<T>>
        {
            public int Compare(IEnumerable<T>? x, IEnumerable<T>? y)
            {
                if (x == null || y == null)
                {
                    return x == y ? 0 : (x == null ? 1 : -1);
                }

                using var xenumerator = x.GetEnumerator();
                using var yenumerator = y.GetEnumerator();
                var xCouldMoveNext = false;
                var yCouldMoveNext = false;

                while ((xCouldMoveNext = xenumerator.MoveNext()) && (yCouldMoveNext = yenumerator.MoveNext()))
                {
                    var comparison = Comparer<T>.Default.Compare(xenumerator.Current, yenumerator.Current);
                    if (comparison != 0)
                    {
                        return comparison;
                    }
                }

                return xCouldMoveNext == yCouldMoveNext ? 0 : (xCouldMoveNext ? -1 : 1);
            }
        }
    }
}
