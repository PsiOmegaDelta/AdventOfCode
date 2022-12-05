using AdventOfCode2022.Day05;

namespace AdventOfCode2022.Test.Unit
{
    [TestClass]
    public class Day05Tests
    {
        private const string TestInputPath = "Day05Demo.txt";

        [TestMethod]
        public void PartOneShallReturnExpectedOutput()
        {
            const string expected = "CMZ";

            var (crateStacks, relocationOrders) = File.ReadLines(TestInputPath).ParseInput();
            var actual = crateStacks.CalculatePartOne(relocationOrders);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoShallReturnExpectedOutput()
        {
            const string expected = "MCD";

            var (crateStacks, relocationOrders) = File.ReadLines(TestInputPath).ParseInput();
            var actual = crateStacks.CalculatePartTwo(relocationOrders);

            Assert.AreEqual(expected, actual);
        }
    }
}
