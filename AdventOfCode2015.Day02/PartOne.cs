using AdventOfCode.Shared;

namespace AdventOfCode2015.Day02
{
    public static class PartOne
    {
        public static long CalculatePartOne(this IEnumerable<(int Length, int Width, int Height)> input)
        {
            return input
                .Select(x => (2 * x.Length * x.Width) + (2 * x.Width * x.Height) + (2 * x.Height * x.Length) + ExtraMath.Min(x.Length * x.Width, x.Length * x.Height, x.Width * x.Height))
                .Sum();
        }
    }
}
