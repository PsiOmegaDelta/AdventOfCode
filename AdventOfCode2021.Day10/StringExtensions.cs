namespace AdventOfCode2021.Day10
{
    public static class StringExtensions
    {
        private static readonly IReadOnlyDictionary<char, char> closingBracketPairs = new Dictionary<char, char>
        {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' },
            { '>', '<' }
        };

        private static readonly IReadOnlyDictionary<char, char> openingBracketPairs = new Dictionary<char, char>
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' },
            { '<', '>' }
        };

        public static IEnumerable<char> InvalidBrackets(this string input)
        {
            // Input always starts with a valid bracket, so we cut out some logic
            var stack = new Stack<char>();
            foreach (char c in input)
            {
                if (closingBracketPairs.ContainsKey(c)) // It's a closing character, see if the last opened one matches
                {
                    if (stack.Pop() != closingBracketPairs[c])
                    {
                        yield return c;
                    }
                }
                else
                {
                    stack.Push(c);
                }
            }
        }

        public static IEnumerable<char> MissingBrackets(this string input)
        {
            // Here we assume that the input is correct, with the exception of missing brackets
            var stack = new Stack<char>();
            foreach (char c in input)
            {
                if (closingBracketPairs.ContainsKey(c))
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(c);
                }
            }

            while (stack.TryPop(out char c))
            {
                yield return openingBracketPairs[c];
            }
        }
    }
}
