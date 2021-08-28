using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealOrNoDeal.Model
{
    /// <summary>
    /// Holds the data for the game banker
    /// </summary>
    public class Banker
    {
        /// <summary>
        /// Calculates the offer from the banker
        /// </summary>
        /// <param name="dollarAmountsInPlay">The dollar amounts left in play from the briefcases</param>
        /// <param name="numberOfCasesToOpenInNextRound">The number of cases that  can be opened in the next round</param>
        /// <param name="numberOfCasesRemainingInGame">The number of cases remaining in the game</param>
        /// <returns></returns>
        public static int CalculateBankerOffer(int dollarAmountsInPlay, int numberOfCasesToOpenInNextRound, int numberOfCasesRemainingInGame)
        {
            var unRoundedBankerOffer = (double) dollarAmountsInPlay / numberOfCasesToOpenInNextRound / numberOfCasesRemainingInGame;
            return (int) Math.Round(unRoundedBankerOffer);
        }
    }
}
