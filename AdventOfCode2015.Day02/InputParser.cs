namespace AdventOfCode2015.Day02
{
    public static class InputParser
    {
        public static IEnumerable<(int Length, int Width, int Height)> ParseInput(this IEnumerable<string> input)
        {
            return input
                .Select(x => x.Split('x'))
                .Select(x => (Length: int.Parse(x[0]), Width: int.Parse(x[1]), Height: int.Parse(x[2])));
        }
    }
}
