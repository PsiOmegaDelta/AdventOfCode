namespace AdventOfCode2015.Day15
{
    public static class PartTwo
    {
        // Playing around with separation of data and logic
        public static long CalculatePartTwo(this IReadOnlyList<Ingredient> ingredients)
        {
            return ingredients.CalculatePartOne(500);
        }
    }
}
