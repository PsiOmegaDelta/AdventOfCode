using AdventOfCode.Shared.Extensions;
using AdventOfCode2015.Day15;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2015.Test.Unit
{
    [TestClass]
    public class Day15Tests
    {
        private const string InputPath = "Day15Demo.txt";

        [TestMethod]
        public void PartOneDemoCalculationsShallReturnExpectedResults()
        {
            const long expected = 62842880;
            var actual = File.ReadLines(InputPath).ParseInput().ToSequence().CalculatePartOne();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoDemoCalculationsShallReturnExpectedResults()
        {
            const int expected = 57600000;
            var actual = File.ReadLines(InputPath).ParseInput().ToSequence().CalculatePartTwo();

            Assert.AreEqual(expected, actual);
        }
    }
}
