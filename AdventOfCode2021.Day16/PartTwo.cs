using AdventOfCode.Shared.Extensions;
using System.Numerics;

namespace AdventOfCode2021.Day16
{
    public static class PartTwo
    {
        public static BigInteger CalculatePartTwo(this string binaryInput)
        {
            return binaryInput.ParseBinaryInput().Sum(x => x.Value);
        }
    }
}
