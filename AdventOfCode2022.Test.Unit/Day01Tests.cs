using AdventOfCode.Shared;
using AdventOfCode2022.Day01;

namespace AdventOfCode2022.Test.Unit
{
    [TestClass]
    public class Day01Tests
    {
        private const string TestInputPath = "Day01Demo.txt";

        [TestMethod]
        public void PartOneShallReturnExpectedOutput()
        {
            const int expected = 24000;

            var input = File.ReadLines(TestInputPath).GroupByNewlineSeparation(int.Parse);
            var actual = input.CalculatePartOne();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoShallReturnExpectedOutput()
        {
            const int expected = 45000;

            var input = File.ReadLines(TestInputPath).GroupByNewlineSeparation(int.Parse);
            var actual = input.CalculatePartTwo();

            Assert.AreEqual(expected, actual);
        }
    }
}
