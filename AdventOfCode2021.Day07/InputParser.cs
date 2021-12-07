using AdventOfCode2021.Shared.Extensions;

namespace AdventOfCode2021.Day07
{
    public static class InputParser
    {
        public static async Task<int[]> ParseInput(string inputPath)
        {
            var splitInput = (await File.ReadAllTextAsync(inputPath)).Split(',').Select(x => int.Parse(x)).ToArray();
            var crabsByPosition = new int[splitInput.Max() + 1];
            splitInput.ForEach(x => crabsByPosition[x]++);
            return crabsByPosition;
        }
    }
}
