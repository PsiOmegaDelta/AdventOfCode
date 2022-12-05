namespace AdventOfCode2022.Day03
{
    public static class Calculations
    {
        private static readonly IReadOnlyDictionary<char, int> letterValue = Enumerable.Range('a', 'z' - 'a' + 1)
                .Concat(Enumerable.Range('A', 'Z' - 'A' + 1))
                .Select((x, i) => (Letter: (char)x, Value: i + 1))
                .ToDictionary(x => x.Letter, x => x.Value);

        public static long CalculatePartOne(this IEnumerable<string> inputs)
        {
            return inputs
                .Select(x => (Left: x[..(x.Length / 2)], Right: x[(x.Length / 2)..])) // Splits each string in 2 equal halves
                .SelectMany(x => x.Left.Intersect(x.Right)) // Gets the intersecting letter(s) for each pair (and flattens the list) - An optimization possibility in this specific scenario is an Intersect-method that breaks after the first hit
                .Sum(x => letterValue[x]); // Sums the values of the intersecting characters
        }

        public static long CalculatePartTwo(this IEnumerable<string> inputs)
        {
            return inputs
                .Chunk(3) // Divides the input into groups of 3
                .SelectMany(x => x[0].Intersect(x[1]).Intersect(x[2])) // Intersect the 1st row with the 2nd, intersect the 3rd with that's left
                .Sum(x => letterValue[x]); // Sums the values of the intersecting characters
        }
    }
}
