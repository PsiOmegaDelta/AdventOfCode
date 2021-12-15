using AdventOfCode2015.Day01;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AdventOfCode2015.Test.Unit
{
    [TestClass]
    public class Day01Tests
    {
        [TestMethod]
        public void PartOneDemoCalculationsShallReturnExpectedResults()
        {
            var examples = new Dictionary<string, long>
            {
                { "(())" , 0 },
                { "()()" , 0 },
                { "(((" , 3 },
                { "(()(()(" , 3 },
                { "))(((((" , 3 },
                { "())" , -1 },
                { "))(" , -1 },
                { ")))" , -3 },
                { ")())())" , -3 }
            };

            foreach (var (example, expected) in examples)
            {
                Assert.AreEqual(expected, example.CalculatePartOne());
            }
        }

        [TestMethod]
        public void PartTwoDemoCalculationsShallReturnExpectedResults()
        {
            var examples = new Dictionary<string, long>
            {
                { ")" , 1 },
                { "()())" , 5 }
            };

            foreach (var (example, expected) in examples)
            {
                Assert.AreEqual(expected, example.CalculatePartTwo());
            }
        }
    }
}
