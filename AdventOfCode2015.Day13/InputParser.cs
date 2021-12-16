using AdventOfCode.Shared.Extensions;
using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace AdventOfCode2015.Day13
{
    public static class InputParser
    {
        public static IReadOnlyDictionary<string, IReadOnlyDictionary<string, int>> ParseInput(this IEnumerable<string> inputs)
        {
            var regex = new Regex(@"^(.+) would (gain|lose) (\d+) happiness units by sitting next to (.+).$");
            var graph = new Dictionary<string, Dictionary<string, int>>();
            foreach (var input in inputs)
            {
                var match = regex.Match(input);
                var personOne = match.Groups[1].Value;
                var gain = match.Groups[2].Value == "gain";
                var adjustment = int.Parse(match.Groups[3].Value);
                var personTwo = match.Groups[4].Value;

                graph.GetOrAdd(personOne, _ => new Dictionary<string, int>()).Add(personTwo, gain ? adjustment : -adjustment);
            }

            return graph.ToImmutableDictionary(x => x.Key, x => (IReadOnlyDictionary<string, int>)x.Value.ToImmutableDictionary());
        }
    }
}
