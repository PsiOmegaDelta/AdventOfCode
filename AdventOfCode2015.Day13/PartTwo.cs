namespace AdventOfCode2015.Day13
{
    public static class PartTwo
    {
        public static int CalculatePartTwo(this IReadOnlyDictionary<string, IReadOnlyDictionary<string, int>> input)
        {
            var newInput = input.ToDictionary(x => x.Key, x => AddSelf(x.Value));
            newInput.Add("Myself", newInput.ToDictionary(x => x.Key, _ => 0));

            return newInput.CalculatePartOne();

            static IReadOnlyDictionary<string, int> AddSelf(IReadOnlyDictionary<string, int> input)
            {
                var newInput = input.ToDictionary(x => x.Key, x => x.Value);
                newInput.Add("Myself", 0);

                return newInput;
            }
        }
    }
}
