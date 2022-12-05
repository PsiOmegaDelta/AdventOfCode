namespace AdventOfCode2022.Day04
{
    public static class Calculations
    {
        public static long CalculatePartOne(this IEnumerable<string> inputs)
        {
            // Splits each entry in inputs into 2 lists of ints
            // We wish to find the number of entries were one of these pair of lists is a complete subset of the other
            return ConvertToIntLists(inputs)
                .Select(x => (x.Left, x.Right, IntersectionLength: x.Left.Intersect(x.Right).Count()))
                .LongCount(x => x.Left.Count == x.IntersectionLength || x.Right.Count == x.IntersectionLength);
        }

        public static long CalculatePartTwo(this IEnumerable<string> inputs)
        {
            // Splits each entry in inputs into 2 lists of ints
            // We wish to find the number of entries were these pair of lists have any intersection at all
            return ConvertToIntLists(inputs)
                .LongCount(x => x.Left.Intersect(x.Right).Any());
        }

        private static IEnumerable<(List<int> Left, List<int> Right)> ConvertToIntLists(IEnumerable<string> inputs)
        {
            // Each entry in the input is a string in the (example) form "2-4,6-8"
            // Such a line is to be converted into 2 lists: (2, 3, 4) and (6, 7, 8) respectively
            return inputs
                .Select(x => x.Split(','))
                .Select(x => (Left: x[0].Split('-'), Right: x[1].Split('-')))
                .Select(x => (Left: (A: int.Parse(x.Left[0]), B: int.Parse(x.Left[1])), Right: (A: int.Parse(x.Right[0]), B: int.Parse(x.Right[1]))))
                .Select(x => (Left: Enumerable.Range(x.Left.A, x.Left.B - x.Left.A + 1).ToList(), Right: Enumerable.Range(x.Right.A, x.Right.B - x.Right.A + 1).ToList()));
        }
    }
}
