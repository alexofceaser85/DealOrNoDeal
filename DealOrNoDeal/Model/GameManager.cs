using System;
using System.Collections.Generic;
using System.Linq;
using DealOrNoDeal.ErrorMessages;

namespace DealOrNoDeal.Model
{
    /// <summary>Handles the management of the actual game play.</summary>
    public class GameManager
    {
        #region Data members

        private const int InitialCurrentRound = 1;
        private const int InitialCasesLeftForCurrentRound = 6;
        private const int InitialPlayerSelectedStartingCase = -1;
        private const int InitialBankerCurrentOffer = 0;
        private const int InitialBankerMinimumOffer = int.MaxValue;
        private const int InitialBankerMaximumOffer = int.MinValue;

        private readonly IList<int> briefCaseDollarAmounts = new List<int> {
            0, 1, 5, 10, 25, 50, 75, 100, 200, 300, 400, 500, 750, 1000, 5000, 10000, 25000, 50000, 75000, 100000,
            200000, 300000, 400000, 500000, 750000, 1000000
        };

        private IList<Briefcase> theBriefcases;

        private int currentRound;
        private int casesLeftForCurrentRound;
        private int playerSelectedStartingCase;
        private int bankerCurrentOffer;
        private int bankerMinimumOffer;
        private int bankerMaximumOffer;

        #endregion

        #region Properties

        /// <summary>
        ///     True if the player is selected their starting case, false if they already selected their starting case
        ///     Precondition: None
        ///     Postcondition: None
        /// </summary>
        public bool IsSelectingStartingCase { get; set; }

        /// <summary>
        ///     The current round that the game is on
        ///     Precondition:
        ///     value >= 1
        ///     Postcondition:
        ///     this.currentRound == value
        /// </summary>
        /// <value>The game's current round.</value>
        public int CurrentRound
        {
            get => this.currentRound;
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException(
                        GameManagerErrorMessages.ShouldNotSetCurrentRoundToLessThanOne);
                }

