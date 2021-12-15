namespace AdventOfCode2015.Day05
{
    public static class PartOne
    {
        private static readonly IReadOnlySet<string> naughties = new HashSet<string> { "ab", "cd", "pq", "xy" };
        private static readonly IReadOnlySet<char> vowels = "aeiou".ToHashSet();

        public static long CalculatePartOne(this IEnumerable<string> inputs)
        {
            return inputs.LongCount(x => naughties.All(y => !x.Contains(y)) && x.Count(y => vowels.Contains(y)) >= 3 && HasPair(x));
        }

        private static bool HasPair(this string input)
        {
            for (var i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == input[i + 1])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
