using AdventOfCode2015.Day03;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AdventOfCode2015.Test.Unit
{
    [TestClass]
    public class Day03Tests
    {
        [TestMethod]
        public void PartOneDemoCalculationsShallReturnExpectedResults()
        {
            var examples = new Dictionary<string, long>
            {
                { ">", 2 },
                { "^>v<", 4 },
                { "^v^v^v^v^v", 2 }
            };

            foreach (var (example, expected) in examples)
            {
                Assert.AreEqual(expected, example.ParseInput().CalculatePartOne());
            }
        }

        [TestMethod]
        public void PartTwoDemoCalculationsShallReturnExpectedResults()
        {
            var examples = new Dictionary<string, long>
            {
                { "^v" , 3 },
                { "^>v<" , 3 },
                { "^v^v^v^v^v" , 11 }
            };

            foreach (var (example, expected) in examples)
            {
                Assert.AreEqual(expected, example.ParseInput().CalculatePartTwo());
            }
        }
    }
}
