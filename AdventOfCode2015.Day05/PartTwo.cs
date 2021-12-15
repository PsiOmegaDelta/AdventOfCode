namespace AdventOfCode2015.Day05
{
    public static class PartTwo
    {
        public static long CalculatePartTwo(this IEnumerable<string> inputs)
        {
            return inputs.LongCount(x => HasSeparatedPair(x) && HasNonOverlappingPairs(x));
        }

        private static bool HasNonOverlappingPairs(this string input)
        {
            for (var n = 0; n < input.Length - 3; n++)
            {
                for (int m = n + 2; m < input.Length - 1; m++)
                {
                    if (input.Substring(n, 2) == input.Substring(m, 2))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool HasSeparatedPair(this string input)
        {
            for (var i = 0; i < input.Length - 2; i++)
            {
                if (input[i] == input[i + 2])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
