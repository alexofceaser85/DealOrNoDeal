using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DealOrNoDeal.Tests.RoundManager
{
    [TestClass]
    public class TestDecrementCasesLeftForCurrentRound
    {
        [TestMethod]
        public void ShouldNotDecrementIfCasesLeftAreZero()
        {
            Model.RoundManager manager = new Model.RoundManager(new List<int>());
            Assert.AreEqual(0, manager.CasesLeftForCurrentRound);
            manager.DecrementCasesLeftForCurrentRound();;
            Assert.AreEqual(0, manager.CasesLeftForCurrentRound);
        }

        [TestMethod]
        public void ShouldDecrementIfCasesLeftAreOne()
        {
            Model.RoundManager manager = new Model.RoundManager(new List<int>() {1, 2, 3});
            Assert.AreEqual(1, manager.CasesLeftForCurrentRound);
            manager.DecrementCasesLeftForCurrentRound(); ;
            Assert.AreEqual(0, manager.CasesLeftForCurrentRound);
        }

        [TestMethod]
        public void ShouldDecrementIfCasesLeftAreWellAboveOne()
        {
            Model.RoundManager manager = new Model.RoundManager(new List<int>() { 10, 2, 3 });
            Assert.AreEqual(10, manager.CasesLeftForCurrentRound);
            manager.DecrementCasesLeftForCurrentRound(); ;
            Assert.AreEqual(9, manager.CasesLeftForCurrentRound);
        }
    }
}
