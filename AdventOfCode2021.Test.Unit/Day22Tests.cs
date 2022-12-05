using AdventOfCode2021.Day22;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2021.Test.Unit
{
    [TestClass]
    public class Day22Tests
    {
        [TestMethod]
        public void PartOneDemoCalculationShallReturnExpectedResult()
        {
            const long expected = 590784;
            var actual = File.ReadLines("Day22DemoPartOne.txt").ParseInput().CalculatePartOne();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoDemoCalculationShallReturnExpectedResult()
        {
            const long expected = 2758514936282235;
            var actual = File.ReadLines("Day22DemoPartTwo.txt").ParseInput().CalculatePartTwo();

            Assert.AreEqual(expected, actual);
        }
    }
}
