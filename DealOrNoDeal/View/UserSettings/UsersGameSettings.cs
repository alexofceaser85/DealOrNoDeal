using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DealOrNoDeal.Data.Settings;

namespace DealOrNoDeal.View.UserSettings
{
    public static class UsersGameSettings
    {
        /// <summary>
        /// Holds the settings for cases to open
        /// </summary>
        public static CasesToOpenSettings CasesToOpenSetting { get; } = CasesToOpenSettings.FiveRoundGame;
        /// <summary>
        /// Holds the settings for the dollar values
        /// </summary>
        public static DollarValuesForRoundSettings DollarValuesSetting { get; } = DollarValuesForRoundSettings.QuickPlay;
    }
}
