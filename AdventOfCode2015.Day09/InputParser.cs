using AdventOfCode.Shared.Extensions;
using System.Collections.Immutable;

namespace AdventOfCode2015.Day09
{
    public static class InputParser
    {
        public static IReadOnlyDictionary<string, IReadOnlyDictionary<string, int>> ParseInput(this IEnumerable<string> inputs)
        {
            var nodesAndNeighbours = new Dictionary<string, Dictionary<string, int>>();

            foreach (var input in inputs)
            {
                var split = input.Split(new string[] { " to ", " = " }, StringSplitOptions.RemoveEmptyEntries);
                var from = split[0];
                var to = split[1];
                var distance = int.Parse(split[2]);

                nodesAndNeighbours.GetOrAdd(from, _ => new Dictionary<string, int>())[to] = distance;
                nodesAndNeighbours.GetOrAdd(to, _ => new Dictionary<string, int>())[from] = distance;
            }

            return nodesAndNeighbours.ToImmutableDictionary(x => x.Key, x => (IReadOnlyDictionary<string, int>)x.Value.ToImmutableDictionary());
        }
    }
}
