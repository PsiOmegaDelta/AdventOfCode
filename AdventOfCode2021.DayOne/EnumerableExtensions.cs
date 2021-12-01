using System.Collections.Generic;

namespace AdventOfCode2021.DayOne
{
    public static class EnumerableExtensions
    {
        public static int GetIncrementations<T>(this IEnumerable<T> input)
        {
            return input.GetIncrementations(Comparer<T>.Default);
        }

        public static int GetIncrementations<T>(this IEnumerable<T> input, IComparer<T> comparer)
        {
            var incrementations = 0;
            using var enumeratator = input.GetEnumerator();
            T previousEntry = default;
            if (enumeratator.MoveNext())
            {
                previousEntry = enumeratator.Current;
            }

            while (enumeratator.MoveNext())
            {
                var entry = enumeratator.Current;
                if (comparer.Compare(entry, previousEntry) == 1)
                {
                    incrementations++;
                }

                previousEntry = entry;
            }

            return incrementations;
        }
    }
}
