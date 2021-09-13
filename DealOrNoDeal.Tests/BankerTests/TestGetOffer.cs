using System.Collections.Generic;
using DealOrNoDeal.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DealOrNoDeal.Tests.BankerTests
{
    [TestClass]
    public class TestGetOffer
    {
        [TestMethod]
        public void ShouldGetOfferFromListWithManyItemsAndManyRounds()
        {
            var manager = new GameManager(new List<int> { 3, 2, 1 }, new List<int> { 1000, 2000, 3000, 4000, 5000, 6000 });
            Assert.AreEqual(1750, manager.GetOffer());
        }
    }
}
