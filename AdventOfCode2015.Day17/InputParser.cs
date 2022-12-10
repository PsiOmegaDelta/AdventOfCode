namespace AdventOfCode2015.Day17
{
    public static class InputParser
    {
        public static IEnumerable<int> ParseInput(this IEnumerable<string> inputs)
        {
            return inputs.Select(int.Parse);
        }
    }
}
