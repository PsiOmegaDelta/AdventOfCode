using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using AdventOfCode2021.Day15;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.Test.Unit
{
    [TestClass]
    public class Day15Tests
    {
        private const string InputPath = "Day15Demo.txt";

        [TestMethod]
        public void OneExpansionShallReturnExpectedResult()
        {
            var input = new int[][]
            {
                new int[] { 1,1,6,3,7,5,1,7,4,2 }
            };

            var expected = new int[][]
            {
                new int[] { 1,1,6,3,7,5,1,7,4,2 }
            };

            var actual = input.ExpandArray(1);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.IsTrue(expected[i].SequenceEqual(actual[i]));
            }
        }

        [TestMethod]
        public void PartOneDemoCalculationShallReturnExpectedResult()
        {
            const int expected = 40;
            var actual = File.ReadLines(InputPath).ToIntArrays().CalculatePartOne();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoDemoCalculationShallReturnExpectedResult()
        {
            const long expected = 315;
            var actual = File.ReadLines(InputPath).ToIntArrays().CalculatePartTwo();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoDemoExpansionShallReturnExpectedResult()
        {
            var expected = File.ReadLines("Day15DemoExpanded.txt").ToIntArrays();
            var actual = File.ReadLines(InputPath).ToIntArrays().ExpandArray(5);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.IsTrue(expected[i].SequenceEqual(actual[i]));
            }
        }

        [TestMethod]
        public void PartTwoExampleExpansionShallReturnExpectedResult()
        {
            var expected = new int[][]
            {
                new int[] { 8, 9, 1, 2, 3 },
                new int[] { 9, 1, 2, 3, 4 },
                new int[] { 1, 2, 3, 4, 5 },
                new int[] { 2, 3, 4, 5, 6 },
                new int[] { 3, 4, 5, 6, 7 },
            };

            var actual = "8".ToEnumerable().ToIntArrays().ExpandArray(5);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.IsTrue(expected[i].SequenceEqual(actual[i]));
            }
        }

        [TestMethod]
        public void TwoExpansionsOfLargerExampleShallReturnExpectedResult()
        {
            var input = new int[][]
            {
                new int[] { 1,1, 2, 2 },
                new int[] { 2,2, 9, 9 }
            };

            var expected = new int[][]
            {
                new int[] { 1, 1, 2, 2, 2, 2, 3, 3 },
                new int[] { 2, 2, 9, 9, 3, 3, 1, 1 },
                new int[] { 2, 2, 3, 3, 3, 3, 4, 4 },
                new int[] { 3, 3, 1, 1, 4, 4, 2, 2 },
            };

            var actual = input.ExpandArray(2);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.IsTrue(expected[i].SequenceEqual(actual[i]));
            }
        }
    }
}
