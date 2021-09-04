using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DealOrNoDeal.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DealOrNoDeal.Tests.BankerTests
{
    [TestClass]
    public class TestGetOffer
    {
        [TestMethod]
        public void ShouldGetOfferFromEmptyList()
        {
            var manager = new GameManager(new List<int>(), new List<int>());
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                manager.GetOffer();
            }).Message;

            Assert.AreEqual(message, ErrorMessages.BankerErrorMessages.CannotCalculateBankerOfferIfNumberOfCasesToOpenIsLessThanOrEqualToZero);
        }

        [TestMethod]
        public void ShouldGetOfferFromListWithOneItemAndOneRound()
        {
            var manager = new GameManager(new List<int>() {1}, new List<int>() {10});
            var message = Assert.ThrowsException<ArgumentException>(() =>
            {
                manager.GetOffer();
            }).Message;

            Assert.AreEqual(message, ErrorMessages.BankerErrorMessages.CannotCalculateBankerOfferIfNumberOfCasesToOpenIsLessThanOrEqualToZero);
        }

        [TestMethod]
        public void ShouldGetOfferFromListWithManyItemsAndManyRounds()
        {
            var manager = new GameManager(new List<int>() { 3, 2, 1 }, new List<int>() { 1000, 2000, 3000, 4000, 5000, 6000 });
            Assert.AreEqual(1800, manager.GetOffer());
        }
    }
}
