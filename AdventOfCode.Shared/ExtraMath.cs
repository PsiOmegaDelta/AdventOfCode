namespace AdventOfCode.Shared
{
    public static class ExtraMath
    {
        public static T Min<T>(params T[] input)
            where T : IComparable<T>
        {
            if (input.Length == 0)
            {
                throw new ArgumentException(null, nameof(input));
            }

            var min = input[0];
            for (var i = 1; i < input.Length; i++)
            {
                if (input[i].CompareTo(min) < 0)
                {
                    min = input[i];
                }
            }

            return min;
        }
    }
}
