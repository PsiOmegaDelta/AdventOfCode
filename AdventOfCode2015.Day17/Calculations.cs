using AdventOfCode.Shared;
using System.Collections.Immutable;

namespace AdventOfCode2015.Day17
{
    public static class Calculations
    {
        public static long CalculatePartOne(this ImmutableQueue<int> containers, int amount)
        {
            return Variants(containers, amount);

            static long Variants(ImmutableQueue<int> containerSizes, int amount)
            {
                if (amount == 0)
                {
                    return 1;
                }

                var containerSize = containerSizes.Peek();
                containerSizes = containerSizes.Dequeue();
                var remaining = amount - containerSize;

                if (containerSizes.IsEmpty)
                {
                    return remaining == 0 ? 1 : 0;
                }

                return Variants(containerSizes, amount) + (remaining < 0 ? 0 : Variants(containerSizes, remaining));
            }
        }

        public static long CalculatePartTwo(this ImmutableQueue<int> containerSizes, int amount)
        {
            return Variants(containerSizes, amount, 0).GroupBy(x => x).MinBy(x => x.Key)?.Count() ?? 0;

            static IEnumerable<long> Variants(ImmutableQueue<int> containerSizes, int amount, int usedContainers)
            {
                if (amount == 0)
                {
                    yield return usedContainers;
                    yield break;
                }

                if (containerSizes.IsEmpty)
                {
                    yield break;
                }

                var containerSize = containerSizes.Peek();
                containerSizes = containerSizes.Dequeue();
                var remaining = amount - containerSize;

                foreach (var uses in Variants(containerSizes, amount, usedContainers))
                {
                    yield return uses;
                }

                if (remaining >= 0)
                {
                    foreach (var uses in Variants(containerSizes, remaining, usedContainers + 1))
                    {
                        yield return uses;
                    }
                }
            }
        }
    }
}
