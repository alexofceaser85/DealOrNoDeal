using System;
using System.Collections.Generic;
using DealOrNoDeal.Data;
using DealOrNoDeal.ErrorMessages;
using DealOrNoDeal.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DealOrNoDeal.Tests.GameManagerTests
{
    [TestClass]
    public class TestPopulateBriefcases
    {
        [TestMethod]
        public void ShouldNotAllowNullDollarValuesToPopulate()
        {
            var gameManager = new GameManager(CasesToOpenForEachRound.TEN_ROUND_CASES);
            IList<int> mockRandomIndexes = new List<int> { 2, 0, 1 };
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                gameManager.PopulateBriefcases(mockRandomIndexes, null);
            });

            Assert.AreEqual(GameManagerErrorMessages.ShouldNotPopulateBriefcasesIfDollarValuesAreNull, message.Message);
        }

        [TestMethod]
        public void ShouldNotAllowNullIndexesOfDollarValuesToPopulate()
        {
            var gameManager = new GameManager(CasesToOpenForEachRound.TEN_ROUND_CASES);
            IList<int> dollarValues = new List<int> { 1, 3, 5 };
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                gameManager.PopulateBriefcases(null, dollarValues);
            });

            Assert.AreEqual(GameManagerErrorMessages.ShouldNotPopulateBriefcasesIfIndexesOfDollarValuesAreNull, message.Message);
        }

        [TestMethod]
        public void ShouldPopulateBriefcases()
        {
            var gameManager = new GameManager(CasesToOpenForEachRound.TEN_ROUND_CASES);
            IList<int> mockRandomIndexes = new List<int> { 2, 0, 1 };
            IList<int> dollarValues = new List<int> { 1, 3, 5 };
            gameManager.PopulateBriefcases(mockRandomIndexes, dollarValues);

            Assert.AreEqual(5, gameManager.GetBriefcaseValue(0));
            Assert.AreEqual(1, gameManager.GetBriefcaseValue(1));
            Assert.AreEqual(3, gameManager.GetBriefcaseValue(2));
        }
    }
}
