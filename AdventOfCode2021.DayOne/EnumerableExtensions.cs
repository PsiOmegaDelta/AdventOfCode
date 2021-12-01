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
    }
}
