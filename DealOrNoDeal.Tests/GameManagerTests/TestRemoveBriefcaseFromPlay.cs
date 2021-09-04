using System.Collections.Generic;
using DealOrNoDeal.Data;
using DealOrNoDeal.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DealOrNoDeal.Tests.GameManagerTests
{
    [TestClass]
    public class TestRemoveBriefcaseFromPlay
    {
        [TestMethod]
        public void ShouldNotRemoveBriefcaseFromEmptyList()
        {
            GameManager manager = new GameManager(new List<int>(), new List<int>());

            Assert.AreEqual(-1, manager.RemoveBriefcaseFromPlay(1));
            Assert.AreEqual(0, manager.RoundManager.CasesLeftForCurrentRound);
        }

        [TestMethod]
        public void ShouldNotRemoveBriefcaseIfBriefcaseIsNotPresentInListOfOneItem()
        {
            GameManager manager = new GameManager(new List<int>() { 1 }, new List<int>() { 10 });

            Assert.AreEqual(-1, manager.RemoveBriefcaseFromPlay(1));
            Assert.AreEqual(0, manager.RoundManager.CasesLeftForCurrentRound);
        }

        [TestMethod]
        public void ShouldNotRemoveBriefcaseIfBriefcaseIsNotPresentInListOfManyItems()
        {
            GameManager manager = new GameManager(new List<int>() { 1, 2, 3 }, new List<int>() { 10, 20, 30 });

            Assert.AreEqual(-1, manager.RemoveBriefcaseFromPlay(4));
            Assert.AreEqual(0, manager.RoundManager.CasesLeftForCurrentRound);
        }

        [TestMethod]
        public void ShouldRemoveOnlyBriefcaseInList()
        {
            GameManager manager = new GameManager(new List<int>() { 1 }, new List<int>() { 10 });

            Assert.AreEqual(10, manager.RemoveBriefcaseFromPlay(0));
            Assert.AreEqual(0, manager.RoundManager.CasesLeftForCurrentRound);
        }

        [TestMethod]
        public void ShouldRemoveFirstBriefcase()
        {
            GameManager manager = new GameManager(new List<int>() { 2, 1 }, new List<int>() { 10, 20, 30, 40 });

            Assert.AreNotEqual(-1, manager.RemoveBriefcaseFromPlay(0));
            Assert.AreEqual(1, manager.RoundManager.CasesLeftForCurrentRound);
        }

        [TestMethod]
        public void ShouldRemoveMiddleBriefcase()
        {
            GameManager manager = new GameManager(new List<int>() { 2, 1 }, new List<int>() { 10, 20, 30, 40 });

            Assert.AreNotEqual(-1, manager.RemoveBriefcaseFromPlay(1));
            Assert.AreEqual(1, manager.RoundManager.CasesLeftForCurrentRound);
        }

        [TestMethod]
        public void ShouldRemoveLastBriefcase()
        {
            GameManager manager = new GameManager(new List<int>() { 2, 1 }, new List<int>() { 10, 20, 30, 40 });

            Assert.AreNotEqual(-1, manager.RemoveBriefcaseFromPlay(2));
            Assert.AreEqual(1, manager.RoundManager.CasesLeftForCurrentRound);
        }
    }
}
