using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using AdventOfCode2015.Day08;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2015.Test.Unit
{
    [TestClass]
    public class Day08Tests
    {
        private const string InputPath = "Day08Demo.txt";

        [TestMethod]
        public void PartOneDemoCalculationsShallReturnExpectedResults()
        {
            const int expected = 12;
            var actual = File.ReadLines(InputPath).CalculatePartOne();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoDemoCalculationsShallReturnExpectedResults()
        {
            const int expected = 19;
            var actual = File.ReadLines(InputPath).CalculatePartTwo();

            Assert.AreEqual(expected, actual);
        }
    }
}
