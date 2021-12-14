using AdventOfCode2021.Day03;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace AdventOfCode2021.Test.Unit
{
    [TestClass]
    public class Day03Tests
    {
        [TestMethod]
        public async Task PartOneDemoCalculationShallReturnExpectedResult()
        {
            const int expected = 198;
            var actual = await Program.CalculatePartOne("Day03Demo.txt").ConfigureAwait(false);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task PartTwoDemoCalculationShallReturnExpectedResult()
        {
            const int expected = 230;
            var actual = await Program.CalculatePartTwo("Day03Demo.txt").ConfigureAwait(false);

            Assert.AreEqual(expected, actual);
        }
    }
}
