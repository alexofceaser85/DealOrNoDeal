using System;
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
            var gameManager = new GameManager();
            Assert.AreEqual(true, gameManager.IsSelectingStartingCase);
            Assert.AreEqual(1, gameManager.CurrentRound);
            Assert.AreEqual(6, gameManager.CasesAvailableForCurrentRound);
            Assert.AreEqual(6, gameManager.CasesLeftForCurrentRound);
            Assert.AreEqual(-1, gameManager.PlayerSelectedStartingCase);
        }

        [TestMethod]
        public void ShouldNotSetCurrentRoundToOneLessThanMinimum()
        {
            var gameManager = new GameManager();
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                gameManager.CurrentRound = 0;
            });

            Assert.AreEqual(GameManagerErrorMessages.ShouldNotSetCurrentRoundToLessThanOne, message.Message);
        }

        [TestMethod]
        public void ShouldNotSetCurrentRoundToWellLessThanMinimum()
        {
            var gameManager = new GameManager();
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                gameManager.CurrentRound = -100;
            });

            Assert.AreEqual(GameManagerErrorMessages.ShouldNotSetCurrentRoundToLessThanOne, message.Message);
        }

        [TestMethod]
        public void ShouldSetCurrentRoundToMinimumValue()
        {
            var gameManager = new GameManager();
            Assert.AreEqual(1, gameManager.CurrentRound);
            gameManager.CurrentRound = 1;
            Assert.AreEqual(1, gameManager.CurrentRound);
        }

        [TestMethod]
        public void ShouldSetCurrentRoundOneAboveMinimumValue()
        {
            var gameManager = new GameManager();
            Assert.AreEqual(1, gameManager.CurrentRound);
            gameManager.CurrentRound = 2;
            Assert.AreEqual(2, gameManager.CurrentRound);
        }

        [TestMethod]
        public void ShouldSetCurrentRoundWellAboveMinimumValue()
        {
            var gameManager = new GameManager();
            Assert.AreEqual(1, gameManager.CurrentRound);
            gameManager.CurrentRound = 1000;
            Assert.AreEqual(1000, gameManager.CurrentRound);
        }


        [TestMethod]
        public void ShouldNotSetTheCasesLeftForCurrentRoundOneLessThanMinimum()
        {
            var gameManager = new GameManager();
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                gameManager.CasesLeftForCurrentRound = -1;
            });

            Assert.AreEqual(GameManagerErrorMessages.ShouldNotSetCasesLeftForCurrentRoundToLessThanZero, message.Message);
        }

        [TestMethod]
        public void ShouldNotSetTheCasesLeftForCurrentRoundWellLessThanMinimum()
        {
            var gameManager = new GameManager();
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                gameManager.CasesLeftForCurrentRound = -100;
            });

            Assert.AreEqual(GameManagerErrorMessages.ShouldNotSetCasesLeftForCurrentRoundToLessThanZero, message.Message);
        }

        [TestMethod]
        public void ShouldSetTheCasesLeftToMinimumValue()
        {
            var gameManager = new GameManager();
            Assert.AreEqual(6, gameManager.CasesLeftForCurrentRound);
            gameManager.CasesLeftForCurrentRound = 0;
            Assert.AreEqual(0, gameManager.CasesLeftForCurrentRound);
        }

        [TestMethod]
        public void ShouldSetTheCasesLeftToOneAboveMinimumValue()
        {
            var gameManager = new GameManager();
            Assert.AreEqual(6, gameManager.CasesLeftForCurrentRound);
            gameManager.CasesLeftForCurrentRound = 1;
            Assert.AreEqual(1, gameManager.CasesLeftForCurrentRound);
        }

        [TestMethod]
        public void ShouldSetTheCasesLeftToWellAboveMinimumValue()
        {
            var gameManager = new GameManager();
            Assert.AreEqual(6, gameManager.CasesLeftForCurrentRound);
            gameManager.CasesLeftForCurrentRound = 1000;
            Assert.AreEqual(1000, gameManager.CasesLeftForCurrentRound);
        }


        [TestMethod]
        public void ShouldNotSetThePlayerSelectedStartingCaseToOneLessThanMinimum()
        {
            var gameManager = new GameManager();
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                gameManager.PlayerSelectedStartingCase = -2;
            });

            Assert.AreEqual(GameManagerErrorMessages.ShouldNotSetPlaySelectedStartingCaseToLessThanNegativeOne, message.Message);
        }

        [TestMethod]
        public void ShouldNotSetThePlayerSelectedStartingCaseToWellLessThanMinimum()
        {
            var gameManager = new GameManager();
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                gameManager.PlayerSelectedStartingCase = -100;
            });

            Assert.AreEqual(GameManagerErrorMessages.ShouldNotSetPlaySelectedStartingCaseToLessThanNegativeOne, message.Message);
        }

        [TestMethod]
        public void ShouldSetThePlayerSelectedStartingCaseToMinimumValue()
        {
            var gameManager = new GameManager
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
            var gameManager = new GameManager();
            Assert.AreEqual(-1, gameManager.PlayerSelectedStartingCase);
            gameManager.PlayerSelectedStartingCase = 2;
            Assert.AreEqual(2, gameManager.PlayerSelectedStartingCase);
        }

        [TestMethod]
        public void ShouldSetThePlayerSelectedStartingCaseToWellAboveMinimumValue()
        {
            var gameManager = new GameManager();
            Assert.AreEqual(-1, gameManager.PlayerSelectedStartingCase);
            gameManager.PlayerSelectedStartingCase = 100;
            Assert.AreEqual(100, gameManager.PlayerSelectedStartingCase);
        }
    }
}
