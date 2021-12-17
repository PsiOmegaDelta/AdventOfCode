using AdventOfCode.Shared;
using System.Text.RegularExpressions;

namespace AdventOfCode2021.Day17
{
    public static class InputParser
    {
        public static (Coordinate start, Coordinate end) ParseInput(this string input)
        {
            var regex = new Regex(@"^target area: x=(\d+)..(\d+), y=(-\d+)..(-\d+)$");
            var match = regex.Match(input);
            return (
                new Coordinate(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[4].Value)),
                new Coordinate(int.Parse(match.Groups[2].Value), int.Parse(match.Groups[3].Value)));
        }
    }
}
