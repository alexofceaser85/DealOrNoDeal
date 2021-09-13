using System;
using System.Collections.Generic;
using DealOrNoDeal.ErrorMessages;
using DealOrNoDeal.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DealOrNoDeal.Tests.BankerTests
{
    [TestClass]
    public class TestCalculateBankerOffer
    {
        [TestMethod]
        public void ShouldNotCalculateOfferForNullList()
        {
            var banker = new Banker();
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                banker.CalculateOffers(null, 10);
            }).Message;

            Assert.AreEqual(message, BankerErrorMessages.CannotCalculateBankerOfferIfBriefcasesStillInPlayAreNull);
        }

        [TestMethod]
        public void ShouldNotCalculateOfferForEmptyList()
        {
            var banker = new Banker();
            IList<Briefcase> briefcases = new List<Briefcase>();
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                banker.CalculateOffers(briefcases, 0);
            }).Message;

            Assert.AreEqual(message, BankerErrorMessages.CannotCalculateBankerOfferIfBriefcasesStillInPlayAreEmpty);
        }

        [TestMethod]
        public void ShouldNotCalculateOfferIfNumberOfCasesForNextRoundIsZero()
        {
            var banker = new Banker();
            IList<Briefcase> briefcases = new List<Briefcase>();
            briefcases.Add(new Briefcase(1, 100));
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                banker.CalculateOffers(briefcases, 0);
            }).Message;

            Assert.AreEqual(message, BankerErrorMessages.CannotCalculateBankerOfferIfNumberOfCasesToOpenIsLessThanOrEqualToZero);
        }

        [TestMethod]
        public void ShouldNotCalculateOfferIfNumberOfCasesForNextRoundIsOneLessThanZero()
        {
            var banker = new Banker();
            IList<Briefcase> briefcases = new List<Briefcase>();
            briefcases.Add(new Briefcase(1, 100));
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                banker.CalculateOffers(briefcases, -1);
            }).Message;

            Assert.AreEqual(message, BankerErrorMessages.CannotCalculateBankerOfferIfNumberOfCasesToOpenIsLessThanOrEqualToZero);
        }

        [TestMethod]
        public void ShouldNotCalculateOfferIfNumberOfCasesForNextRoundIsWellLessThanZero()
        {
            var banker = new Banker();
            var briefcases = new List<Briefcase> { new Briefcase(1, 100) };
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                banker.CalculateOffers(briefcases, -100);
            }).Message;

            Assert.AreEqual(message, BankerErrorMessages.CannotCalculateBankerOfferIfNumberOfCasesToOpenIsLessThanOrEqualToZero);
        }

        [TestMethod]
        public void ShouldCalculateOfferForListOfOneItemAndOneNumberOfCaseToOpenInNextRound()
        {
            var banker = new Banker();
            var briefcases = new List<Briefcase>
            {
                new Briefcase(0, 100)
            };

            Assert.AreEqual(100, banker.CalculateOffers(briefcases, 1));
        }

        [TestMethod]
        public void ShouldCalculateOfferBasedOnDataForStartOfFirstRound()
        {
            var banker = new Banker();
            var briefcases = returnFullyPopulatedBriefcases();

            Assert.AreEqual(131477, banker.CalculateOffers(briefcases, 1));
        }

        [TestMethod]
        public void ShouldCalculateOfferBasedOnDataForEndOfFirstRound()
        {
            var banker = new Banker();
            var briefcases = returnFullyPopulatedBriefcases();
            briefcases.RemoveAt(2);
            briefcases.RemoveAt(5);
            briefcases.RemoveAt(10);
            briefcases.RemoveAt(13);
            briefcases.RemoveAt(19);
            briefcases.RemoveAt(20);

            Assert.AreEqual(18925, banker.CalculateOffers(briefcases, 5));
        }

        [TestMethod]
        public void ShouldCalculateOfferBasedOnDataForEndOfFifthRound()
        {
            var banker = new Banker();
            var briefcases = returnBriefcasesBasedOnDataForFifthRound();

            Assert.AreEqual(12766, banker.CalculateOffers(briefcases, 1));
        }

        private static IList<Briefcase> returnBriefcasesBasedOnDataForFifthRound()
        {
            var briefcases = new List<Briefcase>
            {
                new Briefcase(0, 0),
                new Briefcase(1, 100),
                new Briefcase(2, 500),
                new Briefcase(3, 1000),
                new Briefcase(4, 25000),
                new Briefcase(5, 50000)
            };

            return briefcases;
        }

        private static IList<Briefcase> returnFullyPopulatedBriefcases()
        {
            var briefcases = new List<Briefcase>
            {
                new Briefcase(0, 0),
                new Briefcase(1, 1),
                new Briefcase(2, 5),
                new Briefcase(3, 10),
                new Briefcase(4, 25),
                new Briefcase(5, 50),
                new Briefcase(6, 75),
                new Briefcase(7, 100),
                new Briefcase(8, 200),
                new Briefcase(9, 300),
                new Briefcase(10, 400),
                new Briefcase(11, 500),
                new Briefcase(12, 750),
                new Briefcase(13, 1000),
                new Briefcase(14, 5000),
                new Briefcase(15, 10000),
                new Briefcase(16, 25000),
                new Briefcase(17, 50000),
                new Briefcase(18, 75000),
                new Briefcase(19, 100000),
                new Briefcase(20, 200000),
                new Briefcase(21, 300000),
                new Briefcase(22, 400000),
                new Briefcase(23, 500000),
                new Briefcase(24, 750000),
                new Briefcase(25, 1000000)
            };

            return briefcases;
        }

        [TestMethod]
        public void ShouldCalculateOfferBasedOnDataForFinalRound()
        {
            var banker = new Banker();
            var briefcases = new List<Briefcase>
            {
                new Briefcase(0, 1000),
                new Briefcase(1, 10000)
            };

            Assert.AreEqual(5500, banker.CalculateOffers(briefcases, 1));
        }

        [TestMethod]
        public void ShouldCalculateIfOnlyBriefcaseHasAValueOfZero()
        {
            var banker = new Banker();
            var briefcases = new List<Briefcase>
            {
                new Briefcase(0, 0)
            };

            Assert.AreEqual(0, banker.CalculateOffers(briefcases, 1));
        }

        [TestMethod]
        public void ShouldUpdateMaximumAndMinimumAndAverageOffersForOneData()
        {
            var banker = new Banker();
            var briefcases = returnFullyPopulatedBriefcases();

            Assert.AreEqual(131477, banker.CalculateOffers(briefcases, 1));

            Assert.AreEqual(131477, banker.MaximumOffer);
            Assert.AreEqual(131477, banker.MinimumOffer);
            Assert.AreEqual(131477, banker.AverageOffer);
        }

        [TestMethod]
        public void ShouldUpdateMaximumAndMinimumAndAverageOffersForManyData()
        {
            var banker = new Banker();
            var briefcases = returnFullyPopulatedBriefcases();

            Assert.AreEqual(131477, banker.CalculateOffers(briefcases, 1));
            Assert.AreEqual(21912, banker.CalculateOffers(briefcases, 6));
            Assert.AreEqual(10956, banker.CalculateOffers(briefcases, 12));

            Assert.AreEqual(131477, banker.MaximumOffer);
            Assert.AreEqual(10956, banker.MinimumOffer);
            Assert.AreEqual(54781, banker.AverageOffer);
        }
    }
}
