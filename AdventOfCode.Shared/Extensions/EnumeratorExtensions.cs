namespace AdventOfCode.Shared.Extensions
{
    public static class EnumeratorExtensions
    {
        public static IEnumerable<T> Take<T>(this IEnumerator<T> source, int length)
        {
            for (int i = 0; i < length; i++)
            {
                if (source.MoveNext())
                {
                    yield return source.Current;
                }
                else
                {
                    yield break;
                }
            }
        }

        public static bool TryTake<T>(this IEnumerator<T> source, int length, out IReadOnlyList<T> output)
        {
            var entries = new List<T>();
            output = entries;
            for (int i = 0; i < length; i++)
            {
                if (source.MoveNext())
                {
                    entries.Add(source.Current);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
