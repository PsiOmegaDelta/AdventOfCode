using AdventOfCode2015.Day13;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2015.Test.Unit
{
    [TestClass]
    public class Day13Tests
    {
        private const string InputPath = "Day13Demo.txt";

        [TestMethod]
        public void PartOneDemoCalculationsShallReturnExpectedResults()
        {
            const int expected = 330;
            var actual = File.ReadLines(InputPath).ParseInput().CalculatePartOne();

            Assert.AreEqual(expected, actual);
        }
    }
}
