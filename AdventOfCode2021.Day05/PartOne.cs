using AdventOfCode2021.Shared;

namespace AdventOfCode2021.Day05
{
    public static class PartOne
    {
        public static int CalculateResult(string inputPath)
        {
            var sparsePlane = new SparsePlane<int>();
            InputParser.ParseInput(inputPath).Where(x => x.IsCardinal).PopulatePlane(sparsePlane, x => x + 1);

            return sparsePlane.Entries.Count(x => x.Entry >= 2);
        }
    }
}
