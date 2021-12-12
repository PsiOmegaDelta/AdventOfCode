namespace AdventOfCode2021.Shared.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> source, T item)
        {
            return source.Concat(item.ToEnumerable());
        }

        public static IEnumerable<T> Duplicates<T>(this IEnumerable<T> source)
        {
            return source.Duplicates(EqualityComparer<T>.Default, false);
        }

        public static IEnumerable<T> Duplicates<T>(this IEnumerable<T> source, bool returnDuplicatesMultipleTimes)
        {
            return source.Duplicates(EqualityComparer<T>.Default, returnDuplicatesMultipleTimes);
        }

        public static IEnumerable<T> Duplicates<T>(this IEnumerable<T> source, IEqualityComparer<T> equalityComparer, bool returnDuplicatesMultipleTimes)
        {
            var checkedElements = new HashSet<T>(equalityComparer);
            var returnedElements = new HashSet<T>(equalityComparer);

            foreach (var item in source)
            {
                if (checkedElements.Contains(item) && (!returnedElements.Contains(item) || returnDuplicatesMultipleTimes))
                {
                    returnedElements.Add(item);
                    yield return item;
                }
                else
                {
                    checkedElements.Add(item);
                }
            }
        }

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
