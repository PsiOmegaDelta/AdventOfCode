using System.Text.RegularExpressions;

namespace AdventOfCode2015.Day15
{
    public static class InputParser
    {
        public static IEnumerable<Ingredient> ParseInput(this IEnumerable<string> inputs)
        {
            var regex = new Regex(@"^(.+): capacity (-{0,1}\d+), durability (-{0,1}\d+), flavor (-{0,1}\d+), texture (-{0,1}\d+), calories (-{0,1}\d+)$", RegexOptions.Compiled);
            foreach (var input in inputs)
            {
                var match = regex.Match(input);
                yield return new Ingredient(
                    match.Groups[1].Value,
                    int.Parse(match.Groups[2].Value),
                    int.Parse(match.Groups[3].Value),
                    int.Parse(match.Groups[4].Value),
                    int.Parse(match.Groups[5].Value),
                    int.Parse(match.Groups[6].Value));
            }
        }
    }
}
