namespace AdventOfCode2021.Day06
{
    public static class PartOne
    {
        // The naive solution
        public static async Task<long> CalculateResult(string inputPath, int daysToSimulate)
        {
            var lanternfish = (await File.ReadAllTextAsync(inputPath))
                .Split(',')
                .Select(x => int.Parse(x))
                .Select(x => new Lanternfish(x, false));

            for (int i = 0; i < daysToSimulate; i++)
            {
                lanternfish = lanternfish.DecreaseTimer();
            }

            return lanternfish.Count();
        }
    }
}
