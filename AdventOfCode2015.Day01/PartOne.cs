namespace AdventOfCode2015.Day01
{
    public static class PartOne
    {
        public static long CalculatePartOne(this string input)
        {
            return input.Aggregate(0, (floor, bracket) => bracket == '(' ? floor + 1 : floor - 1);
        }
    }
}
