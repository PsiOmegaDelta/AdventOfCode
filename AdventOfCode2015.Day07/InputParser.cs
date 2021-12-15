namespace AdventOfCode2015.Day07
{
    public static class InputParser
    {
        public static IEnumerable<WireSetup> ParseInput(this IEnumerable<string> inputs)
        {
            return inputs.Select(x => x.Split(" -> ")).Select(x => new WireSetup(x[1], x[0]));
        }
    }
}
