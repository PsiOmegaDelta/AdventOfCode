namespace AdventOfCode2021.Shared.Extensions
{
    public static class EnumerableExtensions
    {
        public static IReadOnlyList<TOut> ForEach<TIn, TOut>(this IEnumerable<TIn> source, Func<TIn, TOut> forEach)
        {
            var eachResult = new List<TOut>();
            foreach (var item in source)
            {
                eachResult.Add(forEach(item));
            }

            return eachResult;
        }

        public static void ForEach<TIn>(this IEnumerable<TIn> source, Action<TIn> forEach)
        {
            foreach (var item in source)
            {
                forEach(item);
            }
        }

        public static long Product(this IEnumerable<int> source)
        {
            return source.Aggregate(1L, (acc, val) => acc * val);
        }

        public static IEnumerable<T> ToEnumerable<T>(this T item)
        {
            yield return item;
        }
    }
}
