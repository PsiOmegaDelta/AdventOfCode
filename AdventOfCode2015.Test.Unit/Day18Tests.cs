using AdventOfCode2015.Day18;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2015.Test.Unit
{
    [TestClass]
    public class Day18Tests
    {
        private const string InputPath = "Day18Demo.txt";

        [TestMethod]
        public void PartOneDemoCalculationsShallReturnExpectedResults()
        {
            const long expected = 4;
            var actual = File.ReadLines(InputPath).ParseInput().CalculatePartOne(4);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoDemoCalculationsShallReturnExpectedResults()
        {
            const long expected = 17;
            var actual = File.ReadLines(InputPath).ParseInput().CalculatePartTwo(5);

            Assert.AreEqual(expected, actual);
        }
    }
}
