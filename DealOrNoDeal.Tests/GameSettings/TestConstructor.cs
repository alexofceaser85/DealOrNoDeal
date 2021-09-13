using DealOrNoDeal.Data.Rounds;
using DealOrNoDeal.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DealOrNoDeal.Tests.GameSettings
{
    [TestClass]
    public class TestConstructor
    {
        [TestMethod]
        public void ShouldSetGameSettingsForTenRoundNotSyndicatedGame()
        {
            var settings = new GameSettingsManager();

            Assert.AreEqual(CasesToOpenForEachRound.TenRoundCases.ToString(), settings.CasesToOpen.ToString());
            Assert.AreEqual(DollarValuesForEachRound.Regular.ToString(), settings.DollarValues.ToString());
        }

        [TestMethod]
        public void ShouldSetGameSettingsForTenRoundSyndicatedGame()
        {
            var settings = new GameSettingsManager();

            Assert.AreEqual(CasesToOpenForEachRound.TenRoundCases.ToString(), settings.CasesToOpen.ToString());
            Assert.AreEqual(DollarValuesForEachRound.Syndicated.ToString(), settings.DollarValues.ToString());
        }

        [TestMethod]
        public void ShouldSetGameSettingsForSevenRoundNotSyndicatedGame()
        {
            var settings = new GameSettingsManager();

            Assert.AreEqual(CasesToOpenForEachRound.SevenRoundGame.ToString(), settings.CasesToOpen.ToString());
            Assert.AreEqual(DollarValuesForEachRound.Regular.ToString(), settings.DollarValues.ToString());
        }

        [TestMethod]
        public void ShouldSetGameSettingsForSevenRoundSyndicatedGame()
        {
            var settings = new GameSettingsManager();

            Assert.AreEqual(CasesToOpenForEachRound.SevenRoundGame.ToString(), settings.CasesToOpen.ToString());
            Assert.AreEqual(DollarValuesForEachRound.Syndicated.ToString(), settings.DollarValues.ToString());
        }

        [TestMethod]
        public void ShouldSetGameSettingsForQuickPlay()
        {

            var settings = new GameSettingsManager();

            Assert.AreEqual(CasesToOpenForEachRound.FiveRoundGame.ToString(), settings.CasesToOpen.ToString());
            Assert.AreEqual(DollarValuesForEachRound.QuickPlay.ToString(), settings.DollarValues.ToString());
        }
    }
}
