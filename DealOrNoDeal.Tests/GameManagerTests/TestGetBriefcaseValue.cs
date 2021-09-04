using System.Collections.Generic;
using DealOrNoDeal.Data;
using DealOrNoDeal.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DealOrNoDeal.Tests.GameManagerTests
{
    [TestClass]
    public class TestGetBriefcaseValue
    {
        [TestMethod]
        public void ShouldNotGetValueFromEmptyBriefcaseManager()
        {
            GameManager manager = new GameManager(new List<int>(), new List<int>());

            Assert.AreEqual(-1, manager.GetBriefcaseValue(0));
        }

        [TestMethod]
        public void ShouldGetOnlyItemInList()
        {
            GameManager manager = new GameManager(new List<int>() { 1 }, new List<int>() { 10 });

            Assert.AreEqual(10, manager.GetBriefcaseValue(0));
        }

        [TestMethod]
        public void ShouldNotGetItemThatIsNotPresentInOneItem()
        {
            GameManager manager = new GameManager(new List<int>() { 1 }, new List<int>() { 10 });

            Assert.AreEqual(-1, manager.GetBriefcaseValue(1));
        }

        [TestMethod]
        public void ShouldNotGetItemThatIsNotPresentInManyItems()
        {
            GameManager manager = new GameManager(new List<int>() { 3, 2, 1 }, new List<int>() { 10, 20, 30 });

            Assert.AreEqual(-1, manager.GetBriefcaseValue(4));
        }

        [TestMethod]
        public void ShouldGetFirstItem()
        {
            GameManager manager = new GameManager(new List<int>() { 3, 2, 1 }, new List<int>() { 10, 20, 30 });

            Assert.AreNotEqual(-1, manager.GetBriefcaseValue(0));
        }

        [TestMethod]
        public void ShouldGetMiddleItem()
        {
            GameManager manager = new GameManager(new List<int>() { 3, 2, 1 }, new List<int>() { 10, 20, 30 });

            Assert.AreNotEqual(-1, manager.GetBriefcaseValue(1));
        }

        [TestMethod]
        public void ShouldGetLastItem()
        {
            GameManager manager = new GameManager(new List<int>() { 3, 2, 1 }, new List<int>() { 10, 20, 30 });

            Assert.AreNotEqual(-1, manager.GetBriefcaseValue(0));
        }
    }
}
