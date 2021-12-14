using AdventOfCode2021.Day02;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace AdventOfCode2021.Test.Unit
{
    [TestClass]
    public class Day02Tests
    {
        [TestMethod]
        public async Task PartOneDemoCalculationShallReturnExpectedResult()
        {
            const int expected = 150;
            var actual = await Program.CalculatePartOne("Day02Demo.txt").ConfigureAwait(false);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task PartTwoDemoCalculationShallReturnExpectedResult()
        {
            const int expected = 900;
            var actual = await Program.CalculatePartTwo("Day02Demo.txt").ConfigureAwait(false);

            Assert.AreEqual(expected, actual);
        }
    }
}
