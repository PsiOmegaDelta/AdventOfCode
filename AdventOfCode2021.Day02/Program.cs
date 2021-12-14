using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day02
{
    public static class Program
    {
        public static async Task<int> CalculatePartOne(string inputPath)
        {
            var input = (await PrepareInput(inputPath).ConfigureAwait(false)).Select(x => new SimpleSubmarineVector(x[0], int.Parse(x[1])));
            return Calculate(input);
        }

        public static async Task<int> CalculatePartTwo(string inputPath)
        {
            var input = (await PrepareInput(inputPath).ConfigureAwait(false)).Select(x => new ComplexSubmarineVector(x[0], int.Parse(x[1])));
            return Calculate(input);
        }

        public static async Task Main()
        {
            const string inputPath = "Day02Input.txt";
            Console.WriteLine("Part One: " + await CalculatePartOne(inputPath).ConfigureAwait(false));
            Console.WriteLine("Part Two: " + CalculatePartTwo(inputPath));
        }

        private static int Calculate(IEnumerable<ISubmarineVector> submarineVectors)
        {
            var location = submarineVectors.Aggregate(Location.Zero, (loc, vec) => vec.AdjustLocation(loc));
            return location.Depth * location.HorizontalPosition;
        }

        private static async Task<IEnumerable<string[]>> PrepareInput(string inputPath)
        {
            return (await File.ReadAllLinesAsync(inputPath).ConfigureAwait(false)).Select(x => x.Split(' '));
        }
    }
}
