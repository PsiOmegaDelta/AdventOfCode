using System.Runtime.Serialization;
using System.Security.AccessControl;

namespace AdventOfCode2022.Day04
{
    public static class Calculations
    {
        public static long CalculatePartOne(this IEnumerable<string> inputs)
        {
            // Each entry in the input is a string in the (example) form "2-4,6-8"
            // Such a line is to be converted into 2 lists: (2, 3, 4) and (6, 7, 8) respectively
            // We wish to find the number of entries were one of these lists is a complete subset of the other
            return inputs
                .Select(x => x.Split(','))
                .Select(x => (Left: x[0].Split('-'), Right: x[1].Split('-')))
                .Select(x => (Left: (A: int.Parse(x.Left[0]), B: int.Parse(x.Left[1])), Right: (A: int.Parse(x.Right[0]), B: int.Parse(x.Right[1]))))
                .Select(x => (Left: Enumerable.Range(x.Left.A, x.Left.B - x.Left.A + 1).ToList(), Right: Enumerable.Range(x.Right.A, x.Right.B - x.Right.A + 1).ToList()))
                .Select(x => (x.Left, x.Right, IntersectionLength: x.Left.Intersect(x.Right).Count()))
                .LongCount(x => x.Left.Count == x.IntersectionLength || x.Right.Count == x.IntersectionLength);
        }

        public static long CalculatePartTwo(this IEnumerable<string> inputs)
        {
            // Each entry in the input is a string in the (example) form "2-4,6-8"
            // Such a line is to be converted into 2 lists: (2, 3, 4) and (6, 7, 8) respectively
            // We wish to find the number of entries were these lists have any intersection at all
            return inputs
                .Select(x => x.Split(','))
                .Select(x => (Left: x[0].Split('-'), Right: x[1].Split('-')))
                .Select(x => (Left: (A: int.Parse(x.Left[0]), B: int.Parse(x.Left[1])), Right: (A: int.Parse(x.Right[0]), B: int.Parse(x.Right[1]))))
                .Select(x => (Left: Enumerable.Range(x.Left.A, x.Left.B - x.Left.A + 1).ToList(), Right: Enumerable.Range(x.Right.A, x.Right.B - x.Right.A + 1).ToList()))
                .LongCount(x => x.Left.Intersect(x.Right).Any());
        }
    }
}
