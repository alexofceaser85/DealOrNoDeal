using System.Collections.Generic;
using DealOrNoDeal.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DealOrNoDeal.Tests.GameManagerTests
{
    [TestClass]
    public class TestGetBriefcaseValue
    {

        [TestMethod]
        public void ShouldGetBriefcaseIfBriefcaseIsInGameManager()
        {
            var gameManager = new GameManager();
            IList<int> mockRandomIndexes = new List<int>() { 0 };
            IList<int> dollarValues = new List<int>() { 1 };
            gameManager.PopulateBriefcases(mockRandomIndexes, dollarValues);

            var briefcase = gameManager.GetBriefcaseValue(0);

            Assert.AreEqual(1, briefcase);
        }

        [TestMethod]
        public void ShouldNotGetBriefcaseIfBriefcaseIsNotInGameManager()
        {
            var gameManager = new GameManager();
            IList<int> mockRandomIndexes = new List<int>() { 0 };
            IList<int> dollarValues = new List<int>() { 1 };
            gameManager.PopulateBriefcases(mockRandomIndexes, dollarValues);

            var briefcase = gameManager.GetBriefcaseValue(1);
            Assert.AreEqual(-1, briefcase);
        }

        [TestMethod]
        public void ShouldGetFirstOfManyBriefcases()
        {
            var gameManager = new GameManager();
            IList<int> mockRandomIndexes = new List<int>() { 0, 1, 2 };
            IList<int> dollarValues = new List<int>() { 1, 3, 5 };
            gameManager.PopulateBriefcases(mockRandomIndexes, dollarValues);

            var briefcase = gameManager.GetBriefcaseValue(0);
            Assert.AreEqual(1, briefcase);
        }

        [TestMethod]
        public void ShouldGetMiddleOfManyBriefcases()
        {
            var gameManager = new GameManager();
            IList<int> mockRandomIndexes = new List<int>() { 0, 1, 2 };
            IList<int> dollarValues = new List<int>() { 1, 3, 5 };
            gameManager.PopulateBriefcases(mockRandomIndexes, dollarValues);

            var briefcase = gameManager.GetBriefcaseValue(1);
            Assert.AreEqual(3, briefcase);
        }

        [TestMethod]
        public void ShouldGetLastOfManyBriefcases()
        {
            var gameManager = new GameManager();
            IList<int> mockRandomIndexes = new List<int>() { 0, 1, 2 };
            IList<int> dollarValues = new List<int>() { 1, 3, 5 };
            gameManager.PopulateBriefcases(mockRandomIndexes, dollarValues);

            var briefcase = gameManager.GetBriefcaseValue(2);
            Assert.AreEqual(5, briefcase);
        }

        [TestMethod]
        public void ShouldNotGetBriefcaseIfNotPresentInListOfManyBriefcases()
        {
            var gameManager = new GameManager();
            IList<int> mockRandomIndexes = new List<int>() { 0, 1, 2 };
            IList<int> dollarValues = new List<int>() { 1, 3, 5 };
            gameManager.PopulateBriefcases(mockRandomIndexes, dollarValues);

            var briefcase = gameManager.GetBriefcaseValue(10);
            Assert.AreEqual(-1, briefcase);
        }
    }
}
