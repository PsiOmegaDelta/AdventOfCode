using AdventOfCode.Shared;
using AdventOfCode2022.Day08;

namespace AdventOfCode2022.Test.Unit
{
    [TestClass]
    public class Day08Tests
    {
        private const string TestInputPath = "Day08Demo.txt";

        [TestMethod]
        public void PartOneShallReturnExpectedOutput()
        {
            const int expected = 21;

            var actual = File.ReadLines(TestInputPath).ToSparsePlane(x => (int?)char.GetNumericValue(x)).CalculatePartOne();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DynamicData(nameof(TestForests), DynamicDataSourceType.Method)]
        public void PartOneShallReturnExpectedOutputForInputs(SparsePlane<int?> trees, int expected)
        {
            var actual = trees.CalculatePartOne();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoShallReturnExpectedOutput()
        {
            const int expected = 24933642;

            var actual = File.ReadLines(TestInputPath).ToSparsePlane(x => (int?)char.GetNumericValue(x)).CalculatePartTwo();

            Assert.AreEqual(expected, actual);
        }

        private static IEnumerable<object[]> TestForests()
        {
            yield return TypeSafety(new[]
            {
                "989",
                "999",
                "999"
            }.ToSparsePlane(x => (int?)char.GetNumericValue(x)),
            9);

            yield return TypeSafety(new[]
            {
                "999",
                "998",
                "999"
            }.ToSparsePlane(x => (int?)char.GetNumericValue(x)),
            9);

            yield return TypeSafety(new[]
            {
                "999",
                "999",
                "989"
            }.ToSparsePlane(x => (int?)char.GetNumericValue(x)),
            9);

            yield return TypeSafety(new[]
            {
                "999",
                "899",
                "999"
            }.ToSparsePlane(x => (int?)char.GetNumericValue(x)),
            9);
            yield return TypeSafety(new[]
            {
                "888",
                "898",
                "888"
            }.ToSparsePlane(x => (int?)char.GetNumericValue(x)),
            9);

            yield return TypeSafety(new[]
            {
                "414",
                "424",
                "434",
                "444"
            }.ToSparsePlane(x => (int?)char.GetNumericValue(x)),
            12);

            yield return TypeSafety(new[]
            {
                "9999999990999999999",
                "9999999991999999999",
                "9999999992999999999",
                "9999999993999999999",
                "9999999994999999999",
                "9999999995999999999",
                "9999999996999999999",
                "9999999997999999999",
                "9999999998999999999",
                "0123456789876543210",
                "9999999998999999999",
                "9999999997999999999",
                "9999999996999999999",
                "9999999995999999999",
                "9999999994999999999",
                "9999999993999999999",
                "9999999992999999999",
                "9999999991999999999",
                "9999999990999999999"
            }.ToSparsePlane(x => (int?)char.GetNumericValue(x)),
            19 + 19 + 17 + 17 + 17 + 16);

            yield return TypeSafety(new[]
            {
                "99199",
                "93239",
                "99999"
            }.ToSparsePlane(x => (int?)char.GetNumericValue(x)),
            5 + 3 + 5);

            static object[] TypeSafety(SparsePlane<int?> trees, int expected)
            {
                return new object[] { trees, expected };
            }
        }
    }
}
