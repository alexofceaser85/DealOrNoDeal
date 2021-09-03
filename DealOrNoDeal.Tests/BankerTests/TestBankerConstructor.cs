using System;
using DealOrNoDeal.ErrorMessages;
using DealOrNoDeal.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DealOrNoDeal.Tests.BankerTests
{
    [TestClass]
    public class TestBankerConstructor
    {
        [TestMethod]
        public void ShouldNotSetTheCurrentOfferToOneBelowMinimumValue()
        {
            var banker = new Banker();
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                banker.CurrentOffer = -1;
            });

            Assert.AreEqual(BankerErrorMessages.ShouldNotSetCurrentOfferToLessThanZero, message.Message);
        }

        [TestMethod]
        public void ShouldNotSetTheCurrentOfferToWellBelowMinimumValue()
        {
            var banker = new Banker();
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                banker.CurrentOffer = -100;
            });

            Assert.AreEqual(BankerErrorMessages.ShouldNotSetCurrentOfferToLessThanZero, message.Message);
        }

        [TestMethod]
        public void ShouldSetTheCurrentOfferToMinimumValue()
        {
            var banker = new Banker
            {
                CurrentOffer = 100
            };
            Assert.AreEqual(100, banker.CurrentOffer);
            banker.CurrentOffer = 0;
            Assert.AreEqual(0, banker.CurrentOffer);
        }

        [TestMethod]
        public void ShouldSetTheCurrentOfferToOneAboveMinimumValue()
        {
            var banker = new Banker();
            Assert.AreEqual(0, banker.CurrentOffer);
            banker.CurrentOffer = 1;
            Assert.AreEqual(1, banker.CurrentOffer);
        }

        [TestMethod]
        public void ShouldSetTheCurrentOfferToWellAboveMinimumValue()
        {
            var banker = new Banker();
            Assert.AreEqual(0, banker.CurrentOffer);
            banker.CurrentOffer = 100;
            Assert.AreEqual(100, banker.CurrentOffer);
        }


        [TestMethod]
        public void ShouldNotSetMinimumOfferToOneBelowMinimumValue()
        {
            var banker = new Banker();
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                banker.MinimumOffer = -1;
            });

            Assert.AreEqual(BankerErrorMessages.ShouldNotSetMinimumOfferToLessThanZero, message.Message);
        }

        [TestMethod]
        public void ShouldNotSetMinimumOfferToWellBelowMinimumValue()
        {
            var banker = new Banker();

            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                banker.MinimumOffer = -100;
            });

            Assert.AreEqual(BankerErrorMessages.ShouldNotSetMinimumOfferToLessThanZero, message.Message);
        }

        [TestMethod]
        public void ShouldNotSetMinimumOfferToOneAboveMaximumOffer()
        {
            var banker = new Banker
            {
                MaximumOffer = 100
            };

            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                banker.MinimumOffer = 101;
            });

            Assert.AreEqual(BankerErrorMessages.ShouldNotSetMinimumOfferToMoreThanMaximumOffer, message.Message);
        }

        [TestMethod]
        public void ShouldNotSetMinimumOfferToWellAboveMaximumOffer()
        {
            var banker = new Banker
            {
                MaximumOffer = 100
            };

            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                banker.MinimumOffer = 200;
            });

            Assert.AreEqual(BankerErrorMessages.ShouldNotSetMinimumOfferToMoreThanMaximumOffer, message.Message);
        }

        [TestMethod]
        public void ShouldSetMinimumOfferToMinimumValue()
        {
            var banker = new Banker();
            Assert.AreEqual(int.MaxValue, banker.MinimumOffer);
            banker.MinimumOffer = 0;
            Assert.AreEqual(0, banker.MinimumOffer);
        }

        [TestMethod]
        public void ShouldSetMinimumOfferToOneAboveMinimumValue()
        {
            var banker = new Banker();
            Assert.AreEqual(int.MaxValue, banker.MinimumOffer);
            banker.MinimumOffer = 1;
            Assert.AreEqual(1, banker.MinimumOffer);
        }

        [TestMethod]
        public void ShouldSetMinimumOfferToWellAboveMinimumValue()
        {
            var banker = new Banker();
            Assert.AreEqual(int.MaxValue, banker.MinimumOffer);
            banker.MinimumOffer = 100;
            Assert.AreEqual(100, banker.MinimumOffer);
        }

        [TestMethod]
        public void ShouldSetMinimumOfferToEqualMaximumOffer()
        {
            var banker = new Banker();
            Assert.AreEqual(int.MaxValue, banker.MinimumOffer);
            banker.MaximumOffer = 100;
            banker.MinimumOffer = 100;
            Assert.AreEqual(100, banker.MinimumOffer);
            Assert.AreEqual(100, banker.MaximumOffer);
        }

        [TestMethod]
        public void ShouldSetMinimumOfferToOneBelowMaximumOffer()
        {
            var banker = new Banker();
            Assert.AreEqual(int.MaxValue, banker.MinimumOffer);
            banker.MaximumOffer = 100;
            banker.MinimumOffer = 99;
            Assert.AreEqual(99, banker.MinimumOffer);
            Assert.AreEqual(100, banker.MaximumOffer);
        }

        [TestMethod]
        public void ShouldSetMinimumOfferToWellBelowMaximumOffer()
        {
            var banker = new Banker();
            Assert.AreEqual(int.MaxValue, banker.MinimumOffer);
            banker.MaximumOffer = 100;
            banker.MinimumOffer = 50;
            Assert.AreEqual(50, banker.MinimumOffer);
            Assert.AreEqual(100, banker.MaximumOffer);
        }


        [TestMethod]
        public void ShouldNotSetMaximumOfferOneBelowMinimumValue()
        {
            var banker = new Banker();
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                banker.MaximumOffer = -1;
            });

            Assert.AreEqual(BankerErrorMessages.ShouldNotSetMaximumOfferToLessThanZero, message.Message);
        }

        [TestMethod]
        public void ShouldNotSetMaximumOfferWellBelowMinimumValue()
        {
            var banker = new Banker();
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                banker.MaximumOffer = -100;
            });

            Assert.AreEqual(BankerErrorMessages.ShouldNotSetMaximumOfferToLessThanZero, message.Message);
        }

        [TestMethod]
        public void ShouldNotSetBankerMaximumValueToOneBelowBankerMinimumValue()
        {
            var banker = new Banker
            {
                MinimumOffer = 100
            };

            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                banker.MaximumOffer = 99;
            });

            Assert.AreEqual(BankerErrorMessages.ShouldNotSetMaximumOfferToLessThanMinimumOffer, message.Message);
        }

        [TestMethod]
        public void ShouldNotSetBankerMaximumValueToWellBelowBankerMinimumValue()
        {
            var banker = new Banker
            {
                MinimumOffer = 100
            };

            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                banker.MaximumOffer = 50;
            });

            Assert.AreEqual(BankerErrorMessages.ShouldNotSetMaximumOfferToLessThanMinimumOffer, message.Message);
        }

        [TestMethod]
        public void ShouldSetMaximumOfferToMinimumValue()
        {
            var banker = new Banker();
            Assert.AreEqual(int.MinValue, banker.MaximumOffer);
            banker.MaximumOffer = 0;
            Assert.AreEqual(0, banker.MaximumOffer);
        }

        [TestMethod]
        public void ShouldSetMaximumOfferToOneAboveMinimumValue()
        {
            var banker = new Banker();
            Assert.AreEqual(int.MinValue, banker.MaximumOffer);
            banker.MaximumOffer = 1;
            Assert.AreEqual(1, banker.MaximumOffer);
        }

        [TestMethod]
        public void ShouldSetMaximumOfferToWellAboveMinimumValue()
        {
            var banker = new Banker();
            Assert.AreEqual(int.MinValue, banker.MaximumOffer);
            banker.MaximumOffer = 100;
            Assert.AreEqual(100, banker.MaximumOffer);
        }

        [TestMethod]
        public void ShouldSetMaximumOfferToEqualMinimumOffer()
        {
            var banker = new Banker();
            Assert.AreEqual(int.MaxValue, banker.MinimumOffer);
            banker.MinimumOffer = 100;
            banker.MaximumOffer = 100;
            Assert.AreEqual(100, banker.MinimumOffer);
            Assert.AreEqual(100, banker.MaximumOffer);
        }

        [TestMethod]
        public void ShouldSetMaximumOfferToOneAboveMinimumOffer()
        {
            var banker = new Banker();
            Assert.AreEqual(int.MaxValue, banker.MinimumOffer);
            banker.MinimumOffer = 100;
            banker.MaximumOffer = 101;
            Assert.AreEqual(100, banker.MinimumOffer);
            Assert.AreEqual(101, banker.MaximumOffer);
        }

        [TestMethod]
        public void ShouldSetMaximumOfferToWellAboveMinimumOffer()
        {
            var banker = new Banker();
            Assert.AreEqual(int.MaxValue, banker.MinimumOffer);
            banker.MinimumOffer = 100;
            banker.MaximumOffer = 200;
            Assert.AreEqual(100, banker.MinimumOffer);
            Assert.AreEqual(200, banker.MaximumOffer);
        }

    }
}
