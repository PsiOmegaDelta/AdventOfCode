using AdventOfCode2021.Day01;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoreLinq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2021.Test.Unit
{
    [TestClass]
    public class Day01Tests
    {
        [TestMethod]
        public async Task PartOneShallReturnExpectedOutput()
        {
            var input = (await File.ReadAllLinesAsync("Day01Demo.txt").ConfigureAwait(false)).Select(x => int.Parse(x)).ToList();
            const int expected = 7;
            var actual = input.GetIncrementations();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task PartTwoShallReturnExpectedOutput()
        {
            var input = (await File.ReadAllLinesAsync("Day01Demo.txt").ConfigureAwait(false)).Select(x => int.Parse(x)).ToList();
            const int expected = 5;
            var actual = input.Window(3).Select(x => x.Sum()).GetIncrementations();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task SlidingWindowShallReturnExpectedOutputs()
        {
            var input = (await File.ReadAllLinesAsync("Day01Demo.txt").ConfigureAwait(false)).Select(x => int.Parse(x)).ToList();
            var expectedOutputs = new List<int> { 607, 618, 618, 617, 647, 716, 769, 792 };
            var actualOutputs = input.Window(3).Select(x => x.Sum()).ToList();

            Assert.AreEqual(expectedOutputs.Count, actualOutputs.Count);
            foreach (var (expectedOutput, actualOutput) in expectedOutputs.Zip(actualOutputs, (x, y) => (x, y)))
            {
                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }
    }
}
