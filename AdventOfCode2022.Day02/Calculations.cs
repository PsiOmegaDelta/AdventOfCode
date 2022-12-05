using System.Text;

namespace AdventOfCode2022.Day02
{
    public static class Calculations
    {
        public static long CalculatePartOne(this IEnumerable<string> inputs)
        {
            var points = new Dictionary<string, IReadOnlyDictionary<string, long>>
            {
                { "A", new Dictionary<string, long>
                    {
                        { "X", 3 + 1 }, // Draw    - Rock VS Rock
                        { "Y", 6 + 2 }, // Victory - Rock VS Paper
                        { "Z", 0 + 3 }  // Loss    - Rock VS Scissors
                    }
                },
                { "B", new Dictionary<string, long>
                    {
                        { "X", 0 + 1 }, // Loss    - Paper VS Rock
                        { "Y", 3 + 2 }, // Draw    - Paper VS Paper
                        { "Z", 6 + 3 }  // Victory - Paper VS Scissors
                    } },
                { "C", new Dictionary<string, long>
                    {
                        { "X", 6 + 1 }, // Victory - Scissors VS Rock
                        { "Y", 0 + 2 }, // Loss - Scissors VS Paper
                        { "Z", 3 + 3 }  // Draw - Scissors VS Scissors
                    } }
            };

            return inputs.Where(x => !string.IsNullOrEmpty(x)).Select(x => x.Split(' ')).Sum(x => points[x[0]][x[1]]);
        }

        public static long CalculatePartTwo(this IEnumerable<string> inputs)
        {
            var points = new Dictionary<string, IReadOnlyDictionary<string, long>>
            {
                { "A", new Dictionary<string, long>
                    {
                        { "X", 0 + 3 }, // Loss    - Rock VS Scissors
                        { "Y", 3 + 1 }, // Draw    - Rock VS Rock
                        { "Z", 6 + 2 }  // Victory - Rock VS Paper
                    }
                },
                { "B", new Dictionary<string, long>
                    {
                        { "X", 0 + 1 }, // Loss    - Paper VS Rock
                        { "Y", 3 + 2 }, // Draw    - Paper VS Paper
                        { "Z", 6 + 3 }  // Victory - Paper VS Scissors
                    } },
                { "C", new Dictionary<string, long>
                    {
                        { "X", 0 + 2 }, // Loss    - Scissors VS Paper
                        { "Y", 3 + 3 }, // Draw    - Scissors VS Scissors
                        { "Z", 6 + 1 }  // Victory - Scissors VS Rock
                    } }
            };

            return inputs.Where(x => !string.IsNullOrEmpty(x)).Select(x => x.Split(' ')).Sum(x => points[x[0]][x[1]]);
        }
    }
}
