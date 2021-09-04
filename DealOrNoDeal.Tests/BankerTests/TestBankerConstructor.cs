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
        public void ShouldInitializeDefaultValues()
        {
            Banker banker = new Banker();
            Assert.AreEqual(0, banker.CurrentOffer);
            Assert.AreEqual(0, banker.AverageOffer);
            Assert.AreEqual(int.MaxValue, banker.MinimumOffer);
            Assert.AreEqual(int.MinValue, banker.MaximumOffer);
        }
        
    }
}
