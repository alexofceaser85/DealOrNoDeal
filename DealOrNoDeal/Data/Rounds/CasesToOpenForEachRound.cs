using System.Collections.Generic;

namespace DealOrNoDeal.Data.Rounds
{
    /// <summary>
    /// Holds the cases to open for each round
    ///
    /// Author: Alex DeCesare
    /// Version: 03-September-2021
    /// </summary>
    public static class CasesToOpenForEachRound
    {
        /// <summary>
        /// Holds the cases to open for a five round game
        /// </summary>
        public static List<int> FiveRoundGame = new List<int> { 6, 5, 3, 2 };
        /// <summary>
        /// Holds the cases to open for a seven round game
        /// </summary>
        public static List<int> SevenRoundGame = new List<int> { 8, 6, 4, 3, 2, 1 };
        /// <summary>
        /// Holds the cases to open for a ten round game
        /// </summary>
        public static List<int> TenRoundCases = new List<int> {6, 5, 4, 3, 2, 1, 1, 1, 1};
    }
}
