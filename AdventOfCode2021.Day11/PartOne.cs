namespace AdventOfCode2021.Day11
{
    public static class PartOne
    {
        public static long CalculatePartOne(this int[][] input, int steps)
        {
            var totalFlashes = 0L;
            for (int i = 1; i <= steps; i++)
            {
                long flashes;
                (input, flashes) = input.ConductStep();
                totalFlashes += flashes;
            }

            return totalFlashes;
        }
    }
}
