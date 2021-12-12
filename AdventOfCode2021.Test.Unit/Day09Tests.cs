using AdventOfCode2021.Day09;
using AdventOfCode2021.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2021.Test.Unit
{
    [TestClass]
    public class Day09Tests
    {
        private const string InputPath = "Day09Demo.txt";

        [TestMethod]
        public void PartOneDemoCalculationShallReturnExpectedResult()
        {
            const int expected = 15;
            var actual = PartOne.CalculateResult(InputParsers.ToIntArrays(File.ReadLines(InputPath)));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoDemoCalculationShallReturnExpectedResult()
        {
            const long expected = 1134;
            var actual = PartTwo.CalculateResult(InputParsers.ToIntArrays(File.ReadLines(InputPath)));

            Assert.AreEqual(expected, actual);
        }
    }
}
