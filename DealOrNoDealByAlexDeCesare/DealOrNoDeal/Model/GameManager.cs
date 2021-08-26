using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace DealOrNoDeal.Model
{
    /// <summary>Handles the management of the actual game play.</summary>
    public class GameManager
    {
        #region Constructors

        private readonly IList<int> briefCaseDollarAmounts = new List<int>
        {
            0, 1, 5, 10, 25, 50, 75, 100, 200, 300, 400, 500, 750, 1000, 5000, 10000, 25000, 50000, 75000, 100000,
            200000, 300000, 400000, 500000, 750000, 1000000
        };

        private IList<Briefcase> theBriefcases;

        private const int InitialCurrentRound = 1;
        private int InitialCasesLeftForCurrentRound = 6;
        private const int InitialPlayerSelectedStartingCase = 1;
        private const int InitialBankerCurrentOffer = 0;
        private const int InitialBankerMinimumOffer = int.MaxValue;
        private const int InitialBankerMaximumOffer = int.MinValue;

        private int currentRound;
        private int casesLeftForCurrentRound;
        private int playerSelectedStartingCase;
        private int bankerCurrentOffer;
        private int bankerMinimumOffer;
        private int bankerMaximumOffer;

        public int TotalBriefCaseDollarAmountInPlay { get; private set; }
        public int CasesLeftInGame { get; private set; }

        /// <summary>
        ///     Gets or sets the current round.
        /// </summary>
        /// <value>The current round.</value>
        public int CurrentRound {
            get => currentRound;
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException(
                        ErrorMessages.GameManagerErrorMessages.ShouldNotSetCurrentRoundToLessThanOne);
                }

                currentRound = value;
            } }

        /// <summary>
        ///     Gets or sets the cases left for current round.
        /// </summary>
        /// <value>The cases left for current round.</value>
        public int CasesLeftForCurrentRound
        {
            get => casesLeftForCurrentRound;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ErrorMessages.GameManagerErrorMessages
                        .ShouldNotSetCasesLeftForCurrentRoundToLessThanZero);
                }

                casesLeftForCurrentRound = value;
            }
        }

        /// <summary>
        ///     Gets or sets the player selected starting case.
        /// </summary>
        /// <value>The player selected starting case.</value>
        public int PlayerSelectedStartingCase { 
            get => playerSelectedStartingCase;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ErrorMessages.GameManagerErrorMessages
                        .ShouldNotSetPlaySelectedStartingCaseToLessThanZero);
                }

                playerSelectedStartingCase = value;
            }
        }

        /// <summary>
        ///     Gets or sets the banker current offer.
        /// </summary>
        /// <value>The banker current offer.</value>
        public int BankerCurrentOffer
        {
            get => bankerCurrentOffer;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ErrorMessages.GameManagerErrorMessages
                        .ShouldNotSetBankerCurrentOfferToLessThanZero);
                }

                bankerCurrentOffer = value;
            }
        }

        /// <summary>
        ///     Gets or sets the minimum banker offer.
        /// </summary>
        /// <value>The minimum banker offer.</value>
        public int BankerMinimumOffer { get => bankerMinimumOffer;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ErrorMessages.GameManagerErrorMessages
                        .ShouldNotSetBankerMinimumOfferToLessThanZero);
                }

                if (value > BankerMaximumOffer && BankerMaximumOffer != InitialBankerMaximumOffer)
                {
                    throw new ArgumentException(ErrorMessages.GameManagerErrorMessages
                        .ShouldNotSetBankerMinimumOfferToMoreThanMaximumOffer);
                }

                bankerMinimumOffer = value;
            } }

        /// <summary>
        ///     Gets or sets the maximum banker offer.
        /// </summary>
        /// <value>The maximum banker offer.</value>
        public int BankerMaximumOffer { get => bankerMaximumOffer;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ErrorMessages.GameManagerErrorMessages
                        .ShouldNotSetBankerMaximumOfferToLessThanZero);
                }

                if (value < BankerMinimumOffer && BankerMinimumOffer != InitialBankerMinimumOffer)
                {
                    throw new ArgumentException(ErrorMessages.GameManagerErrorMessages
                        .ShouldNotSetBankerMaximumOfferToLessThanMinimumOffer);
                }

                bankerMaximumOffer = value;
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameManager" /> class.
        /// </summary>
        /// <precondition>
        ///     None
        /// </precondition>
        /// <postcondition>
        ///     this.theBriefcases.Length == 26
        ///     this.CalculateTotalBriefcaseDollarAmounts == Sum of each int in briefCaseDollarAmounts
        ///     this.CurrentRound == this.InitialCurrentRound;
        ///     this.CasesLeftForCurrentRound == this.InitialCasesLeftForCurrentRound;
        ///     this.PlayerSelectedStartingCase == this.InitialPlayerSelectedStartingCase;
        ///     this.BankerCurrentOffer == this.InitialBankerCurrentOffer;
        ///     this.BankerMinimumOffer == this.InitialBankerMinimumOffer;
        ///     this.BankerMaximumOffer == this.InitialBankerMaximumOffer;
        /// </postcondition>
        public GameManager()
        {
            this.PopulateBriefcases(GetRandomIndexesToAccessDollarValues(briefCaseDollarAmounts.Count, 0,
                briefCaseDollarAmounts.Count), briefCaseDollarAmounts);
            this.TotalBriefCaseDollarAmountInPlay = this.CalculateTotalBriefcaseDollarAmounts();
            CurrentRound = InitialCurrentRound;
            CasesLeftForCurrentRound = InitialCasesLeftForCurrentRound;
            PlayerSelectedStartingCase = InitialPlayerSelectedStartingCase;
            BankerCurrentOffer = InitialBankerCurrentOffer;
            this.bankerMinimumOffer = InitialBankerMinimumOffer;
            this.bankerMaximumOffer = InitialBankerMaximumOffer;
        }

        /// <summary>
        /// Populates the briefcases
        /// </summary>
        ///
        /// <precondition>
        /// indexesOfDollarValuesToPopulate != null
        /// dollarValuesToPopulate != null
        /// </precondition>
        ///
        /// <postcondition>
        /// this.theBriefcases.Count == this.indexesOfDollarValuesToPopulate.Length
        /// </postcondition>
        /// <param name="indexesOfDollarValuesToPopulate">The index of the array element which is used to get a value from the dollar values</param>
        /// <param name="dollarValuesToPopulate">The dollar values which are to be accessed</param>
        public void PopulateBriefcases(IList<int> indexesOfDollarValuesToPopulate, IList<int> dollarValuesToPopulate)
        {
            if (indexesOfDollarValuesToPopulate == null)
            {
                throw new ArgumentException(ErrorMessages.GameManagerErrorMessages
                    .ShouldNotPopulateBriefcasesIfIndexesOfDollarValuesAreNull);
            }

            if (dollarValuesToPopulate == null)
            {
                throw new ArgumentException(ErrorMessages.GameManagerErrorMessages
                    .ShouldNotPopulateBriefcasesIfDollarValuesAreNull);
            }

            IList<Briefcase> thePopulatedBriefcases = new List<Briefcase>();

            for (var counter = 0; counter < indexesOfDollarValuesToPopulate.Count; counter++)
            {
                var currentDollarAmountIndex = indexesOfDollarValuesToPopulate[counter];
                var newBriefcase = new Briefcase(counter, dollarValuesToPopulate[currentDollarAmountIndex]);
                thePopulatedBriefcases.Add(newBriefcase);
            }

            theBriefcases = thePopulatedBriefcases;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Gets the briefcase value.
        /// </summary>
        /// <precondition>
        ///     None
        /// </precondition>
        /// <postcondition>
        ///     None
        /// </postcondition>
        /// <param name="briefcaseIdToGet">The briefcase identifier to get.</param>
        /// <returns>
        ///     the dollar amount of the briefcase that has been selected, -1 if the briefcase Id is not present in the
        ///     Briefcases
        /// </returns>
        public int GetBriefcaseValue(int briefcaseIdToGet)
        {
            var theSelectedBriefcase = GetBriefcaseById(briefcaseIdToGet);

            if (theSelectedBriefcase == null) return -1;
            return theSelectedBriefcase.DollarAmount;
        }

        /// <summary>
        ///     Removes the specified briefcase from play.
        ///     Precondition: None
        /// </summary>
        /// <precondition>
        ///     None
        /// </precondition>
        /// <postcondition>
        ///     None
        /// </postcondition>
        /// <param name="id">The id of the briefcase to remove from play.</param>
        /// <returns>Dollar amount stored in the case, or -1 if case not found.</returns>
        public int RemoveBriefcaseFromPlay(int id)
        {
            var briefcaseToRemove = GetBriefcaseById(id);
            if (briefcaseToRemove == null) return -1;

            this.TotalBriefCaseDollarAmountInPlay =- briefcaseToRemove.DollarAmount;
            this.CasesLeftInGame--;
            theBriefcases.Remove(GetBriefcaseById(id));
            return briefcaseToRemove.DollarAmount;
        }

        /// <summary>
        ///     TODO Complete method specification
        /// </summary>
        /// <returns></returns>
        public int GetOffer()
        {
            //int casesLeftForTheNextRound;
            //if (this.CasesLeftForCurrentRound > 1)
            //{
            //    casesLeftForTheNextRound = this.CasesLeftForCurrentRound--;
            //}
            //else
            //{
            //    casesLeftForTheNextRound = this.CasesLeftForCurrentRound;
            //}

            return Banker.CalculateBankerOffer(this.TotalBriefCaseDollarAmountInPlay, this.CasesLeftForCurrentRound,
                this.CasesLeftInGame);
        }

        /// <summary>
        ///     Moves to next round by incrementing Round property and setting
        ///     initial number of cases for that round
        ///     Precondition: None
        ///     Postcondition: Round == Round@prev + 1 AND CasesRemainingInRound == (number of cases to open in the next round)
        /// </summary>
        public void MoveToNextRound()
        {
            this.CurrentRound++;
            this.InitialCasesLeftForCurrentRound--;
            this.CasesLeftForCurrentRound = InitialCasesLeftForCurrentRound;
        }

        private int CalculateTotalBriefcaseDollarAmounts()
        {
            var totalBriefcaseDollarAmounts = 0;

            foreach (var briefcaseDollarAmount in this.briefCaseDollarAmounts)
            {
                totalBriefcaseDollarAmounts += briefcaseDollarAmount;
            }

            return totalBriefcaseDollarAmounts;
        }

        private Briefcase GetBriefcaseById(int briefcaseIdToGet)
        {
            return theBriefcases.SingleOrDefault(p => p.BriefcaseId == briefcaseIdToGet);
        }

        private static IList<int> GetRandomIndexesToAccessDollarValues(int numberOfIndexesToGenerate,
            int minimumValueToGenerate, int maximumValueToGenerate)
        {
            var randomNumberGenerator = new Random();
            IList<int> randomIndexes = new List<int>();
            IList<int> previousIndexes = new List<int>();

            for (var counter = 0; counter < numberOfIndexesToGenerate; counter++)
            {
                int currentIndex;
                do
                {
                    currentIndex = randomNumberGenerator.Next(minimumValueToGenerate, maximumValueToGenerate);
                } while (previousIndexes.Contains(currentIndex));

                randomIndexes.Add(currentIndex);
                previousIndexes.Add(currentIndex);
            }

            return randomIndexes;
        }

        #endregion
    }
}