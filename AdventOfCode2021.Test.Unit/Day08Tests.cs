using AdventOfCode2021.Day08;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace AdventOfCode2021.Test.Unit
{
    [TestClass]
    public class Day08Tests
    {
        [TestMethod]
        public void PartOneDemoCalculationShallReturnExpectedResult()
        {
            const int expected = 26;
            var actual = PartOne.CalculateResult("Day08DemoLong.txt");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoDemoCalculationShallReturnExpectedResultWithLongInput()
        {
            const long expected = 61229;
            var actual = PartTwo.CalculateResult("Day08DemoLong.txt");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoDemoCalculationShallReturnExpectedResultWithShortInput()
        {
            const long expected = 5353;
            var actual = PartTwo.CalculateResult("Day08DemoShort.txt");

            Assert.AreEqual(expected, actual);
        }
    }
}
