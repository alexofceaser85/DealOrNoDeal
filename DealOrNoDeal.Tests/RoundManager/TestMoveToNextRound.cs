using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DealOrNoDeal.Tests.RoundManager
{
    [TestClass]
    public class TestMoveToNextRound
    {
        [TestMethod]
        public void ShouldNotMoveToNextRoundInEmptyRoundManagerList()
        {
            Model.RoundManager manager = new Model.RoundManager(new List<int>());

            manager.MoveToNextRound();

            Assert.AreEqual(0, manager.CasesAvailableForNextRound);
            Assert.AreEqual(2, manager.CurrentRound);
            Assert.AreEqual(0, manager.CasesAvailableForCurrentRound);
            Assert.AreEqual(0, manager.CasesLeftForCurrentRound);
        }

        [TestMethod]
        public void ShouldNotMoveToNextRoundInManagerWithOneItem()
        {
            Model.RoundManager manager = new Model.RoundManager(new List<int>() {1});

            manager.MoveToNextRound();

            Assert.AreEqual(0, manager.CasesAvailableForNextRound);
            Assert.AreEqual(2, manager.CurrentRound);
            Assert.AreEqual(0, manager.CasesAvailableForCurrentRound);
            Assert.AreEqual(0, manager.CasesLeftForCurrentRound);
        }

        [TestMethod]
        public void ShouldMoveThroughManyRounds()
        {
            Model.RoundManager manager = new Model.RoundManager(new List<int>() {3, 2, 1});

            Assert.AreEqual(2, manager.CasesAvailableForNextRound);
            Assert.AreEqual(1, manager.CurrentRound);
            Assert.AreEqual(3, manager.CasesAvailableForCurrentRound);
            Assert.AreEqual(3, manager.CasesLeftForCurrentRound);

            manager.MoveToNextRound();

            Assert.AreEqual(1, manager.CasesAvailableForNextRound);
            Assert.AreEqual(2, manager.CurrentRound);
            Assert.AreEqual(2, manager.CasesAvailableForCurrentRound);
            Assert.AreEqual(2, manager.CasesLeftForCurrentRound);

            manager.MoveToNextRound();

            Assert.AreEqual(1, manager.CasesAvailableForNextRound);
            Assert.AreEqual(3, manager.CurrentRound);
            Assert.AreEqual(1, manager.CasesAvailableForCurrentRound);
            Assert.AreEqual(1, manager.CasesLeftForCurrentRound);
        }
    }
}
