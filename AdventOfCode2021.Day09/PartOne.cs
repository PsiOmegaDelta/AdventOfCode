namespace AdventOfCode2021.Day09
{
    public static class PartOne
    {
        public static int CalculatePartOne(int[][] matrix)
        {
            return matrix.LowPointValues().Select(x => x + 1).Sum();
        }
    }
}
