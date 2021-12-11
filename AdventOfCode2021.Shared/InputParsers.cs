namespace AdventOfCode2021.Shared.InputParsers
{
    public static class InputParsers
    {
        public static int[][] ToIntArrays(this IEnumerable<string> input)
        {
            return input
                .Select(x => x.Where(char.IsDigit).Select(x => (int)char.GetNumericValue(x)).ToArray())
                .ToArray();
        }
    }
}
