﻿using System;
using System.Collections;
using System.Collections.Generic;
using DealOrNoDeal.ErrorMessages;
using DealOrNoDeal.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DealOrNoDeal.Tests.BankerTests
{
    [TestClass]
    public class CalculateBankerOfferTests
    {
        [TestMethod]
        public void ShouldNotCalculateOfferForNullList()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = Banker.CalculateBankerOffer(null, 10);
            }).Message;

            Assert.AreEqual(message, BankerErrorMessages.CannotCalculateBankerOfferIfBriefcasesStillInPlayAreNull);
        }

        [TestMethod]
        public void ShouldNotCalculateOfferForEmptyList()
        {
            IList<Briefcase> briefcases = new List<Briefcase>();
            Assert.AreEqual(0, Banker.CalculateBankerOffer(briefcases, 10));
        }

        [TestMethod]
        public void ShouldNotCalculateOfferIfNumberOfCasesForNextRoundIsZero()
        {
            IList<Briefcase> briefcases = new List<Briefcase>();
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = Banker.CalculateBankerOffer(briefcases, 0);
            }).Message;

            Assert.AreEqual(message, BankerErrorMessages.CannotCalculateBankerOfferIfNumberOfCasesToOpenIsLessThanOrEqualToZero);
        }

        [TestMethod]
        public void ShouldNotCalculateOfferIfNumberOfCasesForNextRoundIsOneLessThanZero()
        {
            IList<Briefcase> briefcases = new List<Briefcase>();
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = Banker.CalculateBankerOffer(briefcases, -1);
            }).Message;

            Assert.AreEqual(message, BankerErrorMessages.CannotCalculateBankerOfferIfNumberOfCasesToOpenIsLessThanOrEqualToZero);
        }

        [TestMethod]
        public void ShouldNotCalculateOfferIfNumberOfCasesForNextRoundIsWellLessThanZero()
        {
            IList<Briefcase> briefcases = new List<Briefcase>();
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = Banker.CalculateBankerOffer(briefcases, -100);
            }).Message;

            Assert.AreEqual(message, BankerErrorMessages.CannotCalculateBankerOfferIfNumberOfCasesToOpenIsLessThanOrEqualToZero);
        }

        [TestMethod]
        public void ShouldCalculateOfferForListOfOneItemAndOneNumberOfCaseToOpenInNextRound()
        {
            IList<Briefcase> briefcases = new List<Briefcase>();
            briefcases.Add(new Briefcase(0, 100));

            Assert.AreEqual(100, Banker.CalculateBankerOffer(briefcases, 1));
        }

        [TestMethod]
        public void ShouldCalculateOfferBasedOnDataForStartOfFirstRound()
        {
            IList<Briefcase> briefcases = this.returnFullyPopulatedBriefcases();

            Assert.AreEqual(131500, Banker.CalculateBankerOffer(briefcases, 1));
        }

        [TestMethod]
        public void ShouldCalculateOfferBasedOnDataForEndOfFirstRound()
        {
            IList<Briefcase> briefcases = this.returnFullyPopulatedBriefcases();
            briefcases.RemoveAt(2);
            briefcases.RemoveAt(5);
            briefcases.RemoveAt(10);
            briefcases.RemoveAt(13);
            briefcases.RemoveAt(19);
            briefcases.RemoveAt(20);

            Assert.AreEqual(18900, Banker.CalculateBankerOffer(briefcases, 5));
        }

        [TestMethod]
        public void ShouldCalculateOfferBasedOnDataForEndOfFifthRound()
        {
            IList<Briefcase> briefcases = this.returnBriefcasesBasedOnDataForFifthRound();

            Assert.AreEqual(12800, Banker.CalculateBankerOffer(briefcases, 1));
        }

        private IList<Briefcase> returnBriefcasesBasedOnDataForFifthRound()
        {
            IList<Briefcase> briefcases = new List<Briefcase>();
            briefcases.Add(new Briefcase(0, 0));
            briefcases.Add(new Briefcase(1, 100));
            briefcases.Add(new Briefcase(2, 500));
            briefcases.Add(new Briefcase(3, 1000));
            briefcases.Add(new Briefcase(4, 25000));
            briefcases.Add(new Briefcase(5, 50000));

            return briefcases;
        }

        private IList<Briefcase> returnFullyPopulatedBriefcases()
        {
            IList<Briefcase> briefcases = new List<Briefcase>();
            briefcases.Add(new Briefcase(0, 0));
            briefcases.Add(new Briefcase(1, 1));
            briefcases.Add(new Briefcase(2, 5));
            briefcases.Add(new Briefcase(3, 10));
            briefcases.Add(new Briefcase(4, 25));
            briefcases.Add(new Briefcase(5, 50));
            briefcases.Add(new Briefcase(6, 75));
            briefcases.Add(new Briefcase(7, 100));
            briefcases.Add(new Briefcase(8, 200));
            briefcases.Add(new Briefcase(9, 300));
            briefcases.Add(new Briefcase(10, 400));
            briefcases.Add(new Briefcase(11, 500));
            briefcases.Add(new Briefcase(12, 750));
            briefcases.Add(new Briefcase(13, 1000));
            briefcases.Add(new Briefcase(14, 5000));
            briefcases.Add(new Briefcase(15, 10000));
            briefcases.Add(new Briefcase(16, 25000));
            briefcases.Add(new Briefcase(17, 50000));
            briefcases.Add(new Briefcase(18, 75000));
            briefcases.Add(new Briefcase(19, 100000));
            briefcases.Add(new Briefcase(20, 200000));
            briefcases.Add(new Briefcase(21, 300000));
            briefcases.Add(new Briefcase(22, 400000));
            briefcases.Add(new Briefcase(23, 500000));
            briefcases.Add(new Briefcase(24, 750000));
            briefcases.Add(new Briefcase(25, 1000000));

            return briefcases;
        }

        [TestMethod]
        public void ShouldCalculateOfferBasedOnDataForFinalRound()
        {
            IList<Briefcase> briefcases = new List<Briefcase>();
            briefcases.Add(new Briefcase(0, 1000));
            briefcases.Add(new Briefcase(1, 10000));

            Assert.AreEqual(5500, Banker.CalculateBankerOffer(briefcases, 1));
        }

        [TestMethod]
        public void ShouldCalculateIfOnlyBriefcaseHasAValueOfZero()
        {
            IList<Briefcase> briefcases = new List<Briefcase>();
            briefcases.Add(new Briefcase(0, 0));

            Assert.AreEqual(0, Banker.CalculateBankerOffer(briefcases, 1));
        }
    }
}
