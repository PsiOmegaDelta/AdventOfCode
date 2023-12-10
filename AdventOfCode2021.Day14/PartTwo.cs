using AdventOfCode.Shared.Extensions;
using System.Collections.Immutable;

namespace AdventOfCode2021.Day14
{
    public static class PartTwo
    {
        public static long CalculatePartTwo(this (string Template, IReadOnlyDictionary<string, char> Inserts) input, int steps)
        {
            // It's fortunate that we only need to keep track of the total character count...
            var characterCount = input.Template.GroupBy(x => x).ToDictionary(x => x.Key, x => x.LongCount());
            var pairCount = ImmutableDictionary<string, long>.Empty;

            for (int i = 0; i < input.Template.Length - 1; i++)
            {
                var pair = input.Template.Substring(i, 2);
                var amount = pairCount.GetValueOrDefault(pair, _ => 0) + 1;
                pairCount = pairCount.SetItem(pair, amount);
            }

            for (int step = 0; step < steps; step++)
            {
                foreach (var (pair, amount) in pairCount.Where(x => x.Value > 0))
                {
                    var reducedAmount = pairCount[pair] - amount;
                    pairCount = pairCount.SetItem(pair, reducedAmount);

                    var newChar = input.Inserts[pair];
                    characterCount[newChar] = characterCount.GetValueOrDefault(newChar, _ => 0) + amount;

                    foreach (var newPair in new string[] { new string(new char[] { pair[0], newChar }), new string(new char[] { newChar, pair[1] }) })
                    {
                        var increasedAmount = pairCount.GetValueOrDefault(newPair, _ => 0) + amount;
                        pairCount = pairCount.SetItem(newPair, increasedAmount);
                    }
                }
            }

            return characterCount.Max(x => x.Value) - characterCount.Min(x => x.Value);
        }
    }
}
