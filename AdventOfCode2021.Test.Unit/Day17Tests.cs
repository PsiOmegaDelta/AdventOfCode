using AdventOfCode2021.Day17;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2021.Test.Unit
{
    [TestClass]
    public class Day17Tests
    {
        private const string InputPath = "Day17Demo.txt";

        [TestMethod]
        public void PartOneDemoCalculationShallReturnExpectedResult()
        {
            const long expected = 45;
            var actual = File.ReadAllText(InputPath).ParseInput().CalculatePartOne();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoDemoCalculationShallReturnExpectedResult()
        {
            const int expected = 112;
            var actual = File.ReadAllText(InputPath).ParseInput().CalculatePartTwo();

            Assert.AreEqual(expected, actual);
        }
    }
}
