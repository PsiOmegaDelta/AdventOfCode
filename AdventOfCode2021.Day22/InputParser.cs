using AdventOfCode.Shared;
using System.Text.RegularExpressions;

namespace AdventOfCode2021.Day22
{
    public static class InputParser
    {
        public static IEnumerable<(bool, Coordinate3D, Coordinate3D)> ParseInput(this IEnumerable<string> inputs)
        {
            var regex = new Regex(@"^(on|off) x=(-{0,1}\d+)..(-{0,1}\d+),y=(-{0,1}\d+)..(-{0,1}\d+),z=(-{0,1}\d+)..(-{0,1}\d+)$");
            foreach (var input in inputs)
            {
                var match = regex.Match(input);
                var turnOn = match.Groups[1].Value == "on";
                var startCoordinate = new Coordinate3D(int.Parse(match.Groups[2].Value), int.Parse(match.Groups[4].Value), int.Parse(match.Groups[6].Value));
                var endCoordinate = new Coordinate3D(int.Parse(match.Groups[3].Value), int.Parse(match.Groups[5].Value), int.Parse(match.Groups[7].Value));
                yield return (turnOn, startCoordinate, endCoordinate);
            }
        }
    }
}
