using System;
using System.Collections.Generic;
using DealOrNoDeal.ErrorMessages;

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
        private const int InitialCurrentOffer = 0;
        private const int InitialAverageOffer = 0;
        private const int InitialMinimumOffer = int.MaxValue;
        private const int InitialMaximumOffer = int.MinValue;

        private List<int> previousOffers;
        private int currentOffer;
        private int averageOffer;
        private int minimumOffer;
        private int maximumOffer;

        /// <summary>
        ///     The current banker offer.
        ///     Precondition:
        ///     value >= 0
        ///     Postcondition:
        ///     this.currentOffer == value
        /// </summary>
        /// <value>The banker's current offer.</value>
        public int CurrentOffer
        {
            get => this.currentOffer;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(BankerErrorMessages
                        .ShouldNotSetCurrentOfferToLessThanZero);
                }

                this.currentOffer = value;
            }
        }

        public int AverageOffer
        {
            get => this.averageOffer;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(BankerErrorMessages.ShouldNotSetAverageOfferToLessThanZero);
                }

                this.averageOffer = value;
            }
        }

        /// <summary>
        ///     The lowest offer the banker offered throughout the game
        ///     Precondition:
        ///     value  >= 0
        ///     AND value >= this.MinimumOffer OR this.MinimumOffer == InitialMinimumOffer
        ///     Postcondition:
        ///     this.minimumOffer == value
        /// </summary>
        /// <value>The minimum banker offer.</value>
        public int MinimumOffer
        {
            get => this.minimumOffer;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(BankerErrorMessages
                        .ShouldNotSetMinimumOfferToLessThanZero);
                }

                if (value > this.MaximumOffer && this.MaximumOffer != InitialMaximumOffer)
                {
                    throw new ArgumentException(BankerErrorMessages
                        .ShouldNotSetMinimumOfferToMoreThanMaximumOffer);
                }

                this.minimumOffer = value;
            }
        }

        /// <summary>
        ///     The highest offer the banker offered throughout the game
        ///     Precondition:
        ///     value >= 0
        ///     AND value >= this.MaximumOffer OR this.MaximumOffer == InitialMaximumOffer
        ///     Postcondition:
        ///     this.maximumOffer == value
        /// </summary>
        /// <value>The maximum banker offer.</value>
        public int MaximumOffer
        {
            get => this.maximumOffer;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(BankerErrorMessages
                        .ShouldNotSetMaximumOfferToLessThanZero);
                }

                if (value < this.MinimumOffer && this.MinimumOffer != InitialMinimumOffer)
                {
                    throw new ArgumentException(BankerErrorMessages
                        .ShouldNotSetMaximumOfferToLessThanMinimumOffer);
                }

                this.maximumOffer = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Banker" /> class.
        ///
        /// Precondition: None
        /// Postcondition:
        ///     this.previousOffers = new List&lt;int&gt;
        ///     this.currentOffer == 0
        ///     this.minimumOffer == int.MaxValue
        ///     this.maximumOffer == int.MinValue
        /// </summary>
        public Banker()
        {
            this.previousOffers = new List<int>();
            this.CurrentOffer = InitialCurrentOffer;
            this.AverageOffer = InitialAverageOffer;
            this.minimumOffer = InitialMinimumOffer;
            this.maximumOffer = InitialMaximumOffer;
        }

        /// <summary>
        /// Calculates the offer from the banker
        ///
        /// Precondition: None
        /// Postcondition:
        ///     this.CurrentOffer == InitialCurrentOffer;
        ///     AND this.MinimumOffer == InitialMinimumOffer;
        ///     AND this.MaximumOffer == InitialMaximumOffer;
        /// </summary>
        /// <param name="briefcasesStillInPlay">The briefcases that are still in play</param>
        /// <param name="numberOfCasesToOpenInNextRound">The number of cases that can be opened in the next round</param>
        /// <returns>The amount of money which will be offered by the banker</returns>
        public int CalculateOffer(IList<Briefcase> briefcasesStillInPlay, int numberOfCasesToOpenInNextRound)
        {
            if (briefcasesStillInPlay == null)
            {
                throw new ArgumentException(BankerErrorMessages
                    .CannotCalculateBankerOfferIfBriefcasesStillInPlayAreNull);
            }

            if (numberOfCasesToOpenInNextRound <= 0)
            {
                throw new ArgumentException(BankerErrorMessages
                    .CannotCalculateBankerOfferIfNumberOfCasesToOpenIsLessThanOrEqualToZero);
            }

            var unRoundedOffer = calculateTotalBriefcaseDollarAmounts(briefcasesStillInPlay) / numberOfCasesToOpenInNextRound / briefcasesStillInPlay.Count;
            var roundedOffer = roundOfferToNearestOneHundred(unRoundedOffer);
            this.previousOffers.Add(roundedOffer);
            this.updateOffers(roundedOffer);
            return roundedOffer;
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

        private static int roundOfferToNearestOneHundred(double unRoundedBankerOffer)
        {
            return (int)Math.Round(unRoundedBankerOffer / 100) * 100;
        }

        private void updateOffers(int bankerOffer)
        {
            this.CurrentOffer = bankerOffer;
            this.AverageOffer = this.calculateAverageOffer();

            if (this.MinimumOffer > bankerOffer)
            {
                this.MinimumOffer = bankerOffer;
            }

            if (this.MaximumOffer < bankerOffer)
            {
                this.MaximumOffer = bankerOffer;
            }
        }

        private int calculateAverageOffer()
        {
            int totalOffer = 0;

            foreach (int offer in this.previousOffers)
            {
                totalOffer += offer;
            }

            return totalOffer / this.previousOffers.Count;
        }

    }
}
