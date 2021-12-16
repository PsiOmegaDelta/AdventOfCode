using System.Text;

namespace AdventOfCode2015.Day10
{
    public static class IntExtensions
    {
        public static string LookAndSay(this string input)
        {
            if (input.Length == 0)
            {
                return input;
            }

            if (input.Length == 1)
            {
                return $"1{input}";
            }

            var stringBuilder = new StringBuilder();

            var previousChar = input[0];
            var characterCount = 1;
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == previousChar)
                {
                    characterCount++;
                }
                else
                {
                    stringBuilder.Append(characterCount);
                    stringBuilder.Append(previousChar);

                    previousChar = input[i];
                    characterCount = 1;
                }
            }

            stringBuilder.Append(characterCount);
            stringBuilder.Append(previousChar);

            return stringBuilder.ToString();
        }
    }
}
