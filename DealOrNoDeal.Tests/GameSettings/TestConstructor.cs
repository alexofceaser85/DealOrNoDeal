using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DealOrNoDeal.Data;
using DealOrNoDeal.Data.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DealOrNoDeal.Tests.GameSettings
{
    [TestClass]
    public class TestConstructor
    {
        [TestMethod]
        public void ShouldSetGameSettingsForTenRoundNotSyndicatedGame()
        {
            Model.GameSettings settings = new Model.GameSettings(CasesToOpenSettings.TenRoundGame,
                DollarValuesForRoundSettings.Regular);

            Assert.IsTrue(settings.GameSettingForCasesToOpen.Equals(CasesToOpenSettings.TenRoundGame));
            Assert.IsTrue(settings.GameSettingForDollarValues.Equals(DollarValuesForRoundSettings.Regular));

            Assert.IsTrue(settings.CasesToOpen.Equals(CasesToOpenForEachRound.TenRoundCases));
            Assert.IsTrue(settings.DollarValues.Equals(DollarValuesForEachRound.Regular));
        }

        [TestMethod]
        public void ShouldSetGameSettingsForTenRoundSyndicatedGame()
        {
            Model.GameSettings settings = new Model.GameSettings(CasesToOpenSettings.TenRoundGame,
                DollarValuesForRoundSettings.Syndicated);

            Assert.IsTrue(settings.GameSettingForCasesToOpen.Equals(CasesToOpenSettings.TenRoundGame));
            Assert.IsTrue(settings.GameSettingForDollarValues.Equals(DollarValuesForRoundSettings.Syndicated));

            Assert.IsTrue(settings.CasesToOpen.Equals(CasesToOpenForEachRound.TenRoundCases));
            Assert.IsTrue(settings.DollarValues.Equals(DollarValuesForEachRound.Syndicated));
        }

        [TestMethod]
        public void ShouldSetGameSettingsForSevenRoundNotSyndicatedGame()
        {
            Model.GameSettings settings = new Model.GameSettings(CasesToOpenSettings.SevenRoundGame,
                DollarValuesForRoundSettings.Regular);

            Assert.IsTrue(settings.GameSettingForCasesToOpen.Equals(CasesToOpenSettings.SevenRoundGame));
            Assert.IsTrue(settings.GameSettingForDollarValues.Equals(DollarValuesForRoundSettings.Regular));

            Assert.IsTrue(settings.CasesToOpen.Equals(CasesToOpenForEachRound.SevenRoundGame));
            Assert.IsTrue(settings.DollarValues.Equals(DollarValuesForEachRound.Regular));
        }

        [TestMethod]
        public void ShouldSetGameSettingsForSevenRoundSyndicatedGame()
        {
            Model.GameSettings settings = new Model.GameSettings(CasesToOpenSettings.SevenRoundGame,
                DollarValuesForRoundSettings.Syndicated);

            Assert.IsTrue(settings.GameSettingForCasesToOpen.Equals(CasesToOpenSettings.SevenRoundGame));
            Assert.IsTrue(settings.GameSettingForDollarValues.Equals(DollarValuesForRoundSettings.Syndicated));

            Assert.IsTrue(settings.CasesToOpen.Equals(CasesToOpenForEachRound.SevenRoundGame));
            Assert.IsTrue(settings.DollarValues.Equals(DollarValuesForEachRound.Syndicated));
        }

        [TestMethod]
        public void ShouldSetGameSettingsForQuickPlay()
        {
            Model.GameSettings settings = new Model.GameSettings(CasesToOpenSettings.FiveRoundGame,
                DollarValuesForRoundSettings.QuickPlay);

            Assert.IsTrue(settings.GameSettingForCasesToOpen.Equals(CasesToOpenSettings.FiveRoundGame));
            Assert.IsTrue(settings.GameSettingForDollarValues.Equals(DollarValuesForRoundSettings.QuickPlay));

            Assert.IsTrue(settings.CasesToOpen.Equals(CasesToOpenForEachRound.FiveRoundGame));
            Assert.IsTrue(settings.DollarValues.Equals(DollarValuesForEachRound.QuickPlay));
        }
    }
}
