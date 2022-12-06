using AdventOfCode2015.Day17;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace AdventOfCode2015.Test.Unit
{
    [TestClass]
    public class Day17Tests
    {
        private const string InputPath = "Day17Demo.txt";

        [TestMethod]
        public void PartOneDemoCalculationsShallReturnExpectedResults()
        {
            const long expected = 4;
            var actual = ImmutableQueue.Create(File.ReadLines(InputPath).ParseInput().ToArray()).CalculatePartOne(25);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoDemoCalculationsShallReturnExpectedResults()
        {
            const long expected = 3;
            var actual = ImmutableQueue.Create(File.ReadLines(InputPath).ParseInput().ToArray()).CalculatePartTwo(25);

            Assert.AreEqual(expected, actual);
        }
    }
}
