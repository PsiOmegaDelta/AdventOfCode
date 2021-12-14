using AdventOfCode2021.Day06;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace AdventOfCode2021.Test.Unit
{
    [TestClass]
    public class Day06Tests
    {
        private const string InputPath = "Day06Demo.txt";

        [TestMethod]
        public async Task PartOneDemoCalculationShallReturnExpectedResult()
        {
            const int expected = 5934;
            var actual = await PartOne.CalculateResult(InputPath, 80).ConfigureAwait(false);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task PartTwoDemoCalculationShallReturnExpectedResultFor256Days()
        {
            const long expected = 26984457539;
            var actual = await PartTwo.CalculateResult(InputPath, 256).ConfigureAwait(false);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task PartTwoDemoCalculationShallReturnExpectedResultFor80Days()
        {
            const long expected = 5934;
            var actual = await PartTwo.CalculateResult(InputPath, 80).ConfigureAwait(false);

            Assert.AreEqual(expected, actual);
        }
    }
}
