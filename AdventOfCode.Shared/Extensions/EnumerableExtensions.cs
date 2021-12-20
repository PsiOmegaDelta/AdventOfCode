using AdventOfCode.Shared.Extensions;
using System.Numerics;

namespace AdventOfCode.Shared.Extensions
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

        public static IEnumerable<T> Except<T>(this IEnumerable<T> source, T item)
        {
            return source.Except(item.ToEnumerable());
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
            return source.Product(x => x);
        }

        public static long Product<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
        {
            return source.Aggregate(1L, (acc, val) => acc * selector(val));
        }

        public static BigInteger Product<TSource>(this IEnumerable<TSource> source, Func<TSource, BigInteger> selector)
        {
            return source.Select(selector).Product();
        }

        public static BigInteger Product(this IEnumerable<BigInteger> source)
        {
            return source.Aggregate(BigInteger.One, (acc, val) => BigInteger.Multiply(acc, val));
        }

        public static IEnumerable<(T Element, int Index)> SelectIndex<T>(this IEnumerable<T> source)
        {
            return source.Select((x, i) => (x, i));
        }

        public static BigInteger Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, BigInteger> selector)
        {
            return source.Select(selector).Sum();
        }

        public static BigInteger Sum(this IEnumerable<BigInteger> source)
        {
            return source.Aggregate(BigInteger.Zero, (acc, val) => BigInteger.Add(acc, val));
        }

        public static IEnumerable<T> ToEnumerable<T>(this T item)
        {
            yield return item;
        }

        public static Sequence<T> ToSequence<T>(this IEnumerable<T> source)
        {
            return new Sequence<T>(source);
        }
    }
}
