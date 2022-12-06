using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;

namespace AdventOfCode2015.Day18
{
    public static class InputParser
    {
        public static SparsePlane<char> ParseInput(this IEnumerable<string> inputs)
        {
            var plane = new SparsePlane<char>() { DefaultWhenUnset = '.' };
            foreach (var (input, rowIndex) in inputs.SelectIndex())
            {
                foreach (var (_, columnIndex) in input.SelectIndex().Where(x => x.Element == '#'))
                {
                    plane[columnIndex, rowIndex] = '#';
                }
            }

            return plane;
        }
    }
}
