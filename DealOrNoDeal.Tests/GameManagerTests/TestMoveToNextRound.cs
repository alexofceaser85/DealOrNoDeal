using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DealOrNoDeal.Tests.GameManagerTests
{
    [TestClass]
    public class TestMoveToNextRound
    {
        [TestMethod]
        public void ShouldNotMoveToNextRoundInEmptyRoundManagerList()
        {
            Model.GameManager manager = new Model.GameManager(new List<int>(), new List<int>());

            manager.MoveToNextRound();

            Assert.AreEqual(0, manager.RoundManager.CasesAvailableForNextRound);
            Assert.AreEqual(2, manager.RoundManager.CurrentRound);
            Assert.AreEqual(0, manager.RoundManager.CasesAvailableForCurrentRound);
            Assert.AreEqual(0, manager.RoundManager.CasesLeftForCurrentRound);
        }

        [TestMethod]
        public void ShouldNotMoveToNextRoundInManagerWithOneItem()
        {
            Model.GameManager manager = new Model.GameManager(new List<int>() { 1 }, new List<int>() { 10 });

            manager.MoveToNextRound();

            Assert.AreEqual(0, manager.RoundManager.CasesAvailableForNextRound);
            Assert.AreEqual(2, manager.RoundManager.CurrentRound);
            Assert.AreEqual(0, manager.RoundManager.CasesAvailableForCurrentRound);
            Assert.AreEqual(0, manager.RoundManager.CasesLeftForCurrentRound);
        }

        [TestMethod]
        public void ShouldMoveThroughManyRounds()
        {
            Model.GameManager manager = new Model.GameManager(new List<int>() { 3, 2, 1 }, new List<int>() {1000, 2000, 3000});

            Assert.AreEqual(2, manager.RoundManager.CasesAvailableForNextRound);
            Assert.AreEqual(1, manager.RoundManager.CurrentRound);
            Assert.AreEqual(3, manager.RoundManager.CasesAvailableForCurrentRound);
            Assert.AreEqual(3, manager.RoundManager.CasesLeftForCurrentRound);

            manager.MoveToNextRound();

            Assert.AreEqual(1, manager.RoundManager.CasesAvailableForNextRound);
            Assert.AreEqual(2, manager.RoundManager.CurrentRound);
            Assert.AreEqual(2, manager.RoundManager.CasesAvailableForCurrentRound);
            Assert.AreEqual(2, manager.RoundManager.CasesLeftForCurrentRound);

            manager.MoveToNextRound();

            Assert.AreEqual(1, manager.RoundManager.CasesAvailableForNextRound);
            Assert.AreEqual(3, manager.RoundManager.CurrentRound);
            Assert.AreEqual(1, manager.RoundManager.CasesAvailableForCurrentRound);
            Assert.AreEqual(1, manager.RoundManager.CasesLeftForCurrentRound);
        }
    }
}
