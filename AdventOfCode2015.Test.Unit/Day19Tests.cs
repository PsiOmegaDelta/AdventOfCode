using AdventOfCode2015.Day19;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2015.Test.Unit
{
    [TestClass]
    public class Day19Tests
    {
        private const string InputPath = "Day19Demo.txt";

        [TestMethod]
        public void PartOneDemoCalculationsShallReturnExpectedResults()
        {
            var expected = new List<long> { 4, 7 };
            var (transformations, input) = File.ReadLines(InputPath).ParseInput();
            var actual = Calculations.CalculatePartOne(transformations, input);

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        public void PartTwoDemoCalculationsShallReturnExpectedResults()
        {
            var expected = new List<long> { 3, 6 };
            var (transformations, input) = File.ReadLines(InputPath).ParseInput();
            var actual = Calculations.CalculatePartTwo(transformations, input);

            Assert.IsTrue(expected.SequenceEqual(actual));
        }
    }
}
