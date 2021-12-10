namespace AdventOfCode2021.Day10
{
    public static class PartOne
    {
        private static readonly IReadOnlyDictionary<char, int> bracketPoints = new Dictionary<char, int>
        {
            { ')', 3 },
            { ']', 57 },
            { '}', 1197 },
            { '>', 25137 }
        };

        public static int CalculateResult(IEnumerable<string> input)
        {
            return input.Select(x => x.InvalidBrackets().Take(1).CalculatePoints()).Sum();
        }

        private static int CalculatePoints(this IEnumerable<char> input)
        {
            return input.Select(x => bracketPoints[x]).Sum();
        }
    }
}
