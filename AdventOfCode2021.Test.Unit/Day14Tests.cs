using AdventOfCode2021.Day14;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AdventOfCode2021.Test.Unit
{
    [TestClass]
    public class Day14Tests
    {
        private const string InputPath = "Day14Demo.txt";

        [TestMethod]
        public void ConductedStepsShallProduceExpectedResults()
        {
            var (template, inputs) = InputParser.ParseInput(InputPath);
            var expectations = new List<string> { "NCNBCHB", "NBCCNBBBCBHCB", "NBBBCNCCNBBNBNBBCHBHHBCHB", "NBBNBNBBCCNBCNCCNBBNBBNBBBNBBNBBCBHCBHHNHCBBCBHCB" };

            var actual = template;
            foreach (var expected in expectations)
            {
                actual = PartOne.ConductStep(inputs, actual);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void PartOneDemoCalculationShallReturnExpectedResult()
        {
            const long expected = 1588;
            var actual = InputParser.ParseInput(InputPath).CalculatePartOne(10);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoDemoCalculationShallReturnExpectedResultFor10Steps()
        {
            const long expected = 1588;
            var actual = InputParser.ParseInput(InputPath).CalculatePartTwo(10);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoDemoCalculationShallReturnExpectedResultFor40Steps()
        {
            const long expected = 2188189693529;
            var actual = InputParser.ParseInput(InputPath).CalculatePartTwo(40);

            Assert.AreEqual(expected, actual);
        }
    }
}
