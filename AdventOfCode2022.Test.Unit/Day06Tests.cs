using AdventOfCode2022.Day06;

namespace AdventOfCode2022.Test.Unit
{
    [TestClass]
    public class Day06Tests
    {
        private const string TestInputPath = "Day06Demo.txt";

        [TestMethod]
        public void PartOneShallReturnExpectedOutput()
        {
            var expected = new List<long> { 7, 5, 6, 10, 11 };
            var actual = File.ReadLines(TestInputPath).CalculatePartOne();

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        public void PartTwoShallReturnExpectedOutput()
        {
            var expected = new List<long> { 19, 23, 23, 29, 26 };
            var actual = File.ReadLines(TestInputPath).CalculatePartTwo();

            Assert.IsTrue(expected.SequenceEqual(actual));
        }
    }
}
