using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DealOrNoDeal.Tests.RoundManager
{
    [TestClass]
    public class TestDecrementCasesLeftForCurrentRound
    {
        [TestMethod]
        public void ShouldDecrementIfCasesLeftAreOne()
        {
            var manager = new Model.RoundManager(new List<int> {1, 2, 3});
            Assert.AreEqual(1, manager.CasesLeftForCurrentRound);
            manager.DecrementCasesLeftForCurrentRound();
            Assert.AreEqual(0, manager.CasesLeftForCurrentRound);
        }

        [TestMethod]
        public void ShouldDecrementIfCasesLeftAreWellAboveOne()
        {
            var manager = new Model.RoundManager(new List<int> { 10, 2, 3 });
            Assert.AreEqual(10, manager.CasesLeftForCurrentRound);
            manager.DecrementCasesLeftForCurrentRound();
            Assert.AreEqual(9, manager.CasesLeftForCurrentRound);
        }
    }
}
