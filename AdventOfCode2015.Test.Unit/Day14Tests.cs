using AdventOfCode2015.Day14;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2015.Test.Unit
{
    [TestClass]
    public class Day14Tests
    {
        private const string InputPath = "Day14Demo.txt";

        [TestMethod]
        public void PartOneDemoCalculationsShallReturnExpectedResults()
        {
            const int expected = 1120;
            var actual = File.ReadLines(InputPath).ParseInput().CalculatePartOne(1000);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoDemoCalculationsShallReturnExpectedResults()
        {
            const int expected = 688;
            var actual = File.ReadLines(InputPath).ParseInput().CalculatePartTwo(1000);

            Assert.AreEqual(expected, actual);
        }
    }
}
