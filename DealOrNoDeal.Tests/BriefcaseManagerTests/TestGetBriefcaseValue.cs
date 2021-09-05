using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DealOrNoDeal.Data;
using DealOrNoDeal.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DealOrNoDeal.Tests.BriefcaseManagerTests
{
    [TestClass]
    public class TestGetBriefcaseValue
    {
        [TestMethod]
        public void ShouldGetBriefcaseIfBriefcaseIsInBriefcaseManager()
        {
            var gameManager = new BriefcaseManager(CasesToOpenForEachRound.TenRoundCases);
            IList<int> mockRandomIndexes = new List<int> { 0 };
            IList<int> dollarValues = new List<int> { 1 };
            gameManager.PopulateBriefcases(mockRandomIndexes, dollarValues);

            var briefcase = gameManager.GetBriefcaseValue(0);

            Assert.AreEqual(1, briefcase);
        }

        [TestMethod]
        public void ShouldNotGetBriefcaseIfBriefcaseIsNotInBriefcaseManager()
        {
            var gameManager = new BriefcaseManager(CasesToOpenForEachRound.TenRoundCases);
            IList<int> mockRandomIndexes = new List<int> { 0 };
            IList<int> dollarValues = new List<int> { 1 };
            gameManager.PopulateBriefcases(mockRandomIndexes, dollarValues);

            var briefcase = gameManager.GetBriefcaseValue(1);
            Assert.AreEqual(-1, briefcase);
        }

        [TestMethod]
        public void ShouldGetFirstOfManyBriefcases()
        {
            var gameManager = new BriefcaseManager(CasesToOpenForEachRound.TenRoundCases);
            IList<int> mockRandomIndexes = new List<int> { 0, 1, 2 };
            IList<int> dollarValues = new List<int> { 1, 3, 5 };
            gameManager.PopulateBriefcases(mockRandomIndexes, dollarValues);

            var briefcase = gameManager.GetBriefcaseValue(0);
            Assert.AreEqual(1, briefcase);
        }

        [TestMethod]
        public void ShouldGetMiddleOfManyBriefcases()
        {
            var gameManager = new BriefcaseManager(CasesToOpenForEachRound.TenRoundCases);
            IList<int> mockRandomIndexes = new List<int> { 0, 1, 2 };
            IList<int> dollarValues = new List<int> { 1, 3, 5 };
            gameManager.PopulateBriefcases(mockRandomIndexes, dollarValues);

            var briefcase = gameManager.GetBriefcaseValue(1);
            Assert.AreEqual(3, briefcase);
        }

        [TestMethod]
        public void ShouldGetLastOfManyBriefcases()
        {
            var gameManager = new BriefcaseManager(CasesToOpenForEachRound.TenRoundCases);
            IList<int> mockRandomIndexes = new List<int> { 0, 1, 2 };
            IList<int> dollarValues = new List<int> { 1, 3, 5 };
            gameManager.PopulateBriefcases(mockRandomIndexes, dollarValues);

            var briefcase = gameManager.GetBriefcaseValue(2);
            Assert.AreEqual(5, briefcase);
        }

        [TestMethod]
        public void ShouldNotGetBriefcaseIfNotPresentInListOfManyBriefcases()
        {
            var gameManager = new BriefcaseManager(CasesToOpenForEachRound.TenRoundCases);
            IList<int> mockRandomIndexes = new List<int> { 0, 1, 2 };
            IList<int> dollarValues = new List<int> { 1, 3, 5 };
            gameManager.PopulateBriefcases(mockRandomIndexes, dollarValues);

            var briefcase = gameManager.GetBriefcaseValue(10);
            Assert.AreEqual(-1, briefcase);
        }
    }
}
