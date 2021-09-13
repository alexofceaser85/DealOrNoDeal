using System;
using DealOrNoDeal.Data.Rounds;
using DealOrNoDeal.ErrorMessages;
using DealOrNoDeal.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DealOrNoDeal.Tests.GameManagerTests
{
    [TestClass]
    public class TestGameManagerConstructor
    {
        [TestMethod]
        public void ShouldInitializeDefaultValues()
        {
            var gameManager = new GameManager(CasesToOpenForEachRound.TenRoundCases, DollarValuesForEachRound.Regular);
            Assert.AreEqual(true, gameManager.IsSelectingStartingCase);
            Assert.AreEqual(-1, gameManager.PlayerSelectedStartingCase);
            Assert.IsNotNull(gameManager.RoundManager);
            Assert.IsNotNull(gameManager.Banker);
        }


        [TestMethod]
        public void ShouldNotSetThePlayerSelectedStartingCaseToOneLessThanMinimum()
        {
            var gameManager = new GameManager(CasesToOpenForEachRound.TenRoundCases, DollarValuesForEachRound.Regular);
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                gameManager.PlayerSelectedStartingCase = -2;
            });

            Assert.AreEqual(GameManagerErrorMessages.ShouldNotSetPlaySelectedStartingCaseToLessThanNegativeOne, message.Message);
        }

        [TestMethod]
        public void ShouldNotSetThePlayerSelectedStartingCaseToWellLessThanMinimum()
        {
            var gameManager = new GameManager(CasesToOpenForEachRound.TenRoundCases, DollarValuesForEachRound.Regular);
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                gameManager.PlayerSelectedStartingCase = -100;
            });

            Assert.AreEqual(GameManagerErrorMessages.ShouldNotSetPlaySelectedStartingCaseToLessThanNegativeOne, message.Message);
        }

        [TestMethod]
        public void ShouldSetThePlayerSelectedStartingCaseToMinimumValue()
        {
            var gameManager = new GameManager(CasesToOpenForEachRound.TenRoundCases, DollarValuesForEachRound.Regular)
            {
                PlayerSelectedStartingCase = 5
            };
            Assert.AreEqual(5, gameManager.PlayerSelectedStartingCase);
            gameManager.PlayerSelectedStartingCase = 1;
            Assert.AreEqual(1, gameManager.PlayerSelectedStartingCase);
        }

        [TestMethod]
        public void ShouldSetThePlayerSelectedStartingCaseToOneAboveMinimumValue()
        {
            var gameManager = new GameManager(CasesToOpenForEachRound.TenRoundCases, DollarValuesForEachRound.Regular);
            Assert.AreEqual(-1, gameManager.PlayerSelectedStartingCase);
            gameManager.PlayerSelectedStartingCase = 2;
            Assert.AreEqual(2, gameManager.PlayerSelectedStartingCase);
        }

        [TestMethod]
        public void ShouldSetThePlayerSelectedStartingCaseToWellAboveMinimumValue()
        {
            var gameManager = new GameManager(CasesToOpenForEachRound.TenRoundCases, DollarValuesForEachRound.Regular);
            Assert.AreEqual(-1, gameManager.PlayerSelectedStartingCase);
            gameManager.PlayerSelectedStartingCase = 100;
            Assert.AreEqual(100, gameManager.PlayerSelectedStartingCase);
        }
    }
}
