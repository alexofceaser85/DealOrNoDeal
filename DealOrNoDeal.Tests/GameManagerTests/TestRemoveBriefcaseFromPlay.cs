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
        public void ShouldNotRemoveOneBriefcaseIfNotPresentInListOfOneBriefcase()
        {
            var gameManager = new GameManager(CasesToOpenForEachRound.TEN_ROUND_CASES);
            IList<int> mockRandomIndexes = new List<int> { 0 };
            IList<int> dollarValues = new List<int> { 10 };
            gameManager.PopulateBriefcases(mockRandomIndexes, dollarValues);

            Assert.AreEqual(-1, gameManager.RemoveBriefcaseFromPlay(5));

            Assert.AreEqual(10, gameManager.GetBriefcaseValue(0));
        }

        [TestMethod]
        public void ShouldRemoveOneBriefcaseIfOnlyBriefcaseInList()
        {
            var gameManager = new GameManager(CasesToOpenForEachRound.TEN_ROUND_CASES);
            IList<int> mockRandomIndexes = new List<int> { 0 };
            IList<int> dollarValues = new List<int> { 10 };
            gameManager.PopulateBriefcases(mockRandomIndexes, dollarValues);

            Assert.AreEqual(10, gameManager.RemoveBriefcaseFromPlay(0));

            Assert.AreEqual(-1, gameManager.GetBriefcaseValue(0));
        }

        [TestMethod]
        public void ShouldRemoveFirstOfManyBriefcases()
        {
            var gameManager = new GameManager(CasesToOpenForEachRound.TEN_ROUND_CASES);
            IList<int> mockRandomIndexes = new List<int> { 2, 0, 1 };
            IList<int> dollarValues = new List<int> { 1, 3, 5 };
            gameManager.PopulateBriefcases(mockRandomIndexes, dollarValues);

            Assert.AreEqual(5, gameManager.RemoveBriefcaseFromPlay(0));

            Assert.AreEqual(-1, gameManager.GetBriefcaseValue(0));
            Assert.AreEqual(1, gameManager.GetBriefcaseValue(1));
            Assert.AreEqual(3, gameManager.GetBriefcaseValue(2));
        }

        [TestMethod]
        public void ShouldRemoveMiddleOfManyBriefcases()
        {
            var gameManager = new GameManager(CasesToOpenForEachRound.TEN_ROUND_CASES);
            IList<int> mockRandomIndexes = new List<int> { 2, 0, 1 };
            IList<int> dollarValues = new List<int> { 1, 3, 5 };
            gameManager.PopulateBriefcases(mockRandomIndexes, dollarValues);

            Assert.AreEqual(1, gameManager.RemoveBriefcaseFromPlay(1));

            Assert.AreEqual(5, gameManager.GetBriefcaseValue(0));
            Assert.AreEqual(-1, gameManager.GetBriefcaseValue(1));
            Assert.AreEqual(3, gameManager.GetBriefcaseValue(2));
        }

        [TestMethod]
        public void ShouldRemoveLastOfManyBriefcases()
        {
            var gameManager = new GameManager(CasesToOpenForEachRound.TEN_ROUND_CASES);
            IList<int> mockRandomIndexes = new List<int> { 2, 0, 1 };
            IList<int> dollarValues = new List<int> { 1, 3, 5 };
            gameManager.PopulateBriefcases(mockRandomIndexes, dollarValues);

            Assert.AreEqual(3, gameManager.RemoveBriefcaseFromPlay(2));

            Assert.AreEqual(5, gameManager.GetBriefcaseValue(0));
            Assert.AreEqual(1, gameManager.GetBriefcaseValue(1));
            Assert.AreEqual(-1, gameManager.GetBriefcaseValue(2));
        }

        [TestMethod]
        public void ShouldNotRemoveBriefcaseIfItIsNotPresentInListOfManyBriefcases()
        {
            var gameManager = new GameManager(CasesToOpenForEachRound.TEN_ROUND_CASES);
            IList<int> mockRandomIndexes = new List<int> { 2, 0, 1 };
            IList<int> dollarValues = new List<int> { 1, 3, 5 };
            gameManager.PopulateBriefcases(mockRandomIndexes, dollarValues);

            Assert.AreEqual(-1, gameManager.RemoveBriefcaseFromPlay(10));

            Assert.AreEqual(5, gameManager.GetBriefcaseValue(0));
            Assert.AreEqual(1, gameManager.GetBriefcaseValue(1));
            Assert.AreEqual(3, gameManager.GetBriefcaseValue(2));
        }
    }
}
