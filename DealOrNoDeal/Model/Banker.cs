using System;
using System.Collections.Generic;

namespace DealOrNoDeal.Model
{
    /// <summary>
    /// Holds the data for the game banker
    ///
    /// Author: Alex DeCesare
    /// Version: 31-August-2021
    /// </summary>
    public class Banker
    {
        /// <summary>
        /// Calculates the offer from the banker
        /// </summary>
        /// <param name="briefcasesStillInPlay">The briefcases that are still in play</param>
        /// <param name="numberOfCasesToOpenInNextRound">The number of cases that can be opened in the next round</param>
        /// <returns>The amount of money which will be offered by the banker</returns>
        public static int CalculateBankerOffer(IList<Briefcase> briefcasesStillInPlay, int numberOfCasesToOpenInNextRound)
        {
            var unRoundedBankerOffer = calculateTotalBriefcaseDollarAmounts(briefcasesStillInPlay) / numberOfCasesToOpenInNextRound / briefcasesStillInPlay.Count;
            return roundBankerOfferToNearestOneHundred(unRoundedBankerOffer);
        }

        private static double calculateTotalBriefcaseDollarAmounts(IEnumerable<Briefcase> briefcasesStillInPlay)
        {
            var totalBriefcaseDollarAmounts = 0;

            foreach (var briefcase in briefcasesStillInPlay)
            {
                totalBriefcaseDollarAmounts += briefcase.DollarAmount;
            }

            return totalBriefcaseDollarAmounts;
        }

        private static int roundBankerOfferToNearestOneHundred(double unRoundedBankerOffer)
        {
            return (int)Math.Round(unRoundedBankerOffer / 100) * 100;
        }
    }
}
