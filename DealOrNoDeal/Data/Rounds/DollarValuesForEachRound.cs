using System.Collections.Generic;

namespace DealOrNoDeal.Data.Rounds
{
    /// <summary>
    /// Holds the dollar amounts for each version of the game
    ///
    /// Author: Alex DeCesare
    /// Version: 04-September-2021
    /// </summary>
    public static class DollarValuesForEachRound
    {
        /// <summary>
        /// Holds the dollar values that each briefcase can have for a quick play, 18 case, game
        /// </summary>
        public static IList<int> QuickPlay = new List<int> {
            0, 5, 10, 25, 50, 75, 100, 250, 500, 750, 1000, 2500, 5000, 10000, 25000, 50000, 75000, 100000
        };
        /// <summary>
        /// Holds the dollar values that each briefcase can have for a syndicated, 26 case, game
        /// </summary>
        public static IList<int> Syndicated = new List<int> {
            0, 1, 5, 10, 25, 50, 75, 100, 200, 300, 400, 500, 750, 1000, 2500, 5000, 10000, 25000, 50000, 75000, 100000,
            150000, 200000, 250000, 350000, 500000
        };
        /// <summary>
        /// Holds the dollar values that each briefcase can have for a regular/default, 26 case, game
        /// </summary>
        public static IList<int> Regular = new List<int> {
            0, 1, 5, 10, 25, 50, 75, 100, 200, 300, 400, 500, 750, 1000, 5000, 10000, 25000, 50000, 75000, 100000,
            200000, 300000, 400000, 500000, 750000, 1000000
        };
    }
}
