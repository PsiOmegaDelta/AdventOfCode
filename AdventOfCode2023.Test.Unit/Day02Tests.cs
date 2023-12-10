using AdventOfCode2023.Day02;

namespace AdventOfCode2023.Test.Unit
{
    [TestClass]
    public class Day02Tests
    {
        private const string TestInputPath = "Day02Demo.txt";

        [TestMethod]
        public void PartOneShallReturnExpectedOutput()
        {
            const int expected = 8;
            var actual = Calculations.CalculatePartOne(12, 13, 14, File.ReadLines(TestInputPath).ParseInput());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoShallReturnExpectedOutput()
        {
            const int expected = 2286;
            var actual = File.ReadLines(TestInputPath).ParseInput().CalculatePartTwo();

            Assert.AreEqual(expected, actual);
        }
    }
}
