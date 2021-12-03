using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day03
{
    public static class Program
    {
        public static async Task<int> CalculatePartOne(string inputPath)
        {
            var inputs = await AcquireInputs(inputPath);
            var mostCommon = CalculateMostCommon(inputs);

            var (gamma, epsilon) = ConvertToDecimal(mostCommon);
            return gamma * epsilon;
        }

        public static async Task<int> CalculatePartTwo(string inputPath)
        {
            var inputs = await AcquireInputs(inputPath);

            var oxygen = FilterInput(inputs, true);
            var scrubber = FilterInput(inputs, false);

            return Convert.ToInt32(oxygen[0], 2) * Convert.ToInt32(scrubber[0], 2);
        }

        public static async Task Main()
        {
            const string inputPath = "Day03Input.txt";
            Console.WriteLine("Part One: " + await CalculatePartOne(inputPath));
            Console.WriteLine("Part Two: " + await CalculatePartTwo(inputPath));
        }

        private static async Task<IImmutableList<string>> AcquireInputs(string inputPath)
        {
            return (await File.ReadAllLinesAsync(inputPath)).ToImmutableList();
        }

        private static IReadOnlyList<int> CalculateMostCommon(IEnumerable<string> inputs)
        {
            var enumeratedInputs = inputs.ToList();
            var inputLength = enumeratedInputs[0].Length;
            var mostCommon = new List<int>(Enumerable.Repeat(0, inputLength));
            foreach (var input in enumeratedInputs)
            {
                for (var i = 0; i < inputLength; i++)
                {
                    mostCommon[i] = input[i] == '1' ? mostCommon[i] + 1 : mostCommon[i] - 1;
                }
            }

            return mostCommon;
        }

        private static (int gamma, int epsilon) ConvertToDecimal(IReadOnlyList<int> input)
        {
            var output = 0;
            var inputLength = input.Count;
            foreach (var (entry, index) in input.Select((x, i) => (x, i)))
            {
                if (entry > 0)
                {
                    var bitPosition = inputLength - index - 1;
                    output |= 1 << bitPosition;
                }
            }

            return (output, (~output) & ((int)Math.Pow(2, inputLength) - 1));
        }

        private static IReadOnlyList<string> FilterInput(IImmutableList<string> input, bool getMostCommon)
        {
            for (int index = 0; input.Count > 1; index++)
            {
                var mostCommon = CalculateMostCommon(input);
                var commonBit = mostCommon[index];

                foreach (var entry in input)
                {
                    if (commonBit >= 0 && (getMostCommon ? entry[index] != '1' : entry[index] == '1'))
                    {
                        input = input.Remove(entry);
                    }
                    else if (commonBit < 0 && (getMostCommon ? entry[index] != '0' : entry[index] == '0'))
                    {
                        input = input.Remove(entry);
                    }
                }
            }

            return input;
        }
    }
}
