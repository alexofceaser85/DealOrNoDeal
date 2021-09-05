using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DealOrNoDeal.Data;
using DealOrNoDeal.Data.Settings;

namespace DealOrNoDeal.Model
{
    /// <summary>
    /// Holds the game 
    ///
    /// Author: Alex DeCesare
    /// Version: 04-September-2021
    /// </summary>
    public class GameSettings
    {
        /// <summary>
        /// The setting for the cases to open
        /// </summary>
        public CasesToOpenSettings GameSettingForCasesToOpen { get; }

        /// <summary>
        /// The setting for the dollar values
        /// </summary>
        public DollarValuesForRoundSettings GameSettingForDollarValues { get; }

        /// <summary>
        /// The cases to open based on the game settings
        /// </summary>
        public IList<int> CasesToOpen { get; private set; }

        /// <summary>
        /// The dollar values based on the game settings
        /// </summary>
        public IList<int> DollarValues { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameSettings" /> class.
        ///
        /// Precondition: None
        /// Postcondtion:
        ///     this.CasesToOpen = casesToOpen
        ///     this.DollarValues = dollarValues
        /// </summary>
        /// <param name="casesToOpen">The setting for the cases to open</param>
        /// <param name="dollarValues">The setting for the dollar values</param>
        public GameSettings(CasesToOpenSettings casesToOpen, DollarValuesForRoundSettings dollarValues)
        {
            this.GameSettingForCasesToOpen = casesToOpen;
            this.GameSettingForDollarValues = dollarValues;
            this.SetGameValuesBasedOnSettings();
        }

        private void SetGameValuesBasedOnSettings()
        {
            if (this.GameSettingForCasesToOpen.Equals(CasesToOpenSettings.TenRoundGame))
            {
                this.SetDollarValuesForNonQuickPlayGame();
                this.CasesToOpen = CasesToOpenForEachRound.TenRoundCases;
            }

            if (this.GameSettingForCasesToOpen.Equals(CasesToOpenSettings.SevenRoundGame))
            {
                this.SetDollarValuesForNonQuickPlayGame();
                this.CasesToOpen = CasesToOpenForEachRound.SevenRoundGame;
            }

            if (this.GameSettingForCasesToOpen.Equals(CasesToOpenSettings.FiveRoundGame))
            {
                this.DollarValues = DollarValuesForEachRound.QuickPlay;
                this.CasesToOpen = CasesToOpenForEachRound.FiveRoundGame;
            }
        }

        private void SetDollarValuesForNonQuickPlayGame()
        {
            if (this.GameSettingForDollarValues.Equals(DollarValuesForRoundSettings.Regular))
            {
                this.DollarValues = DollarValuesForEachRound.Regular;
            }
            else
            {
                this.DollarValues = DollarValuesForEachRound.Syndicated;
            }
        }

    }
}
