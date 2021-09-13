using System;
using System.Collections.Generic;
using DealOrNoDeal.Data.Rounds;
using DealOrNoDeal.ErrorMessages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DealOrNoDeal.Tests.RoundManager
{
    [TestClass]
    public class TestRoundManagerConstructor
    {
        [TestMethod]
        public void ShouldNotAllowNullCasesForEachRound()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Model.RoundManager(null);
            }).Message;

            Assert.AreEqual(RoundManagerErrorMessages.ShouldNotAllowNullCasesAvailableForEachRound, message);
        }

        [TestMethod]
        public void ShouldHandleEmptyList()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Model.RoundManager(new List<int>());
            }).Message;

            Assert.AreEqual(RoundManagerErrorMessages.ShouldNotAllowEmptyCasesAvailableForEachRound, message);
        }

        [TestMethod]
        public void ShouldHandleListOfOneItem()
        {
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Model.RoundManager(new List<int>(1));
            }).Message;

            Assert.AreEqual(RoundManagerErrorMessages.ShouldNotAllowEmptyCasesAvailableForEachRound, message);
        }

        [TestMethod]
        public void ShouldInitializeDefaultValues()
        {
            var roundManager = new Model.RoundManager(CasesToOpenForEachRound.TenRoundCases);
            Assert.AreEqual(5, roundManager.CasesAvailableForNextRound);
            Assert.AreEqual(1, roundManager.CurrentRound);
            Assert.AreEqual(6, roundManager.CasesAvailableForCurrentRound);
            Assert.AreEqual(6, roundManager.CasesLeftForCurrentRound);
        }

        [TestMethod]
        public void ShouldNotSetCurrentRoundToOneLessThanMinimum()
        {
            var roundManager = new Model.RoundManager(CasesToOpenForEachRound.TenRoundCases);
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                roundManager.CurrentRound = 0;
            });

            Assert.AreEqual(RoundManagerErrorMessages.ShouldNotSetCurrentRoundToLessThanOne, message.Message);
        }

        [TestMethod]
        public void ShouldNotSetCurrentRoundToWellLessThanMinimum()
        {
            var roundManager = new Model.RoundManager(CasesToOpenForEachRound.TenRoundCases);
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                roundManager.CurrentRound = -100;
            });

            Assert.AreEqual(RoundManagerErrorMessages.ShouldNotSetCurrentRoundToLessThanOne, message.Message);
        }

        [TestMethod]
        public void ShouldSetCurrentRoundToMinimumValue()
        {
            var roundManager = new Model.RoundManager(CasesToOpenForEachRound.TenRoundCases);
            Assert.AreEqual(1, roundManager.CurrentRound);
            roundManager.CurrentRound = 1;
            Assert.AreEqual(1, roundManager.CurrentRound);
        }

        [TestMethod]
        public void ShouldSetCurrentRoundOneAboveMinimumValue()
        {
            var roundManager = new Model.RoundManager(CasesToOpenForEachRound.TenRoundCases);
            Assert.AreEqual(1, roundManager.CurrentRound);
            roundManager.CurrentRound = 2;
            Assert.AreEqual(2, roundManager.CurrentRound);
        }

        [TestMethod]
        public void ShouldSetCurrentRoundWellAboveMinimumValue()
        {
            var roundManager = new Model.RoundManager(CasesToOpenForEachRound.TenRoundCases);
            Assert.AreEqual(1, roundManager.CurrentRound);
            roundManager.CurrentRound = 1000;
            Assert.AreEqual(1000, roundManager.CurrentRound);
        }


        [TestMethod]
        public void ShouldNotSetTheCasesLeftForCurrentRoundOneLessThanMinimum()
        {
            var roundManager = new Model.RoundManager(CasesToOpenForEachRound.TenRoundCases);
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                roundManager.CasesLeftForCurrentRound = -1;
            });

            Assert.AreEqual(RoundManagerErrorMessages.ShouldNotSetCasesLeftForCurrentRoundToLessThanZero, message.Message);
        }

        [TestMethod]
        public void ShouldNotSetTheCasesLeftForCurrentRoundWellLessThanMinimum()
        {
            var roundManager = new Model.RoundManager(CasesToOpenForEachRound.TenRoundCases);
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                roundManager.CasesLeftForCurrentRound = -100;
            });

            Assert.AreEqual(RoundManagerErrorMessages.ShouldNotSetCasesLeftForCurrentRoundToLessThanZero, message.Message);
        }

        [TestMethod]
        public void ShouldSetTheCasesLeftToMinimumValue()
        {
            var roundManager = new Model.RoundManager(CasesToOpenForEachRound.TenRoundCases);
            Assert.AreEqual(6, roundManager.CasesLeftForCurrentRound);
            roundManager.CasesLeftForCurrentRound = 0;
            Assert.AreEqual(0, roundManager.CasesLeftForCurrentRound);
        }

        [TestMethod]
        public void ShouldSetTheCasesLeftToOneAboveMinimumValue()
        {
            var roundManager = new Model.RoundManager(CasesToOpenForEachRound.TenRoundCases);
            Assert.AreEqual(6, roundManager.CasesLeftForCurrentRound);
            roundManager.CasesLeftForCurrentRound = 1;
            Assert.AreEqual(1, roundManager.CasesLeftForCurrentRound);
        }

        [TestMethod]
        public void ShouldSetTheCasesLeftToWellAboveMinimumValue()
        {
            var roundManager = new Model.RoundManager(CasesToOpenForEachRound.TenRoundCases);
            Assert.AreEqual(6, roundManager.CasesLeftForCurrentRound);
            roundManager.CasesLeftForCurrentRound = 1000;
            Assert.AreEqual(1000, roundManager.CasesLeftForCurrentRound);
        }
    }
}
