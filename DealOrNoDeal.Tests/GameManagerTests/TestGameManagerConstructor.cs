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
            Assert.AreEqual(0, gameManager.BankerCurrentOffer);
            Assert.AreEqual(int.MaxValue, gameManager.BankerMinimumOffer);
            Assert.AreEqual(int.MinValue, gameManager.BankerMaximumOffer);
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

        [TestMethod]
        public void ShouldNotSetTheBankerCurrentOfferToOneBelowMinimumValue()
        {
            var gameManager = new GameManager();
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                gameManager.BankerCurrentOffer = -1;
            });

            Assert.AreEqual(GameManagerErrorMessages.ShouldNotSetBankerCurrentOfferToLessThanZero, message.Message);
        }

        [TestMethod]
        public void ShouldNotSetTheBankerCurrentOfferToWellBelowMinimumValue()
        {
            var gameManager = new GameManager();
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                gameManager.BankerCurrentOffer = -100;
            });

            Assert.AreEqual(GameManagerErrorMessages.ShouldNotSetBankerCurrentOfferToLessThanZero, message.Message);
        }

        [TestMethod]
        public void ShouldSetTheBankerCurrentOfferToMinimumValue()
        {
            var gameManager = new GameManager
            {
                BankerCurrentOffer = 100
            };
            Assert.AreEqual(100, gameManager.BankerCurrentOffer);
            gameManager.BankerCurrentOffer = 0;
            Assert.AreEqual(0, gameManager.BankerCurrentOffer);
        }

        [TestMethod]
        public void ShouldSetTheBankerCurrentOfferToOneAboveMinimumValue()
        {
            var gameManager = new GameManager();
            Assert.AreEqual(0, gameManager.BankerCurrentOffer);
            gameManager.BankerCurrentOffer = 1;
            Assert.AreEqual(1, gameManager.BankerCurrentOffer);
        }

        [TestMethod]
        public void ShouldSetTheBankerCurrentOfferToWellAboveMinimumValue()
        {
            var gameManager = new GameManager();
            Assert.AreEqual(0, gameManager.BankerCurrentOffer);
            gameManager.BankerCurrentOffer = 100;
            Assert.AreEqual(100, gameManager.BankerCurrentOffer);
        }


        [TestMethod]
        public void ShouldNotSetBankerMinimumOfferToOneBelowMinimumValue()
        {
            var gameManager = new GameManager();
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                gameManager.BankerMinimumOffer = -1;
            });

            Assert.AreEqual(GameManagerErrorMessages.ShouldNotSetBankerMinimumOfferToLessThanZero, message.Message);
        }

        [TestMethod]
        public void ShouldNotSetBankerMinimumOfferToWellBelowMinimumValue()
        {
            var gameManager = new GameManager();

            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                gameManager.BankerMinimumOffer = -100;
            });

            Assert.AreEqual(GameManagerErrorMessages.ShouldNotSetBankerMinimumOfferToLessThanZero, message.Message);
        }

        [TestMethod]
        public void ShouldNotSetBankerMinimumOfferToOneAboveMaximumOffer()
        {
            var gameManager = new GameManager
            {
                BankerMaximumOffer = 100
            };

            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                gameManager.BankerMinimumOffer = 101;
            });

            Assert.AreEqual(GameManagerErrorMessages.ShouldNotSetBankerMinimumOfferToMoreThanMaximumOffer, message.Message);
        }

        [TestMethod]
        public void ShouldNotSetBankerMinimumOfferToWellAboveMaximumOffer()
        {
            var gameManager = new GameManager
            {
                BankerMaximumOffer = 100
            };

            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                gameManager.BankerMinimumOffer = 200;
            });

            Assert.AreEqual(GameManagerErrorMessages.ShouldNotSetBankerMinimumOfferToMoreThanMaximumOffer, message.Message);
        }

        [TestMethod]
        public void ShouldSetBankerMinimumOfferToMinimumValue()
        {
            var gameManager = new GameManager();
            Assert.AreEqual(int.MaxValue, gameManager.BankerMinimumOffer);
            gameManager.BankerMinimumOffer = 0;
            Assert.AreEqual(0, gameManager.BankerMinimumOffer);
        }

        [TestMethod]
        public void ShouldSetBankerMinimumOfferToOneAboveMinimumValue()
        {
            var gameManager = new GameManager();
            Assert.AreEqual(int.MaxValue, gameManager.BankerMinimumOffer);
            gameManager.BankerMinimumOffer = 1;
            Assert.AreEqual(1, gameManager.BankerMinimumOffer);
        }

        [TestMethod]
        public void ShouldSetBankerMinimumOfferToWellAboveMinimumValue()
        {
            var gameManager = new GameManager();
            Assert.AreEqual(int.MaxValue, gameManager.BankerMinimumOffer);
            gameManager.BankerMinimumOffer = 100;
            Assert.AreEqual(100, gameManager.BankerMinimumOffer);
        }

        [TestMethod]
        public void ShouldSetBankerMinimumOfferToEqualMaximumOffer()
        {
            var gameManager = new GameManager();
            Assert.AreEqual(int.MaxValue, gameManager.BankerMinimumOffer);
            gameManager.BankerMaximumOffer = 100;
            gameManager.BankerMinimumOffer = 100;
            Assert.AreEqual(100, gameManager.BankerMinimumOffer);
            Assert.AreEqual(100, gameManager.BankerMaximumOffer);
        }

        [TestMethod]
        public void ShouldSetBankerMinimumOfferToOneBelowMaximumOffer()
        {
            var gameManager = new GameManager();
            Assert.AreEqual(int.MaxValue, gameManager.BankerMinimumOffer);
            gameManager.BankerMaximumOffer = 100;
            gameManager.BankerMinimumOffer = 99;
            Assert.AreEqual(99, gameManager.BankerMinimumOffer);
            Assert.AreEqual(100, gameManager.BankerMaximumOffer);
        }

        [TestMethod]
        public void ShouldSetBankerMinimumOfferToWellBelowMaximumOffer()
        {
            var gameManager = new GameManager();
            Assert.AreEqual(int.MaxValue, gameManager.BankerMinimumOffer);
            gameManager.BankerMaximumOffer = 100;
            gameManager.BankerMinimumOffer = 50;
            Assert.AreEqual(50, gameManager.BankerMinimumOffer);
            Assert.AreEqual(100, gameManager.BankerMaximumOffer);
        }


        [TestMethod]
        public void ShouldNotSetBankerMaximumOfferOneBelowMinimumValue()
        {
            var gameManager = new GameManager();
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                gameManager.BankerMaximumOffer = -1;
            });

            Assert.AreEqual(GameManagerErrorMessages.ShouldNotSetBankerMaximumOfferToLessThanZero, message.Message);
        }

        [TestMethod]
        public void ShouldNotSetBankerMaximumOfferWellBelowMinimumValue()
        {
            var gameManager = new GameManager();
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                gameManager.BankerMaximumOffer = -100;
            });

            Assert.AreEqual(GameManagerErrorMessages.ShouldNotSetBankerMaximumOfferToLessThanZero, message.Message);
        }

        [TestMethod]
        public void ShouldNotSetBankerMaximumValueToOneBelowBankerMinimumValue()
        {
            var gameManager = new GameManager
            {
                BankerMinimumOffer = 100
            };

            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                gameManager.BankerMaximumOffer = 99;
            });

            Assert.AreEqual(GameManagerErrorMessages.ShouldNotSetBankerMaximumOfferToLessThanMinimumOffer, message.Message);
        }

        [TestMethod]
        public void ShouldNotSetBankerMaximumValueToWellBelowBankerMinimumValue()
        {
            var gameManager = new GameManager
            {
                BankerMinimumOffer = 100
            };

            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                gameManager.BankerMaximumOffer = 50;
            });

            Assert.AreEqual(GameManagerErrorMessages.ShouldNotSetBankerMaximumOfferToLessThanMinimumOffer, message.Message);
        }

        [TestMethod]
        public void ShouldSetBankerMaximumOfferToMinimumValue()
        {
            var gameManager = new GameManager();
            Assert.AreEqual(int.MinValue, gameManager.BankerMaximumOffer);
            gameManager.BankerMaximumOffer = 0;
            Assert.AreEqual(0, gameManager.BankerMaximumOffer);
        }

        [TestMethod]
        public void ShouldSetBankerMaximumOfferToOneAboveMinimumValue()
        {
            var gameManager = new GameManager();
            Assert.AreEqual(int.MinValue, gameManager.BankerMaximumOffer);
            gameManager.BankerMaximumOffer = 1;
            Assert.AreEqual(1, gameManager.BankerMaximumOffer);
        }

        [TestMethod]
        public void ShouldSetBankerMaximumOfferToWellAboveMinimumValue()
        {
            var gameManager = new GameManager();
            Assert.AreEqual(int.MinValue, gameManager.BankerMaximumOffer);
            gameManager.BankerMaximumOffer = 100;
            Assert.AreEqual(100, gameManager.BankerMaximumOffer);
        }

        [TestMethod]
        public void ShouldSetBankerMaximumOfferToEqualMinimumOffer()
        {
            var gameManager = new GameManager();
            Assert.AreEqual(int.MaxValue, gameManager.BankerMinimumOffer);
            gameManager.BankerMinimumOffer = 100;
            gameManager.BankerMaximumOffer = 100;
            Assert.AreEqual(100, gameManager.BankerMinimumOffer);
            Assert.AreEqual(100, gameManager.BankerMaximumOffer);
        }

        [TestMethod]
        public void ShouldSetBankerMaximumOfferToOneAboveMinimumOffer()
        {
            var gameManager = new GameManager();
            Assert.AreEqual(int.MaxValue, gameManager.BankerMinimumOffer);
            gameManager.BankerMinimumOffer = 100;
            gameManager.BankerMaximumOffer = 101;
            Assert.AreEqual(100, gameManager.BankerMinimumOffer);
            Assert.AreEqual(101, gameManager.BankerMaximumOffer);
        }

        [TestMethod]
        public void ShouldSetBankerMaximumOfferToWellAboveMinimumOffer()
        {
            var gameManager = new GameManager();
            Assert.AreEqual(int.MaxValue, gameManager.BankerMinimumOffer);
            gameManager.BankerMinimumOffer = 100;
            gameManager.BankerMaximumOffer = 200;
            Assert.AreEqual(100, gameManager.BankerMinimumOffer);
            Assert.AreEqual(200, gameManager.BankerMaximumOffer);
        }
    }
}
