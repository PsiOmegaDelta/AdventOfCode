using AdventOfCode.Shared;
using AdventOfCode2022.Day03;

namespace AdventOfCode2022.Test.Unit
{
    [TestClass]
    public class Day03Tests
    {
        [TestMethod]
        public void PartOneShallReturnExpectedOutput()
        {
            const int expected = 157;

            var actual = File.ReadLines("Day03Demo.txt").CalculatePartOne();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoShallReturnExpectedOutput()
        {
            const int expected = 70;

            var actual = File.ReadLines("Day03Demo.txt").CalculatePartTwo();

            Assert.AreEqual(expected, actual);
        }
    }
}
