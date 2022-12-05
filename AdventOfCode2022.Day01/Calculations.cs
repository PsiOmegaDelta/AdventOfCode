using System.Text;

namespace AdventOfCode2022.Day01
{
    public static class Calculations
    {
        public static long CalculatePartOne(this IEnumerable<IReadOnlyList<int>> input)
        {
            return input.Max(x => x.Sum());
        }

        public static long CalculatePartTwo(this IEnumerable<IReadOnlyList<int>> input)
        {
            return input.Select(x => x.Sum()).OrderByDescending(x => x).Take(3).Sum();
        }
    }
}
