using System;
using System.Collections.Generic;
using DealOrNoDeal.Data.Rounds;
using DealOrNoDeal.ErrorMessages;
using DealOrNoDeal.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DealOrNoDeal.Tests.BriefcaseManagerTests
{
    [TestClass]
    public class TestPopulateBriefcases
    {
        [TestMethod]
        public void ShouldNotAllowNullDollarValuesToPopulate()
        {
            var briefcaseManager = new BriefcaseManager(CasesToOpenForEachRound.TenRoundCases);
            IList<int> mockRandomIndexes = new List<int> { 2, 0, 1 };
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                briefcaseManager.PopulateBriefcases(mockRandomIndexes, null);
            });

            Assert.AreEqual(BriefcaseManagerErrorMessages.ShouldNotPopulateBriefcasesIfDollarValuesAreNull, message.Message);
        }

        [TestMethod]
        public void ShouldNotAllowNullIndexesOfDollarValuesToPopulate()
        {
            var briefcaseManager = new BriefcaseManager(CasesToOpenForEachRound.TenRoundCases);
            IList<int> dollarValues = new List<int> { 1, 3, 5 };
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                briefcaseManager.PopulateBriefcases(null, dollarValues);
            });

            Assert.AreEqual(BriefcaseManagerErrorMessages.ShouldNotPopulateBriefcasesIfIndexesOfDollarValuesAreNull, message.Message);
        }

        [TestMethod]
        public void ShouldPopulateBriefcases()
        {
            var briefcaseManager = new BriefcaseManager(CasesToOpenForEachRound.TenRoundCases);
            IList<int> mockRandomIndexes = new List<int> { 2, 0, 1 };
            IList<int> dollarValues = new List<int> { 1, 3, 5 };
            briefcaseManager.PopulateBriefcases(mockRandomIndexes, dollarValues);

            Assert.AreEqual(5, briefcaseManager.GetBriefcaseValue(0));
            Assert.AreEqual(1, briefcaseManager.GetBriefcaseValue(1));
            Assert.AreEqual(3, briefcaseManager.GetBriefcaseValue(2));
        }
    }
}
