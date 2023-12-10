using AdventOfCode2023.Day03;

namespace AdventOfCode2023.Test.Unit
{
    [TestClass]
    public class Day03Tests
    {
        private const string TestInputPath = "Day03Demo.txt";

        [TestMethod]
        public void PartOneShallReturnExpectedOutput()
        {
            const int expected = 4361;
            var actual = File.ReadLines(TestInputPath).ParseInput().CalculatePartOne();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoShallReturnExpectedOutput()
        {
            const int expected = 467835;
            var actual = File.ReadLines(TestInputPath).ParseInput().CalculatePartTwo();

            Assert.AreEqual(expected, actual);
        }
    }
}
