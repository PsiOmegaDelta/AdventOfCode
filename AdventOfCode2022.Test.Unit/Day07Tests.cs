using AdventOfCode2022.Day07;

namespace AdventOfCode2022.Test.Unit
{
    [TestClass]
    public class Day07Tests
    {
        private const string TestInputPath = "Day07Demo.txt";

        [TestMethod]
        public void PartOneShallReturnExpectedOutput()
        {
            const int expected = 95437;

            var actual = System.IO.File.ReadLines(TestInputPath).ParseInput().CalculatePartOne(100000);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoShallReturnExpectedOutput()
        {
            const int expected = 24933642;

            var actual = System.IO.File.ReadLines(TestInputPath).ParseInput().CalculatePartTwo(70000000, 30000000);

            Assert.AreEqual(expected, actual);
        }
    }
}
