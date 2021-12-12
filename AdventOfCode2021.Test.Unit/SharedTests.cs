using AdventOfCode2021.Shared.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Test.Unit
{
    [TestClass]
    public class SharedTests
    {
        [TestMethod]
        public void ShallOnlyReceiveOneInstanceOfDuplicatesIfRequested()
        {
            CollectionAssert.AreEqual(new List<string> { "a" }, new List<string> { "a", "a", "a" }.Duplicates(false).ToList());
        }

        [TestMethod]
        public void ShallReceiveAllDuplicateInstancesWhenRequested()
        {
            CollectionAssert.AreEqual(new List<string> { "a", "a" }, new List<string> { "a", "a", "a" }.Duplicates(true).ToList());
        }
    }
}
