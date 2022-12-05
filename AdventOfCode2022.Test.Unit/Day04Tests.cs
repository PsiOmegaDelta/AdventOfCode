using AdventOfCode.Shared;
using AdventOfCode2022.Day04;

namespace AdventOfCode2022.Test.Unit
{
    [TestClass]
    public class Day04Tests
    {
        [TestMethod]
        public void PartOneShallReturnExpectedOutput()
        {
            const int expected = 2;

            var actual = File.ReadLines("Day04Demo.txt").CalculatePartOne();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoShallReturnExpectedOutput()
        {
            const int expected = 4;

            var actual = File.ReadLines("Day04Demo.txt").CalculatePartTwo();

            Assert.AreEqual(expected, actual);
        }
    }
}
