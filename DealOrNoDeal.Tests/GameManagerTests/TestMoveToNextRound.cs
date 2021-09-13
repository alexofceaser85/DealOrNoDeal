using System.Collections.Generic;
using DealOrNoDeal.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DealOrNoDeal.Tests.GameManagerTests
{
    [TestClass]
    public class TestMoveToNextRound
    {
        [TestMethod]
        public void ShouldMoveThroughManyRounds()
        { 
            var manager = new GameManager(new List<int> { 3, 2, 1 }, new List<int> {1000, 2000, 3000});

            Assert.AreEqual(2, manager.RoundManager.CasesAvailableForNextRound);
            Assert.AreEqual(1, manager.RoundManager.CurrentRound);
            Assert.AreEqual(3, manager.RoundManager.CasesAvailableForCurrentRound);
            Assert.AreEqual(3, manager.RoundManager.CasesLeftForCurrentRound);

            manager.RoundManager.MoveToNextRound();

            Assert.AreEqual(1, manager.RoundManager.CasesAvailableForNextRound);
            Assert.AreEqual(2, manager.RoundManager.CurrentRound);
            Assert.AreEqual(2, manager.RoundManager.CasesAvailableForCurrentRound);
            Assert.AreEqual(2, manager.RoundManager.CasesLeftForCurrentRound);

            manager.RoundManager.MoveToNextRound();

            Assert.AreEqual(1, manager.RoundManager.CasesAvailableForNextRound);
            Assert.AreEqual(3, manager.RoundManager.CurrentRound);
            Assert.AreEqual(1, manager.RoundManager.CasesAvailableForCurrentRound);
            Assert.AreEqual(1, manager.RoundManager.CasesLeftForCurrentRound);
        }
    }
}
