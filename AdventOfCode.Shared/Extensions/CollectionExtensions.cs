namespace AdventOfCode.Shared.Extensions
{
    public static class CollectionExtensions
    {
        public static void AddRange<T>(this ICollection<T> source, IEnumerable<T> input)
        {
            foreach (var item in input)
            {
                source.Add(item);
            }
        }
    }
}
