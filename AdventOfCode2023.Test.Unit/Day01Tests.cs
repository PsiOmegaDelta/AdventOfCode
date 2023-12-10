using AdventOfCode2023.Day01;

namespace AdventOfCode2023.Test.Unit
{
    [TestClass]
    public class Day01Tests
    {
        [TestMethod]
        public void PartOneShallReturnExpectedOutput()
        {
            const int expected = 142;

            var input = File.ReadLines("Day01DemoPartOne.txt");
            var actual = input.CalculatePartOne();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoeShallReturnExpectedOutput()
        {
            const int expected = 281;

            var input = File.ReadLines("Day01DemoPartTwo.txt");
            var actual = input.CalculatePartTwo();

            Assert.AreEqual(expected, actual);
        }
    }
}
