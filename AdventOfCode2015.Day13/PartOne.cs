using AdventOfCode.Shared.Extensions;
using MoreLinq.Extensions;

namespace AdventOfCode2015.Day13
{
    public static class PartOne
    {
        public static int CalculatePartOne(this IReadOnlyDictionary<string, IReadOnlyDictionary<string, int>> input)
        {
            var mostHappiness = 0;
            foreach (var combination in input.Keys.Permutations().Where(x => x.Count == input.Count))
            {
                var totalHappiness = combination.Zip(combination.Skip(1).Concat(combination.Take(1))).Sum(x => input[x.First][x.Second] + input[x.Second][x.First]);
                if (totalHappiness > mostHappiness)
                {
                    mostHappiness = totalHappiness;
                }
            }

            return mostHappiness;
        }
    }
}
