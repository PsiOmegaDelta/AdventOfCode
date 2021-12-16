using AdventOfCode.Shared.Extensions;

namespace AdventOfCode2015.Day11
{
    public static class PartOne
    {
        public static string CalculatePartOne(this string input)
        {
            while (true)
            {
                input = input.Increment();
                if (input.IsGoodPassword())
                {
                    return input;
                }
            }
        }

        private static bool IsGoodPassword(this string input)
        {
            var badChars = new HashSet<char> { 'i', 'o', 'l' };
            if (input.Any(x => badChars.Contains(x)))
            {
                return false;
            }

            if (!input.Pairs().Any(x => x.Item1[0] == x.Item1[1] && x.Item2[0] == x.Item2[1]))
            {
                return false;
            }

            for (int i = 0; i < input.Length - 3; i++)
            {
                if ((input[i] + 2) <= 'z' && (input[i + 1] + 1) <= 'z' && input[i] + 2 == input[i + 1] + 1 && input[i] + 2 == input[i + 2])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
