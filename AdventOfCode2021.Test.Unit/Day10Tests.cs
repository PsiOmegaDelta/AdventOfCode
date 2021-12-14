using AdventOfCode.Shared.Extensions;
using AdventOfCode2021.Day10;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.Test.Unit
{
    [TestClass]
    public class Day10Tests
    {
        private const string InputPath = "Day10Demo.txt";

        [TestMethod]
        public void PartOneDemoCalculationShallReturnExpectedResult()
        {
            const int expected = 26397;
            var actual = PartOne.CalculateResult(File.ReadLines(InputPath));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoDemoCalculationShallReturnExpectedResult()
        {
            const long expected = 288957;
            var actual = PartTwo.CalculateResult(File.ReadLines(InputPath));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShallDetectExpectedInvalidBracket()
        {
            var inputsAndErrors = new Dictionary<string, char>
            {
                { "{([(<{}[<>[]}>{[]{[(<()>", '}' },
                { "[[<[([]))<([[{}[[()]]]", ')' },
                { "[{[{({}]{}}([{[{{{}}([]", ']' },
                { "[<(<(<(<{}))><([]([]()", ')' },
                { "<{([([[(<>()){}]>(<<{{", '>' }
            };

            foreach (var (input, expected) in inputsAndErrors)
            {
                var actual = input.InvalidBrackets().First();
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void ShallReturnExpectedMissingBracketPoints()
        {
            var inputsAndErrors = new Dictionary<string, long>
            {
                { "[({(<(())[]>[[{[]{<()<>>", 288957 },
                { "[(()[<>])]({[<{<<[]>>(", 5566 },
                { "(((({<>}<{<{<>}{[]{[]{}", 1480781 },
                { "{<[[]]>}<{[{[{[]{()[[[]", 995444 },
                { "<{([{{}}[<[[[<>{}]]]>[]]", 294 }
            };

            foreach (var (input, expected) in inputsAndErrors)
            {
                var actual = PartTwo.CalculateResult(input.ToEnumerable());
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void ShallReturnExpectedMissingBrackets()
        {
            var inputsAndErrors = new Dictionary<string, string>
            {
                { "[({(<(())[]>[[{[]{<()<>>", "}}]])})]" },
                { "[(()[<>])]({[<{<<[]>>(", ")}>]})" },
                { "(((({<>}<{<{<>}{[]{[]{}", "}}>}>))))" },
                { "{<[[]]>}<{[{[{[]{()[[[]", "]]}}]}]}>" },
                { "<{([{{}}[<[[[<>{}]]]>[]]", "])}>" }
            };

            foreach (var (input, expected) in inputsAndErrors)
            {
                var actual = new string(input.MissingBrackets().ToArray());
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
