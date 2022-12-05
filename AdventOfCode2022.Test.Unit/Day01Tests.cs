using AdventOfCode.Shared;
using AdventOfCode2022.Day01;

namespace AdventOfCode2022.Test.Unit
{
    [TestClass]
    public class Day01Tests
    {
        [TestMethod]
        public void PartOneShallReturnExpectedOutput()
        {
            const int expected = 24000;

            var input = File.ReadLines("Day01Demo.txt").GroupByNewlineSeparation(int.Parse);
            var actual = input.CalculatePartOne();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoShallReturnExpectedOutput()
        {
            const int expected = 45000;

            var input = File.ReadLines("Day01Demo.txt").GroupByNewlineSeparation(int.Parse);
            var actual = input.CalculatePartTwo();

            Assert.AreEqual(expected, actual);
        }
    }
}
