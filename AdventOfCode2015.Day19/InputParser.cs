using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System.Collections.Generic;

namespace AdventOfCode2015.Day19
{
    public static class InputParser
    {
        public static (IReadOnlyList<(string, string)> Transformations, IReadOnlyList<string> Molecules) ParseInput(this IEnumerable<string> inputs)
        {
            using var enumerator = inputs.GetEnumerator();

            var transformations = new List<(string, string)>();
            while (enumerator.MoveNext())
            {
                var input = enumerator.Current;
                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                var split = input.Split(" => ");
                transformations.Add((split[0], split[1]));
            }

            var molecules = new List<string>();
            while (enumerator.MoveNext())
            {
                molecules.Add(enumerator.Current);
            }

            return (transformations, molecules);
        }
    }
}
