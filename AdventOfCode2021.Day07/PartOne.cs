namespace AdventOfCode2021.Day07
{
    public static class PartOne
    {
        public static async Task<int> CalculateResult(string inputPath)
        {
            var crabsByPosition = await InputParser.ParseInput(inputPath).ConfigureAwait(false);
            var minCost = int.MaxValue;
            for (var targetPosition = 0; targetPosition < crabsByPosition.Length; targetPosition++)
            {
                var fuelCost = 0;
                for (var crabPosition = 0; crabPosition < crabsByPosition.Length; crabPosition++)
                {
                    fuelCost += Math.Abs(targetPosition - crabPosition) * crabsByPosition[crabPosition];
                }

                minCost = Math.Min(minCost, fuelCost);
            }

            return minCost;
        }
    }
}
