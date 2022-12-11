using AdventOfCode.Shared;
using AdventOfCode2022.Day09;

namespace AdventOfCode2022.Test.Unit
{
    [TestClass]
    public class Day09Tests
    {
        private const string TestInputPath = "Day09Demo.txt";

        [TestMethod]
        public void PartOneShallReturnExpectedOutput()
        {
            const int expected = 13;

            var actual = File.ReadLines(TestInputPath).ParseInput().CalculatePartOne();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DynamicData(nameof(TestRopes), DynamicDataSourceType.Method)]
        public void PartOneShallReturnExpectedOutputForInputs(
            Coordinate2D headStart,
            Coordinate2D tailStart,
            (int, int) direction,
            Coordinate2D expectedTailPosition)
        {
            var (_, actualTailPosition) = Calculations.MoveHead(headStart, tailStart, direction);

            Assert.AreEqual(expectedTailPosition, actualTailPosition);
        }

        [TestMethod]
        public void PartTwoShallReturnExpectedOutput()
        {
            const int expected = 0;

            var actual = File.ReadLines(TestInputPath).ParseInput().CalculatePartTwo();

            Assert.AreEqual(expected, actual);
        }

        private static IEnumerable<object[]> TestRopes()
        {
            yield return TypeSafety(
                (1, 1),
                (1, 1),
                (0, 1), // Up
                (1, 1)
            );

            yield return TypeSafety(
                (1, 2),
                (1, 1),
                (0, 1), // Up
                (1, 2)
            );

            yield return TypeSafety(
                (1, 0),
                (1, 1),
                (0, -1), // Down
                (1, 0)
            );

            yield return TypeSafety(
                (2, 2),
                (1, 1),
                (0, 1), // Up
                (2, 2)
            );

            yield return TypeSafety(
                (1, 1),
                (2, 0),
                (-1, 0), // Left
                (1, 1)
            );

            static object[] TypeSafety(Coordinate2D headStart, Coordinate2D tailStart, (int, int) direction, Coordinate2D expectedTailPosition)
            {
                return new object[] { headStart, tailStart, direction, expectedTailPosition };
            }
        }
    }
}
