namespace AdventOfCode2015.Day08
{
    public static class PartOne
    {
        public static long CalculatePartOne(this IEnumerable<string> input)
        {
            return input.Sum(x => x.Length - x.InMemoryCount());
        }

        private static int InMemoryCount(this string input)
        {
            using var enumerator = input.GetEnumerator();
            var count = 0;
            while (enumerator.MoveNext())
            {
                if (enumerator.Current == '"')
                {
                    continue;
                }

                if (enumerator.Current == '\\')
                {
                    enumerator.MoveNext();
                    if (enumerator.Current == 'x')
                    {
                        enumerator.MoveNext();
                        enumerator.MoveNext();
                    }
                }

                count++;
            }

            return count;
        }
    }
}
