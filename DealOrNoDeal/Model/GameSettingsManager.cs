using System.Collections.Generic;
using DealOrNoDeal.Data;
using DealOrNoDeal.Data.Rounds;
using DealOrNoDeal.Data.SettingVariables;

namespace DealOrNoDeal.Model
{
    /// <summary>
    /// Gets the game data associated with the game settings
    ///
    /// Author: Alex DeCesare
    /// Version: 04-September-2021
    /// </summary>
    public class GameSettingsManager
    {
        /// <summary>
        /// The cases to open based on the game settings
        /// </summary>
        public IList<int> CasesToOpen { get; private set; }

        /// <summary>
        /// The dollar values based on the game settings
        /// </summary>
        public IList<int> DollarValues { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameSettingsManager" /> class.
        ///
        /// Precondition: None
        /// Postcondition:
        /// this.CasesToOpen = casesToOpen
        /// this.DollarValues = dollarValues
        /// </summary>
        public GameSettingsManager()
        {
            this.setGameValuesBasedOnSettings();
        }

        private void setGameValuesBasedOnSettings()
        {
            if (UsersGameSettings.CasesToOpenSetting.Equals(CasesToOpenSettings.TenRoundGame))
            {
                this.setDollarValuesForNonQuickPlayGame();
                this.CasesToOpen = CasesToOpenForEachRound.TenRoundCases;
            } else if (UsersGameSettings.CasesToOpenSetting.Equals(CasesToOpenSettings.SevenRoundGame))
            {
                this.setDollarValuesForNonQuickPlayGame();
                this.CasesToOpen = CasesToOpenForEachRound.SevenRoundGame;
            } else if (UsersGameSettings.CasesToOpenSetting.Equals(CasesToOpenSettings.FiveRoundGame))
            {
                this.DollarValues = DollarValuesForEachRound.QuickPlay;
                this.CasesToOpen = CasesToOpenForEachRound.FiveRoundGame;
            }
        }

        private void setDollarValuesForNonQuickPlayGame()
        {
            if (UsersGameSettings.DollarValuesSetting.Equals(DollarValueSettings.Regular))
            {
                this.DollarValues = DollarValuesForEachRound.Regular;
            }
            else
            {
                this.DollarValues = DollarValuesForEachRound.Syndicated;
            }
        }

        /// <summary>
        /// Validates the users game settings, ensures that the settings are valid
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <returns>True if the game settings are valid, False otherwise</returns>
        public bool ValidateGameSettings()
        {
            if (UsersGameSettings.DollarValuesSetting.Equals(DollarValueSettings.Regular))
            {
                return validateNonQuickPlayGameSettings();
            }
            
            if (UsersGameSettings.DollarValuesSetting.Equals(DollarValueSettings.Syndicated))
            {
                return validateNonQuickPlayGameSettings();
            }

            return validateQuickPlayGameSettings();
        }

        private static bool validateNonQuickPlayGameSettings()
        {
            return UsersGameSettings.CasesToOpenSetting.Equals(CasesToOpenSettings.TenRoundGame) || UsersGameSettings.CasesToOpenSetting.Equals(CasesToOpenSettings.SevenRoundGame);
        }

        private static bool validateQuickPlayGameSettings()
        {
            return UsersGameSettings.CasesToOpenSetting.Equals(CasesToOpenSettings.FiveRoundGame);
        }
    }
}
