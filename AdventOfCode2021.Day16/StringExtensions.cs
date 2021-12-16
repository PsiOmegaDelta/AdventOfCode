using System.Text;

namespace AdventOfCode2021.Day16
{
    public static class StringExtensions
    {
        // Yes, there are built-in converters.
        private static readonly IReadOnlyDictionary<char, string> charToBinary = new Dictionary<char, string>
        {
            { '0', "0000" },
            { '1', "0001" },
            { '2', "0010" },
            { '3', "0011" },
            { '4', "0100" },
            { '5', "0101" },
            { '6', "0110" },
            { '7', "0111" },
            { '8', "1000" },
            { '9', "1001" },
            { 'A', "1010" },
            { 'B', "1011" },
            { 'C', "1100" },
            { 'D', "1101" },
            { 'E', "1110" },
            { 'F', "1111" }
        };

        public static string FromHexToBinary(this string input)
        {
            var stringBuilder = new StringBuilder();
            foreach (var c in input.Trim())
            {
                stringBuilder.Append(charToBinary[c]);
            }

            return stringBuilder.ToString();
        }
    }
}
