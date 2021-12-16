namespace AdventOfCode2021.Day16
{
    public static class EnumerableExtensions
    {
        public static int FromBinaryToInt(this IEnumerable<char> binary)
        {
            var binaryString = new string(binary.ToArray());
            return binaryString.Length == 0 ? 0 : Convert.ToInt32(binaryString, 2);
        }
    }
}
