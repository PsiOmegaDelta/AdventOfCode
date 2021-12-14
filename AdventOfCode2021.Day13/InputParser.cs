using AdventOfCode.Shared;
using System.Text.RegularExpressions;

namespace AdventOfCode2021.Day13
{
    public static class InputParser
    {
        public static (SparsePlane<char> matrix, IReadOnlyList<(char Axis, int Line)>) ParseInput(string inputPath)
        {
            var matrix = new SparsePlane<char>(' ');
            var folds = new List<(char, int)>();
            var foldRegex = new Regex(@".* ([xy])=(\d*)", RegexOptions.Compiled);

            using var input = File.ReadLines(inputPath).GetEnumerator();
            var addLines = true;
            while (input.MoveNext())
            {
                if (string.IsNullOrWhiteSpace(input.Current))
                {
                    addLines = false;
                }
                else
                {
                    if (addLines)
                    {
                        var split = input.Current.Split(",");
                        matrix[int.Parse(split[0]), int.Parse(split[1])] = '#';
                    }
                    else
                    {
                        var matchResult = foldRegex.Match(input.Current);
                        folds.Add((char.Parse(matchResult.Groups[1].Value), int.Parse(matchResult.Groups[2].Value)));
                    }
                }
            }

            return (matrix, folds);
        }
    }
}
