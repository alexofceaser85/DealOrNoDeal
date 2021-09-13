using System;
using DealOrNoDeal.Model;

namespace DealOrNoDeal.View.FormattedValues
{
    /// <summary>
    /// Formats the banker offers
    ///
    /// Author: Alex DeCesare
    /// Version: 10-September-2021
    /// </summary>
    public class FormattedOffers
    {
        private const string BankerOfferFormatOption = "C";

        /// <summary>
        /// The formatted current offer
        /// </summary>
        public string CurrentOffer { get; private set; }

        /// <summary>
        /// The formatted average offer
        /// </summary>
        public string AverageOffer { get; private set; }

        /// <summary>
        /// The formatted minimum offer
        /// </summary>
        public string MinimumOffer { get; private set; }

        /// <summary>
        /// The formatted maximum offer
        /// </summary>
        public string MaximumOffer { get; private set; }

        /// <summary>
        /// Updates the formatted offers
        ///
        /// Precondition: None
        /// Postcondition:
        /// this.CurrentOffer == gameManager.Banker.CurrentOffer.ToString(BankerOfferFormatOption);
        /// this.FormattedAverageOfferOffer == gameManager.Banker.AverageOffer.ToString(BankerOfferFormatOption);
        /// this.FormattedMinimumOfferOffer == gameManager.Banker.MinimumOffer.ToString(BankerOfferFormatOption);
        /// this.FormattedMaximumOfferOffer == gameManager.Banker.MaximumOffer.ToString(BankerOfferFormatOption);
        /// </summary>
        /// <param name="gameManager">The game manager holding the unformatted offers</param>
        public void UpdateFormattedOffers(GameManager gameManager)
        {
            gameManager.GetOffer();
            this.CurrentOffer = formatOffer(gameManager.Banker.CurrentOffer);
            this.AverageOffer = formatOffer(gameManager.Banker.AverageOffer);
            this.MinimumOffer = formatOffer(gameManager.Banker.MinimumOffer);
            this.MaximumOffer = formatOffer(gameManager.Banker.MaximumOffer);
        }

        private static string formatOffer(double unformattedOffer)
        {
            var roundedOffer = RoundOfferToNearestOneHundred(unformattedOffer);
            return roundedOffer.ToString(BankerOfferFormatOption);
        }

        private static int RoundOfferToNearestOneHundred(double unRoundedBankerOffer)
        {
            return (int)Math.Round(unRoundedBankerOffer / 100) * 100;
        }
    }
}
