using AdventOfCode2022.Day02;

namespace AdventOfCode2022.Test.Unit
{
    [TestClass]
    public class Day02Tests
    {
        private const string TestInputPath = "Day02Demo.txt";

        [TestMethod]
        public void PartOneShallReturnExpectedOutput()
        {
            const int expected = 15;

            var actual = File.ReadLines(TestInputPath).CalculatePartOne();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoShallReturnExpectedOutput()
        {
            const int expected = 12;

            var actual = File.ReadLines(TestInputPath).CalculatePartTwo();

            Assert.AreEqual(expected, actual);
        }
    }
}
