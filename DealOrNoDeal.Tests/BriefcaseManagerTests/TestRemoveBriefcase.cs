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
    public class TestRemoveBriefcase
    {
        [TestMethod]
        public void ShouldNotRemoveOneBriefcaseIfNotPresentInListOfOneBriefcase()
        {
            var briefcaseManager = new BriefcaseManager(CasesToOpenForEachRound.TEN_ROUND_CASES);
            IList<int> mockRandomIndexes = new List<int> { 0 };
            IList<int> dollarValues = new List<int> { 10 };
            briefcaseManager.PopulateBriefcases(mockRandomIndexes, dollarValues);

            Assert.AreEqual(-1, briefcaseManager.RemoveBriefcase(5));

            Assert.AreEqual(10, briefcaseManager.GetBriefcaseValue(0));
        }

        [TestMethod]
        public void ShouldRemoveOneBriefcaseIfOnlyBriefcaseInList()
        {
            var briefcaseManager = new BriefcaseManager(CasesToOpenForEachRound.TEN_ROUND_CASES);
            IList<int> mockRandomIndexes = new List<int> { 0 };
            IList<int> dollarValues = new List<int> { 10 };
            briefcaseManager.PopulateBriefcases(mockRandomIndexes, dollarValues);

            Assert.AreEqual(10, briefcaseManager.RemoveBriefcase(0));

            Assert.AreEqual(-1, briefcaseManager.GetBriefcaseValue(0));
        }

        [TestMethod]
        public void ShouldRemoveFirstOfManyBriefcases()
        {
            var briefcaseManager = new BriefcaseManager(CasesToOpenForEachRound.TEN_ROUND_CASES);
            IList<int> mockRandomIndexes = new List<int> { 2, 0, 1 };
            IList<int> dollarValues = new List<int> { 1, 3, 5 };
            briefcaseManager.PopulateBriefcases(mockRandomIndexes, dollarValues);

            Assert.AreEqual(5, briefcaseManager.RemoveBriefcase(0));

            Assert.AreEqual(-1, briefcaseManager.GetBriefcaseValue(0));
            Assert.AreEqual(1, briefcaseManager.GetBriefcaseValue(1));
            Assert.AreEqual(3, briefcaseManager.GetBriefcaseValue(2));
        }

        [TestMethod]
        public void ShouldRemoveMiddleOfManyBriefcases()
        {
            var briefcaseManager = new BriefcaseManager(CasesToOpenForEachRound.TEN_ROUND_CASES);
            IList<int> mockRandomIndexes = new List<int> { 2, 0, 1 };
            IList<int> dollarValues = new List<int> { 1, 3, 5 };
            briefcaseManager.PopulateBriefcases(mockRandomIndexes, dollarValues);

            Assert.AreEqual(1, briefcaseManager.RemoveBriefcase(1));

            Assert.AreEqual(5, briefcaseManager.GetBriefcaseValue(0));
            Assert.AreEqual(-1, briefcaseManager.GetBriefcaseValue(1));
            Assert.AreEqual(3, briefcaseManager.GetBriefcaseValue(2));
        }

        [TestMethod]
        public void ShouldRemoveLastOfManyBriefcases()
        {
            var briefcaseManager = new BriefcaseManager(CasesToOpenForEachRound.TEN_ROUND_CASES);
            IList<int> mockRandomIndexes = new List<int> { 2, 0, 1 };
            IList<int> dollarValues = new List<int> { 1, 3, 5 };
            briefcaseManager.PopulateBriefcases(mockRandomIndexes, dollarValues);

            Assert.AreEqual(3, briefcaseManager.RemoveBriefcase(2));

            Assert.AreEqual(5, briefcaseManager.GetBriefcaseValue(0));
            Assert.AreEqual(1, briefcaseManager.GetBriefcaseValue(1));
            Assert.AreEqual(-1, briefcaseManager.GetBriefcaseValue(2));
        }

        [TestMethod]
        public void ShouldNotRemoveBriefcaseIfItIsNotPresentInListOfManyBriefcases()
        {
            var briefcaseManager = new BriefcaseManager(CasesToOpenForEachRound.TEN_ROUND_CASES);
            IList<int> mockRandomIndexes = new List<int> { 2, 0, 1 };
            IList<int> dollarValues = new List<int> { 1, 3, 5 };
            briefcaseManager.PopulateBriefcases(mockRandomIndexes, dollarValues);

            Assert.AreEqual(-1, briefcaseManager.RemoveBriefcase(10));

            Assert.AreEqual(5, briefcaseManager.GetBriefcaseValue(0));
            Assert.AreEqual(1, briefcaseManager.GetBriefcaseValue(1));
            Assert.AreEqual(3, briefcaseManager.GetBriefcaseValue(2));
        }
    }
}
