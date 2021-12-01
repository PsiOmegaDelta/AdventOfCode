using AdventOfCode2021.DayOne;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2021.Test.Unit
{
    [TestClass]
    public class DayOne
    {
        [TestMethod]
        public async Task PartOneShallReturnExpectedOutput()
        {
            var input = (await File.ReadAllLinesAsync("DayOneDemo.txt")).Select(x => int.Parse(x)).ToList();
            const int expected = 7;
            var actual = input.GetNumberOfIncrements();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task PartTwoShallReturnExpectedOutput()
        {
            var input = (await File.ReadAllLinesAsync("DayOneDemo.txt")).Select(x => int.Parse(x)).ToList();
            const int expected = 5;
            var actual = input.SumGroups(3).GetNumberOfIncrements();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task SumGroupsExtensionShallReturnExpectedOutputs()
        {
            var input = (await File.ReadAllLinesAsync("DayOneDemo.txt")).Select(x => int.Parse(x)).ToList();
            var expectedOutputs = new List<int> { 607, 618, 618, 617, 647, 716, 769, 792 };
            var actualOutputs = input.SumGroups(3).ToList();

            Assert.AreEqual(expectedOutputs.Count, actualOutputs.Count);
            foreach (var (expectedOutput, actualOutput) in expectedOutputs.Zip(actualOutputs, (x, y) => (x, y)))
            {
                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }
    }
}
