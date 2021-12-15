using AdventOfCode.Shared;

namespace AdventOfCode2015.Day03
{
    public static class InputParser
    {
        private static readonly IDictionary<char, Func<Coordinate, Coordinate>> coordinatesByChar = new Dictionary<char, Func<Coordinate, Coordinate>>
        {
            { '>', c => c with { X = c.X + 1 } },
            { '<', c => c with { X = c.X - 1 } },
            { '^', c => c with { Y = c.Y + 1 } },
            { 'v', c => c with { Y = c.Y - 1 } }
        };

        public static IEnumerable<Func<Coordinate, Coordinate>> ParseInput(this string input)
        {
            return input.Select(x => coordinatesByChar[x]);
        }
    }
}
