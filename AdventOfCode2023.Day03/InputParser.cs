using AdventOfCode.Shared;

namespace AdventOfCode2023.Day03
{
    public static partial class InputParser
    {
        public static SparsePlane<char> ParseInput(this IEnumerable<string> input)
        {
            var plane = new SparsePlane<char>('.');
            foreach (var (line, row) in input.Select((x, i) => (x, i)))
            {
                foreach (var (character, column) in line.Select((x, i) => (Character: x, Column: i)).Where(x => x.Character != '.'))
                {
                    plane[column, row] = character;
                }
            }

            return plane;
        }
    }
}
