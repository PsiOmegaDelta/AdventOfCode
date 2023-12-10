using AdventOfCode2023.Day04;

namespace AdventOfCode2023.Test.Unit
{
    [TestClass]
    public class Day04Tests
    {
        private const string TestInputPath = "Day04Demo.txt";

        [TestMethod]
        public void PartOneShallReturnExpectedOutput()
        {
            const int expected = 13;
            var actual = File.ReadLines(TestInputPath).ParseInput().CalculatePartOne();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoShallReturnExpectedOutput()
        {
            const int expected = 30;
            var actual = File.ReadLines(TestInputPath).ParseInput().CalculatePartTwo();

            Assert.AreEqual(expected, actual);
        }
    }
}
