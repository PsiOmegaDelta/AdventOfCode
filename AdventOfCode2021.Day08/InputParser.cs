namespace AdventOfCode2021.Day08
{
    public static class InputParser
    {
        public static IEnumerable<string[]> ParseInput(string inputPath)
        {
            foreach (var line in File.ReadLines(inputPath))
            {
                yield return line
                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .SelectMany(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
                    .ToArray();
            }
        }
    }
}
