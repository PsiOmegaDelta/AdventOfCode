﻿using AdventOfCode.Shared.Extensions;

namespace AdventOfCode2015.Day09
{
    public static class PartTwo
    {
        public static long CalculatePartTwo(this IEnumerable<string> input)
        {
            var graph = input.ParseInput();
            var cities = graph.Keys.ToList();

            var highestCost = 0;
            for (int n = 0; n < cities.Count; n++)
            {
                for (int m = n + 1; m < cities.Count; m++)
                {
                    var start = cities[n];
                    var end = cities[m];
                    foreach (var path in graph.AllPaths(start, end))
                    {
                        var cost = path.Zip(path.Skip(1)).Select(x => graph[x.First][x.Second]).Sum();
                        if (cost > highestCost)
                        {
                            highestCost = cost;
                        }
                    }
                }
            }

            return highestCost;
        }
    }
}
