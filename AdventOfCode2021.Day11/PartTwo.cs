namespace AdventOfCode2021.Day11
{
    public static class PartTwo
    {
        public static long CalculatePartTwo(this int[][] input)
        {
            var step = 0L;
            long flashes;
            var arraySize = input.Length * input[0].Length;
            do
            {
                (input, flashes) = input.ConductStep();
                step++;
            } while (flashes != arraySize);

            return step;
        }
    }
}
