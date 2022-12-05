using AdventOfCode.Shared;
using AdventOfCode2022.Day02;

namespace AdventOfCode2022.Test.Unit
{
    [TestClass]
    public class Day02Tests
    {
        [TestMethod]
        public void PartOneShallReturnExpectedOutput()
        {
            const int expected = 15;

            var actual = File.ReadLines("Day02Demo.txt").CalculatePartOne();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoShallReturnExpectedOutput()
        {
            const int expected = 12;

            var actual = File.ReadLines("Day02Demo.txt").CalculatePartTwo();

            Assert.AreEqual(expected, actual);
        }
    }
}
