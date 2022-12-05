using AdventOfCode.Shared.Enumerations;
using AdventOfCode2021.Day21;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2021.Test.Unit
{
    [TestClass]
    public class Day21Tests
    {
        private const string InputPath = "Day21Demo.txt";

        [TestMethod]
        public void PartOneDemoCalculationShallReturnExpectedResult()
        {
            const long expected = 739785;
            var actual = File.ReadLines(InputPath).ParseInput().CalculatePartOne(Dice.DeterministicD100());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Ignore("Needs to be checked")]
        public void PartTwoDemoCalculationShallReturnExpectedResult()
        {
            const long expected = 444356092776315;
            var actual = File.ReadLines(InputPath).ParseInput().CalculatePartTwo();

            Assert.AreEqual(expected, actual);
        }
    }
}
