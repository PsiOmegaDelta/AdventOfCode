namespace AdventOfCode2021.Day07
{
    public static class PartTwo
    {
        public static async Task<int> CalculateResult(string inputPath)
        {
            var crabsByPosition = await InputParser.ParseInput(inputPath).ConfigureAwait(false);
            var minCost = int.MaxValue;
            for (var targetPosition = 0; targetPosition < crabsByPosition.Length; targetPosition++)
            {
                var totalFuelCost = 0;
                for (var crabPosition = 0; crabPosition < crabsByPosition.Length; crabPosition++)
                {
                    var distance = Math.Abs(targetPosition - crabPosition);
                    totalFuelCost += distance * (distance + 1) * crabsByPosition[crabPosition] / 2;
                }

                minCost = Math.Min(minCost, totalFuelCost);
            }

            return minCost;
        }
    }
}
