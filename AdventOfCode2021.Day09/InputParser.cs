namespace AdventOfCode2021.Day09
{
    public static class InputParser
    {
        public static int[][] ParseInput(string inputPath)
        {
            return File.ReadLines(inputPath)
                .Select(x => x.Where(char.IsDigit).Select(x => (int)char.GetNumericValue(x)).ToArray())
                .ToArray();
        }
    }
}
