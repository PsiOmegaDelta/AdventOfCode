using AdventOfCode2021.Day12;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2021.Test.Unit
{
    [TestClass]
    public class Day12Tests
    {
        [TestMethod]
        public void PartOneDemoCalculationShallReturnExpectedResultForLargeSet()
        {
            const int expected = 226;
            var actual = File.ReadLines("Day12DemoLarge.txt").CalculatePartOne();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartOneDemoCalculationShallReturnExpectedResultForMediumSet()
        {
            const int expected = 19;
            var actual = File.ReadLines("Day12DemoMedium.txt").CalculatePartOne();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartOneDemoCalculationShallReturnExpectedResultForSmallSet()
        {
            const int expected = 10;
            var actual = File.ReadLines("Day12DemoSmall.txt").CalculatePartOne();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartOneDemoCalculationShallReturnExpectedResultForTinySet()
        {
            var input = new List<string>() { "start-A", "A-end" };
            const int expected = 1;
            var actual = input.CalculatePartOne();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoDemoCalculationShallReturnExpectedResultForLargeSet()
        {
            const long expected = 3509;
            var actual = File.ReadLines("Day12DemoLarge.txt").CalculatePartTwo();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoDemoCalculationShallReturnExpectedResultForMediumSet()
        {
            const long expected = 103;
            var actual = File.ReadLines("Day12DemoMedium.txt").CalculatePartTwo();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoDemoCalculationShallReturnExpectedResultForSmallSet()
        {
            const long expected = 36;
            var actual = File.ReadLines("Day12DemoSmall.txt").CalculatePartTwo();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoDemoCalculationShallReturnExpectedResultForTinySet()
        {
            var input = new List<string>() { "start-A", "A-end" };
            const int expected = 1;
            var actual = input.CalculatePartTwo();

            Assert.AreEqual(expected, actual);
        }
    }
}
