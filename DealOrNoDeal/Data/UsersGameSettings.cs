using DealOrNoDeal.Data.SettingVariables;

namespace DealOrNoDeal.Data
{
    /// <summary>
    /// This is where the user will set the game settings
    /// 
    /// Author: Alex DeCesare
    /// Version: 08-September-2021
    /// </summary>
    public static class UsersGameSettings
    {
        /// <summary>
        /// Holds the user defined settings for the dollar values
        /// </summary>
        public static DollarValueSettings DollarValuesSetting = DollarValueSettings.Regular;

        /// <summary>
        /// Holds the user defined settings for cases to open
        /// </summary>
        public static CasesToOpenSettings CasesToOpenSetting = CasesToOpenSettings.TenRoundGame;
    }
}
