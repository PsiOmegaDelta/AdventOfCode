using System.Collections.Generic;

namespace AdventOfCode2021.DayOne
{
    public static class EnumerableExtensions
    {
        public static int GetNumberOfIncrements(this IEnumerable<int> input)
        {
            int? previousNumber = null;
            var increases = 0;
            foreach (var entry in input)
            {
                if (entry > previousNumber)
                {
                    increases++;
                }

                previousNumber = entry;
            }

            return increases;
        }

        public static IEnumerable<int> SumGroups(this IEnumerable<int> input, int groupSize)
        {
            var group = new Queue<int>(groupSize);
            foreach (var entry in input)
            {
                if (group.Count == groupSize)
                {
                    yield return group.Sum();
                }

                group.Enqueue(entry);
                if (group.Count > groupSize)
                {
                    group.Dequeue();
                }
            }

            yield return group.Sum();
        }
    }
}
