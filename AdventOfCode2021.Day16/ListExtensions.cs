namespace AdventOfCode2021.Day16
{
    public static class ListExtensions
    {
        public static int ToInteger(this IList<int> source)
        {
            var number = 0;
            foreach (var (item, index) in source.Select((x, i) => (x, i + 1)))
            {
                number += item * (int)Math.Pow(10, source.Count - index);
            }

            return number;
        }
    }
}
