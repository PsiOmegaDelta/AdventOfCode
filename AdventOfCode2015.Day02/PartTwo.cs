using ExtraMath = AdventOfCode.Shared.ExtraMath;

namespace AdventOfCode2015.Day02
{
    public static class PartTwo
    {
        public static long CalculatePartTwo(this IEnumerable<(int Length, int Width, int Height)> input)
        {
            return input
                .Select(x => ExtraMath.Min(2 * (x.Length + x.Width), 2 * (x.Length + x.Height), 2 * (x.Width + x.Height)) + (x.Length * x.Width * x.Height))
                .Sum();
        }
    }
}
