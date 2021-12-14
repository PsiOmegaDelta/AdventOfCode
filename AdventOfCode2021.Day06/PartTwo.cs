using AdventOfCode.Shared.Extensions;

namespace AdventOfCode2021.Day06
{
    public static class PartTwo
    {
        // The slightly less naive solution
        public static async Task<long> CalculateResult(string inputPath, int daysToSimulate)
        {
            var lanternFishByTimer = new long[9];
            var lanternfish = (await File.ReadAllTextAsync(inputPath).ConfigureAwait(false))
                .Split(',')
                .Select(x => int.Parse(x))
                .ForEach(x => lanternFishByTimer[x]++);

            for (int day = 0; day < daysToSimulate; day++)
            {
                long fishToRelocate = 0;
                for (var index = 0; index < lanternFishByTimer.Length; index++)
                {
                    if (index == 0)
                    {
                        fishToRelocate = lanternFishByTimer[index];
                    }
                    else
                    {
                        lanternFishByTimer[index - 1] = lanternFishByTimer[index];
                    }
                }

                lanternFishByTimer[6] += fishToRelocate;
                lanternFishByTimer[8] = fishToRelocate;
            }

            return lanternFishByTimer.Sum();
        }
    }
}
