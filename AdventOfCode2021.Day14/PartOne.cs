using System.Text;

namespace AdventOfCode2021.Day14
{
    public static class PartOne
    {
        // "This polymer grows quickly" - Let's do the naive solution first anyway, can be used to test the optimized solution
        public static long CalculatePartOne(this (string Template, IReadOnlyDictionary<string, char> Inserts) input, int steps)
        {
            for (int step = 0; step < steps; step++)
            {
                input.Template = ConductStep(input.Inserts, input.Template);
            }

            var numberOfChars = input.Template.ToLookup(x => x);
            return numberOfChars.Max(x => x.LongCount()) - numberOfChars.Min(x => x.LongCount());
        }

        public static string ConductStep(IReadOnlyDictionary<string, char> inserts, string template)
        {
            var templateBuilder = new StringBuilder();
            for (int i = 0; i < template.Length - 1; i++)
            {
                var insertKey = template.Substring(i, 2);
                templateBuilder.Append(insertKey[0]);
                templateBuilder.Append(inserts[insertKey]);
            }

            templateBuilder.Append(template[^1]);

            return templateBuilder.ToString();
        }
    }
}
