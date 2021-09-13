using System.Collections.Generic;
using DealOrNoDeal.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DealOrNoDeal.Tests.GameManagerTests
{
    [TestClass]
    public class TestRemoveBriefcaseFromPlay
    {

        [TestMethod]
        public void ShouldNotRemoveBriefcaseIfBriefcaseIsNotPresentInListOfManyItems()
        {
            var manager = new GameManager(new List<int> { 1, 2, 3 }, new List<int> { 10, 20, 30 });

            Assert.AreEqual(-1, manager.RemoveBriefcaseFromPlay(4));
            Assert.AreEqual(0, manager.RoundManager.CasesLeftForCurrentRound);
        }

        [TestMethod]
        public void ShouldRemoveFirstBriefcase()
        {
            var manager = new GameManager(new List<int> { 2, 1 }, new List<int> { 10, 20, 30, 40 });

            Assert.AreNotEqual(-1, manager.RemoveBriefcaseFromPlay(0));
            Assert.AreEqual(1, manager.RoundManager.CasesLeftForCurrentRound);
        }

        [TestMethod]
        public void ShouldRemoveMiddleBriefcase()
        {
            var manager = new GameManager(new List<int> { 2, 1 }, new List<int> { 10, 20, 30, 40 });

            Assert.AreNotEqual(-1, manager.RemoveBriefcaseFromPlay(1));
            Assert.AreEqual(1, manager.RoundManager.CasesLeftForCurrentRound);
        }

        [TestMethod]
        public void ShouldRemoveLastBriefcase()
        {
            var manager = new GameManager(new List<int> { 2, 1 }, new List<int> { 10, 20, 30, 40 });

            Assert.AreNotEqual(-1, manager.RemoveBriefcaseFromPlay(2));
            Assert.AreEqual(1, manager.RoundManager.CasesLeftForCurrentRound);
        }
    }
}
