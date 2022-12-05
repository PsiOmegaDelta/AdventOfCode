using AdventOfCode2022.Day04;

namespace AdventOfCode2022.Test.Unit
{
    [TestClass]
    public class Day04Tests
    {
        private const string TestInputPath = "Day04Demo.txt";

        [TestMethod]
        public void PartOneShallReturnExpectedOutput()
        {
            const int expected = 2;

            var actual = File.ReadLines(TestInputPath).CalculatePartOne();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoShallReturnExpectedOutput()
        {
            const int expected = 4;

            var actual = File.ReadLines(TestInputPath).CalculatePartTwo();

            Assert.AreEqual(expected, actual);
        }
    }
}
