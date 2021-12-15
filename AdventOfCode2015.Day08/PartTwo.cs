using System.Text;

namespace AdventOfCode2015.Day08
{
    public static class PartTwo
    {
        public static long CalculatePartTwo(this IEnumerable<string> input)
        {
            return input.Select(x => x.Encode()).CalculatePartOne();
        }

        public static string Encode(this string input)
        {
            var stringBuilder = new StringBuilder("\"");

            using var enumerator = input.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Current == '"')
                {
                    stringBuilder.Append("\\\"");
                }
                else if (enumerator.Current == '\\')
                {
                    stringBuilder.Append("\\\\");
                    enumerator.MoveNext();
                    if (enumerator.Current == 'x')
                    {
                        stringBuilder.Append(enumerator.Current);
                        enumerator.MoveNext();
                        stringBuilder.Append(enumerator.Current);
                        enumerator.MoveNext();
                        stringBuilder.Append(enumerator.Current);
                    }
                    else
                    {
                        stringBuilder.Append("\\\"");
                    }
                }
                else
                {
                    stringBuilder.Append(enumerator.Current);
                }
            }

            return stringBuilder.Append('"').ToString();
        }
    }
}
