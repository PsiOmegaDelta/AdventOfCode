using System.Text.RegularExpressions;

namespace AdventOfCode2015.Day06
{
    public static class InputParser
    {
        public static IEnumerable<Func<bool[][], bool[][]>> BoolParseInput(this IEnumerable<string> inputPath)
        {
            foreach (var input in inputPath)
            {
                (string type, int startX, int startY, int endX, int endY) = ParseInput(input);
                switch (type)
                {
                    case "toggle":
                        yield return x => x.ForEach(startX, endX, startY, endY, x => !x);
                        break;

                    case "on":
                        yield return x => x.ForEach(startX, endX, startY, endY, _ => true);
                        break;

                    case "off":
                        yield return x => x.ForEach(startX, endX, startY, endY, _ => false);
                        break;
                }
            }
        }

        public static IEnumerable<Func<int[][], int[][]>> IntParseInput(this IEnumerable<string> inputPath)
        {
            foreach (var input in inputPath)
            {
                (string type, int startX, int startY, int endX, int endY) = ParseInput(input);
                switch (type)
                {
                    case "toggle":
                        yield return x => x.ForEach(startX, endX, startY, endY, x => x + 2);
                        break;

                    case "on":
                        yield return x => x.ForEach(startX, endX, startY, endY, x => x + 1);
                        break;

                    case "off":
                        yield return x => x.ForEach(startX, endX, startY, endY, x => Math.Max(x - 1, 0));
                        break;
                }
            }
        }

        private static T[][] ForEach<T>(this T[][] matrix, int startX, int endX, int startY, int endY, Func<T, T> adjust)
        {
            for (var x = startX; x <= endX; x++)
            {
                for (var y = startY; y <= endY; y++)
                {
                    matrix[x][y] = adjust(matrix[x][y]);
                }
            }

            return matrix;
        }

        private static (string, int, int, int, int) ParseInput(string input)
        {
            var inputRegex = new Regex(@"^.*(toggle|off|on) (\d+),(\d+) through (\d+),(\d+)$");
            var match = inputRegex.Match(input);
            return (match.Groups[1].Value, int.Parse(match.Groups[2].Value), int.Parse(match.Groups[3].Value), int.Parse(match.Groups[4].Value), int.Parse(match.Groups[5].Value));
        }
    }
}
