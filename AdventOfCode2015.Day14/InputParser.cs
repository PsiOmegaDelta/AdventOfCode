using System.Text.RegularExpressions;

namespace AdventOfCode2015.Day14
{
    public static class InputParser
    {
        public static IEnumerable<Reindeer> ParseInput(this IEnumerable<string> inputs)
        {
            var regex = new Regex(@"^(.+) can fly (\d+) km\/s for (\d+) seconds, but then must rest for (\d+) seconds.$", RegexOptions.Compiled);
            foreach (var input in inputs)
            {
                var match = regex.Match(input);
                yield return new Reindeer(
                    match.Groups[1].Value,
                    int.Parse(match.Groups[2].Value),
                    int.Parse(match.Groups[3].Value),
                    int.Parse(match.Groups[4].Value));
            }
        }
    }
}
