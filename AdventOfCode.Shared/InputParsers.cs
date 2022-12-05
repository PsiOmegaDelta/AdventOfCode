namespace AdventOfCode.Shared
{
    public static class InputParsers
    {
        public static IEnumerable<IReadOnlyList<T>> GroupByNewlineSeparation<T>(this IEnumerable<string> input, Func<string, T> converter)
        {
            var grouped = new List<T>();
            foreach (var item in input)
            {
                if (string.IsNullOrEmpty(item))
                {
                    if (grouped.Count > 0)
                    {
                        yield return grouped;
                        grouped = new List<T>();
                    }
                }
                else
                {
                    grouped.Add(converter(item));
                }
            }

            if (grouped.Count > 0)
            {
                yield return grouped;
            }
        }

        public static char[][] ToCharArrays(this IEnumerable<string> input)
        {
            return input.Select(x => x.ToArray()).ToArray();
        }

        public static int[][] ToIntArrays(this IEnumerable<string> input)
        {
            return input
                .Select(x => x.Where(char.IsDigit).Select(x => (int)char.GetNumericValue(x)).ToArray())
                .ToArray();
        }
    }
}
