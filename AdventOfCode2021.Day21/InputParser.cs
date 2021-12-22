using System.Text.RegularExpressions;

namespace AdventOfCode2021.Day21
{
    public static class InputParser
    {
        public static IEnumerable<Player> ParseInput(this IEnumerable<string> inputs)
        {
            var regex = new Regex(@"(.+) starting position: (\d+)");
            foreach (var input in inputs)
            {
                var match = regex.Match(input);
                yield return new Player(match.Groups[1].Value, int.Parse(match.Groups[2].Value), 0);
            }
        }
    }
}