                this.currentRound = value;
            }
        }

        /// <summary>
        ///     The number of cases that are available for selection by the player for each new round
        ///     Precondition: None
        ///     Postcondition: None
        /// </summary>
        public int CasesAvailableForCurrentRound { get; private set; }

        /// <summary>
        ///     The cases left for the game's current round
        ///     Precondition:
        ///     value >= 0
        ///     Postcondition:
        ///     this.casesLeftForCurrentRound == value
        /// </summary>
        /// <value>The cases left for current round.</value>
        public int CasesLeftForCurrentRound
        {
            get => this.casesLeftForCurrentRound;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(GameManagerErrorMessages
                        .ShouldNotSetCasesLeftForCurrentRoundToLessThanZero);
                }

                this.casesLeftForCurrentRound = value;
            }
        }

        /// <summary>
        ///     The case that is selected by the player at the start of the game
        /// </summary>
        /// Precondition:
        /// value >= InitialPlayerSelectedStartingCase
        /// Postcondition:
        /// this.playerSelectedStartingCase == value
        /// <value>The case selected by the player at the start of the game.</value>
        public int PlayerSelectedStartingCase
        {
            get => this.playerSelectedStartingCase;
            set
            {
                if (value < InitialPlayerSelectedStartingCase)
                {
                    throw new ArgumentException(GameManagerErrorMessages
                        .ShouldNotSetPlaySelectedStartingCaseToLessThanNegativeOne);
                }

                this.playerSelectedStartingCase = value;
            }
        }

        /// <summary>
        ///     The current banker offer.
        ///     Precondition:
        ///     value >= 0
        ///     Postcondition:
        ///     this.bankerCurrentOffer == value
        /// </summary>
        /// <value>The banker's current offer.</value>
        public int BankerCurrentOffer
        {
            get => this.bankerCurrentOffer;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(GameManagerErrorMessages
                        .ShouldNotSetBankerCurrentOfferToLessThanZero);
                }

                this.bankerCurrentOffer = value;
            }
        }

        /// <summary>
        ///     The lowest offer the banker offered throughout the game
        ///     Precondition:
        ///     value  >= 0
        ///     AND value >= this.BankerMinimumOffer OR this.BankerMinimumOffer == InitialBankerMinimumOffer
        ///     Postcondition:
        ///     this.bankerMinimumOffer == value
        /// </summary>
        /// <value>The minimum banker offer.</value>
        public int BankerMinimumOffer
        {
            get => this.bankerMinimumOffer;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(GameManagerErrorMessages
                        .ShouldNotSetBankerMinimumOfferToLessThanZero);
                }

                if (value > this.BankerMaximumOffer && this.BankerMaximumOffer != InitialBankerMaximumOffer)
                {
                    throw new ArgumentException(GameManagerErrorMessages
                        .ShouldNotSetBankerMinimumOfferToMoreThanMaximumOffer);
                }

                this.bankerMinimumOffer = value;
            }
        }

        /// <summary>
        ///     The highest offer the banker offered throughout the game
        ///     Precondition:
        ///     value >= 0
        ///     AND value >= this.BankerMaximumOffer OR this.BankerMaximumOffer == InitialBankerMaximumOffer
        ///     Postcondition:
        ///     this.bankerMaximumOffer == value
        /// </summary>
        /// <value>The maximum banker offer.</value>
        public int BankerMaximumOffer
        {
            get => this.bankerMaximumOffer;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(GameManagerErrorMessages
                        .ShouldNotSetBankerMaximumOfferToLessThanZero);
                }

                if (value < this.BankerMinimumOffer && this.BankerMinimumOffer != InitialBankerMinimumOffer)
                {
                    throw new ArgumentException(GameManagerErrorMessages
                        .ShouldNotSetBankerMaximumOfferToLessThanMinimumOffer);
                }

                this.bankerMaximumOffer = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameManager" /> class.
        ///     Precondition: None
        ///     Postcondition:
        ///     this.theBriefcases.Count > 0
        ///     AND this.CurrentRound == InitialCurrentRound;
        ///     AND this.CasesLeftForCurrentRound == InitialCasesLeftForCurrentRound;
        ///     AND this.PlayerSelectedStartingCase == InitialPlayerSelectedStartingCase;
        ///     AND this.BankerCurrentOffer == InitialBankerCurrentOffer;
        ///     AND this.BankerMinimumOffer == InitialBankerMinimumOffer;
        ///     AND this.BankerMaximumOffer == InitialBankerMaximumOffer;
        /// </summary>
        public GameManager()
        {
            var randomIndexesToAccessBriefcaseDollarAmounts = getRandomIndexesToAccessDollarValues(
                this.briefCaseDollarAmounts.Count, 0,
                this.briefCaseDollarAmounts.Count);

            this.PopulateBriefcases(randomIndexesToAccessBriefcaseDollarAmounts, this.briefCaseDollarAmounts);
            this.IsSelectingStartingCase = true;
            this.CurrentRound = InitialCurrentRound;
            this.CasesAvailableForCurrentRound = InitialCasesLeftForCurrentRound;
            this.CasesLeftForCurrentRound = InitialCasesLeftForCurrentRound;
            this.PlayerSelectedStartingCase = InitialPlayerSelectedStartingCase;
            this.BankerCurrentOffer = InitialBankerCurrentOffer;
            this.bankerMinimumOffer = InitialBankerMinimumOffer;
            this.bankerMaximumOffer = InitialBankerMaximumOffer;
        }

        #endregion

        #region Methods

        private static IList<int> getRandomIndexesToAccessDollarValues(int numberOfIndexesToGenerate,
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

        /// <summary>
        ///     Populates the briefcases
        ///     Precondition:
        ///     indexesOfDollarValuesToPopulate != null
        ///     AND dollarValuesToPopulate != null
        ///     Postcondition:
        ///     this.theBriefcases = thePopulatedBriefcases
        /// </summary>
        /// <param name="indexesOfDollarValuesToPopulate">
        ///     The index of the array element which is used to get a value from the
        ///     dollar values
        /// </param>
        /// <param name="dollarValuesToPopulate">The dollar values which are to be accessed</param>
        /// <return>The populated briefcases</return>
        public void PopulateBriefcases(IList<int> indexesOfDollarValuesToPopulate, IList<int> dollarValuesToPopulate)
        {
            if (indexesOfDollarValuesToPopulate == null)
            {
                throw new ArgumentException(GameManagerErrorMessages
                    .ShouldNotPopulateBriefcasesIfIndexesOfDollarValuesAreNull);
            }

            if (dollarValuesToPopulate == null)
            {
                throw new ArgumentException(GameManagerErrorMessages
                    .ShouldNotPopulateBriefcasesIfDollarValuesAreNull);
            }

            IList<Briefcase> thePopulatedBriefcases = new List<Briefcase>();

            for (var counter = 0; counter < indexesOfDollarValuesToPopulate.Count; counter++)
            {
                var currentDollarAmountIndex = indexesOfDollarValuesToPopulate[counter];
                var newBriefcase = new Briefcase(counter, dollarValuesToPopulate[currentDollarAmountIndex]);
                thePopulatedBriefcases.Add(newBriefcase);
            }

            this.theBriefcases = thePopulatedBriefcases;
        }

        /// <summary>
        ///     Gets the briefcase value.
        ///     Precondition: None
        ///     Postcondition: None
        /// </summary>
        /// <param name="briefcaseIdToGet">The briefcase identifier to get.</param>
        /// <returns>
        ///     the dollar amount of the briefcase that has been selected, -1 if the briefcase Id is not present in the briefcases
        /// </returns>
        public int GetBriefcaseValue(int briefcaseIdToGet)
        {
            var theSelectedBriefcase = this.getBriefcaseById(briefcaseIdToGet);

            if (theSelectedBriefcase == null)
            {
                return -1;
            }

            return theSelectedBriefcase.DollarAmount;
        }

        private Briefcase getBriefcaseById(int briefcaseIdToGet)
        {
            return this.theBriefcases.SingleOrDefault(p => p.BriefcaseId == briefcaseIdToGet);
        }

        /// <summary>
        ///     Removes the specified briefcase from play.
        ///     Precondition: None
        ///     Postcondition: None
        /// </summary>
        /// <param name="id">The id of the briefcase to remove from play.</param>
        /// <returns>Dollar amount stored in the case, or -1 if case not found.</returns>
        public int RemoveBriefcaseFromPlay(int id)
        {
            var briefcaseToRemove = this.getBriefcaseById(id);
            if (briefcaseToRemove == null)
            {
                return -1;
            }

            this.theBriefcases.Remove(this.getBriefcaseById(id));
            return briefcaseToRemove.DollarAmount;
        }

        /// <summary>
        ///     Gets the banker offer
        ///     Precondition: None
        ///     Postcondition: None
        /// </summary>
        /// <returns>The current banker offer</returns>
        public int GetOffer()
        {
            var bankerOffer = Banker.CalculateBankerOffer(this.theBriefcases, this.CasesLeftForCurrentRound);
            this.updateBankerOffers(bankerOffer);
            return bankerOffer;
        }

        private void updateBankerOffers(int bankerOffer)
        {
            this.BankerCurrentOffer = bankerOffer;
            if (this.bankerMinimumOffer > bankerOffer)
            {
                this.bankerMinimumOffer = bankerOffer;
            }

            if (this.bankerMaximumOffer < bankerOffer)
            {
                this.bankerMaximumOffer = bankerOffer;
            }
        }

        /// <summary>
        ///     Moves to next round by incrementing Round property and setting
        ///     initial number of cases for that round
        ///     Precondition: None
        ///     Postcondition:
        ///     Round == Round@prev + 1
        ///     AND CasesRemainingInRound == (number of cases to open in the next round)
        /// </summary>
        public void MoveToNextRound()
        {
            this.CurrentRound++;
            if (this.CasesAvailableForCurrentRound > 1)
            {
                this.CasesAvailableForCurrentRound--;
            }

            this.CasesLeftForCurrentRound = this.CasesAvailableForCurrentRound;
        }

        #endregion
    }
}