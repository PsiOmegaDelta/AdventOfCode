using AdventOfCode.Shared.Extensions;
using System.Runtime.CompilerServices;

namespace AdventOfCode2022.Day06
{
    public static class Calculations
    {
        public static IEnumerable<long> CalculatePartOne(this IEnumerable<string> inputs)
        {
            return inputs.GetMarkers(4);
        }

        public static IEnumerable<long> CalculatePartTwo(this IEnumerable<string> inputs)
        {
            return inputs.GetMarkers(14);
        }

        private static IEnumerable<long> GetMarkers(this IEnumerable<string> inputs, int distinctCharacters)
        {
            distinctCharacters--; // We pre-read distinctCharacters - 1 characters, then the actual work begin
            foreach (var input in inputs)
            {
                int characterCount = distinctCharacters;
                var characterStream = new Queue<char>(input.Take(distinctCharacters));
                foreach (var character in input.Skip(distinctCharacters))
                {
                    characterCount++;
                    characterStream.Enqueue(character);
                    if (characterStream.Duplicates().None())
                    {
                        yield return characterCount;
                        break;
                    }

                    characterStream.Dequeue();
                }
            }
        }
    }
}
