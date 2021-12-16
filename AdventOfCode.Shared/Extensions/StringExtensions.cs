namespace AdventOfCode.Shared.Extensions
{
    public static class StringExtensions
    {
        public static string Increment(this string input)
        {
            var characters = input.ToCharArray();
            for (int i = input.Length - 1; i >= 0; i--)
            {
                characters[i]++;
                if (characters[i] == ('z' + 1))
                {
                    characters[i] = 'a';
                }
                else
                {
                    break;
                }
            }

            return new string(characters);
        }

        public static IEnumerable<(string, string)> Pairs(this string input)
        {
            for (var n = 0; n < input.Length - 3; n++)
            {
                for (var m = n + 2; m < input.Length - 1; m++)
                {
                    yield return (input.Substring(n, 2), input.Substring(m, 2));
                }
            }
        }
    }
}
