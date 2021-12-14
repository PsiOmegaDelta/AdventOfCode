using AdventOfCode.Shared.Extensions;
using System.Collections.Immutable;

namespace AdventOfCode2021.Day12
{
    public static class PartOne
    {
        public static int CalculatePartOne(this IEnumerable<string> input)
        {
            var edges = new Dictionary<string, ISet<string>>();
            foreach (var group in input.Select(x => x.Split('-')).GroupBy(x => x[0], x => x[1]))
            {
                var otherNodes = group.ToHashSet();
                edges.GetOrAdd(group.Key, _ => new HashSet<string>()).AddRange(otherNodes);
                foreach (var node in otherNodes)
                {
                    edges.GetOrAdd(node, _ => new HashSet<string>()).Add(group.Key);
                }
            }

            return GetPaths(edges, ImmutableList<string>.Empty, "start").Count();
        }

        private static IEnumerable<IReadOnlyList<string>> GetPaths(
            IDictionary<string, ISet<string>> edges,
            IImmutableList<string> visitedNodes,
            string nodeToVisit)
        {
            visitedNodes = visitedNodes.Add(nodeToVisit);
            if (nodeToVisit == "end")
            {
                yield return visitedNodes;
            }
            else
            {
                foreach (var neighbour in edges[nodeToVisit].Where(x => !visitedNodes.Contains(x) || x == x.ToUpper()))
                {
                    foreach (var path in GetPaths(edges, visitedNodes, neighbour).ToList())
                    {
                        yield return path;
                    }
                }
            }
        }
    }
}
