using AdventOfCode2021.Day07;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace AdventOfCode2021.Test.Unit
{
    [TestClass]
    public class Day07Tests
    {
        private const string InputPath = "Day07Demo.txt";

        [TestMethod]
        public async Task PartOneDemoCalculationShallReturnExpectedResult()
        {
            const int expected = 37;
            var actual = await PartOne.CalculateResult(InputPath);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task PartTwoDemoCalculationShallReturnExpectedResult()
        {
            const long expected = 168;
            var actual = await PartTwo.CalculateResult(InputPath);

            Assert.AreEqual(expected, actual);
        }
    }
}
