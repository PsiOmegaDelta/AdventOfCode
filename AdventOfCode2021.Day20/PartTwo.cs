using AdventOfCode.Shared;

namespace AdventOfCode2021.Day20
{
    public static class PartTwo
    {
        public static int CalculatePartTwo(this (IReadOnlySet<int> Algorithm, SparsePlane<char> Image) input)
        {
            return input.CalculatePartOne(50);
        }
    }
}
