using AdventOfCode.Shared.Extensions;

namespace AdventOfCode2022.Day09
{
    public enum Direction
    {
        U,
        D,
        R,
        L
    }

    public static class InputParser
    {
        public static IEnumerable<(Direction, int)> ParseInput(this IEnumerable<string> input)
        {
            return input.Select(x => x.Split(' ')).Select(x => (x[0].ToEnum<Direction>(), int.Parse(x[1])));
        }
    }
}
