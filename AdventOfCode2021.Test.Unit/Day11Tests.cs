using AdventOfCode.Shared;
using AdventOfCode2021.Day11;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2021.Test.Unit
{
    [TestClass]
    public class Day11Tests
    {
        private const string InputPath = "Day11Demo.txt";

        [TestMethod]
        public void PartOneDemoCalculationShallReturnExpectedResult()
        {
            const long expected = 1656;
            var actual = File.ReadLines(InputPath).ToIntArrays().CalculatePartOne(100);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoDemoCalculationShallReturnExpectedResult()
        {
            const long expected = 195;
            var actual = File.ReadLines(InputPath).ToIntArrays().CalculatePartTwo();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SmallInputShallReturnExpectedResult()
        {
            var input = new int[][]
            {
                new int[] { 1,1,1,1,1 },
                new int[] { 1,9,9,9,1 },
                new int[] { 1,9,1,9,1 },
                new int[] { 1,9,9,9,1 },
                new int[] { 1,1,1,1,1 },
            };

            var expected = new int[][]
            {
                new int[] { 4,5,6,5,4 },
                new int[] { 5,1,1,1,5 },
                new int[] { 6,1,1,1,6 },
                new int[] { 5,1,1,1,5 },
                new int[] { 4,5,6,5,4 },
            };

            var (actual, _) = input.ConductStep();
            (actual, _) = actual.ConductStep();
            for (int x = 0; x < expected.Length; x++)
            {
                for (int y = 0; y < expected[x].Length; y++)
                {
                    Assert.AreEqual(expected[x][y], actual[x][y]);
                }
            }
        }
    }
}
