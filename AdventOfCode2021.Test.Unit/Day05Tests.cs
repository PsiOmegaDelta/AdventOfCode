using AdventOfCode2021.Day05;
using AdventOfCode2021.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Test.Unit
{
    [TestClass]
    public class Day05Tests
    {
        private const string InputPath = "Day05Demo.txt";

        [TestMethod]
        public void DiagonalLinesShallPopulateCorrectly()
        {
            var input = new List<string> { "1,1 -> 3,3", "9,7 -> 7,9" };
            var plane = new SparsePlane<int>();
            var lines = InputParser.ParseInput(input).ToList();
            lines.PopulatePlane(plane, x => x + 1);

            var planeEntries = plane.Entries.ToList();

            Assert.AreEqual(6, planeEntries.Count);

            Assert.AreEqual(1, planeEntries.Count(x => x.Coordinate.X == 1 && x.Coordinate.Y == 1));
            Assert.AreEqual(1, planeEntries.Count(x => x.Coordinate.X == 2 && x.Coordinate.Y == 2));
            Assert.AreEqual(1, planeEntries.Count(x => x.Coordinate.X == 3 && x.Coordinate.Y == 3));

            Assert.AreEqual(1, planeEntries.Count(x => x.Coordinate.X == 9 && x.Coordinate.Y == 7));
            Assert.AreEqual(1, planeEntries.Count(x => x.Coordinate.X == 8 && x.Coordinate.Y == 8));
            Assert.AreEqual(1, planeEntries.Count(x => x.Coordinate.X == 7 && x.Coordinate.Y == 9));
        }

        [TestMethod]
        public void PartOneDemoCalculationShallReturnExpectedResult()
        {
            const int expected = 5;
            var actual = PartOne.CalculateResult(InputPath);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoDemoCalculationShallReturnExpectedResult()
        {
            const int expected = 12;
            var actual = PartTwo.CalculateResult(InputPath);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShallBeAbleToParseInput()
        {
            var lines = InputParser.ParseInput(InputPath).ToList();

            Assert.AreEqual(10, lines.Count);
            Assert.AreEqual(6, lines.Count(x => x.IsCardinal));
        }
    }
}
