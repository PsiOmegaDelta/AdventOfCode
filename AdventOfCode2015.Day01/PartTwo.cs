namespace AdventOfCode2015.Day01
{
    public static class PartTwo
    {
        public static long CalculatePartTwo(this string input)
        {
            var floor = 0;
            using var charEnumerator = input.GetEnumerator();
            for (var position = 1; charEnumerator.MoveNext(); position++)
            {
                floor += charEnumerator.Current == '(' ? 1 : -1;
                if (floor < 0)
                {
                    return position;
                }
            }

            return -1;
        }
    }
}
