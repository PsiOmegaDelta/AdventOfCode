using AdventOfCode.Shared.Extensions;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day01
{
    public static partial class Calculations
    {
        private static IReadOnlyDictionary<string, string> wordToDigit = new Dictionary<string, string>
        {
            { "one", "1" },
            { "two", "2" },
            { "three", "3" },
            { "four", "4" },
            { "five", "5" },
            { "six", "6" },
            { "seven", "7" },
            { "eight", "8" },
            { "nine", "9" }
        };

        public static long CalculatePartOne(this IEnumerable<string> input)
        {
            return input.Sum(GetNumber);

            static int GetNumber(string input)
            {
                var digits = GetFirstDigit().Match(input).Groups[1].Value + GetLastDigit().Match(input).Groups[1].Value;
                return int.Parse(digits);
            }
        }

        public static long CalculatePartTwo(this IEnumerable<string> input)
        {
            return input.Sum(GetNumber);

            static int GetNumber(string input)
            {
                var firstDigit = wordToDigit.GetValueOrDefaultRO(GetFirstDigitAsNumberOrWord().Match(input).Groups[1].Value, x => x);
                var lastDigit = wordToDigit.GetValueOrDefaultRO(GetLastDigitAsNumberOrWord().Match(input).Groups[1].Value, x => x);
                return int.Parse(firstDigit + lastDigit);
            }
        }

        [GeneratedRegex(@"^.*?(\d)")]
        private static partial Regex GetFirstDigit();

        [GeneratedRegex(@"^.*?(\d|one|two|three|four|five|six|seven|eight|nine)")]
        private static partial Regex GetFirstDigitAsNumberOrWord();

        [GeneratedRegex(@"^.*(\d)")]
        private static partial Regex GetLastDigit();

        [GeneratedRegex(@"^.*(\d|one|two|three|four|five|six|seven|eight|nine)")]
        private static partial Regex GetLastDigitAsNumberOrWord();
    }
}
