using AdventOfCode.Shared.Extensions;
using AdventOfCode2015.Day02;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AdventOfCode2015.Test.Unit
{
    [TestClass]
    public class Day02Tests
    {
        [TestMethod]
        public void PartOneDemoCalculationsShallReturnExpectedResults()
        {
            var examples = new Dictionary<IEnumerable<string>, long>
            {
                { "2x3x4".ToEnumerable() , 58 },
                { "1x1x10".ToEnumerable()  , 43 }
            };

            foreach (var (example, expected) in examples)
            {
                Assert.AreEqual(expected, example.ParseInput().CalculatePartOne());
            }
        }

        [TestMethod]
        public void PartTwoDemoCalculationsShallReturnExpectedResults()
        {
            var examples = new Dictionary<IEnumerable<string>, long>
            {
                { "2x3x4".ToEnumerable() , 34 },
                { "1x1x10".ToEnumerable() , 14 }
            };

            foreach (var (example, expected) in examples)
            {
                Assert.AreEqual(expected, example.ParseInput().CalculatePartTwo());
            }
        }
    }
}
