namespace AdventOfCode2021.Day10
{
    public static class PartTwo
    {
        private static readonly IReadOnlyDictionary<char, int> bracketPoints = new Dictionary<char, int>
        {
            { ')', 1 },
            { ']', 2 },
            { '}', 3 },
            { '>', 4 }
        };

        public static long CalculateResult(IEnumerable<string> input)
        {
            var scores = input.Where(x => !x.InvalidBrackets().Any()).Select(x => x.MissingBrackets().CalculatePoints()).OrderBy(x => x).ToArray();
            return scores[scores.Length / 2];
        }

        private static long CalculatePoints(this IEnumerable<char> input)
        {
            return checked(input.Aggregate(0L, (p, c) => (p * 5) + bracketPoints[c]));
        }
    }
}
