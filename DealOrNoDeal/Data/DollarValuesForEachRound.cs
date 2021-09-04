using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealOrNoDeal.Data
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
        /// Holds the dollar values the each briefcase can have for a regular/default, 26 case, game
        /// </summary>
        public static IList<int> RegularVersion = new List<int> {
            0, 1, 5, 10, 25, 50, 75, 100, 200, 300, 400, 500, 750, 1000, 5000, 10000, 25000, 50000, 75000, 100000,
            200000, 300000, 400000, 500000, 750000, 1000000
        };
    }
}
