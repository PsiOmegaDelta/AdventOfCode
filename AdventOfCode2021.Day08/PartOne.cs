namespace AdventOfCode2021.Day08
{
    public static class PartOne
    {
        public static int CalculateResult(string inputPath)
        {
            return InputParser.ParseInput(inputPath).Sum(x => x.TakeLast(4).Count(y => y.Length == 2 || y.Length == 3 || y.Length == 4 || y.Length == 7));
        }
    }
}
