using AdventOfCode2022.Day03;

namespace AdventOfCode2022.Test.Unit
{
    [TestClass]
    public class Day03Tests
    {
        private const string TestInputPath = "Day03Demo.txt";

        [TestMethod]
        public void PartOneShallReturnExpectedOutput()
        {
            const int expected = 157;

            var actual = File.ReadLines(TestInputPath).CalculatePartOne();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoShallReturnExpectedOutput()
        {
            const int expected = 70;

            var actual = File.ReadLines(TestInputPath).CalculatePartTwo();

            Assert.AreEqual(expected, actual);
        }
    }
}
