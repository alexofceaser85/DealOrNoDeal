using System;
using System.Collections.Generic;
using System.Linq;
using DealOrNoDeal.ErrorMessages;

namespace DealOrNoDeal.Model
{
    /// <summary>
    ///     Handles the management of the actual game play.
    ///     Author: Alex DeCesare
    ///     Version: 31-August-2021
    /// </summary>
    public class GameManager
    {
        #region Data members

        private const int InitialPlayerSelectedStartingCase = -1;
        private readonly IList<int> briefCaseDollarAmounts = new List<int> {
            0, 1, 5, 10, 25, 50, 75, 100, 200, 300, 400, 500, 750, 1000, 5000, 10000, 25000, 50000, 75000, 100000,
            200000, 300000, 400000, 500000, 750000, 1000000
        };

        private int playerSelectedStartingCase;
        private IList<Briefcase> theBriefcases;

        #endregion

        #region Properties

        /// <summary>
        ///     True if the player is selected their starting case, false if they already selected their starting case
        ///     Precondition: None
        ///     Postcondition: None
        /// </summary>
        public bool IsSelectingStartingCase { get; set; }

        /// <summary>
        ///     The banker for the game
        ///
        ///     Precondition: None
        ///     Postcondition: None
        /// </summary>
        public Banker Banker { get; }

        /// <summary>
        ///     The round manager for the game
        ///
        ///     Precondition: None
        ///     Postcondition: None
        /// </summary>
        public RoundManager RoundManager { get; }

        #endregion
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

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameManager" /> class.
        ///     Precondition: None
        ///     Postcondition:
        ///     this.RoundManager = new RoundManager(casesToOpenForEachRound)
        ///     AND this.Banker == new Banker()
        ///     AND this.theBriefcases.Count > 0
        ///     AND this.IsSelectingStartingCase = true
        ///     AND this.PlayerSelectedStartingCase == InitialPlayerSelectedStartingCase;
        /// </summary>
        /// <param name="casesToOpenForEachRound">The cases than can be opened for each round</param>
        public GameManager(IList<int> casesToOpenForEachRound)
        {
            this.RoundManager = new RoundManager(casesToOpenForEachRound);
            this.Banker = new Banker();

            var randomIndexesToAccessBriefcaseDollarAmounts = this.getRandomIndexesToAccessDollarValues(
                this.briefCaseDollarAmounts.Count, 0,
                this.briefCaseDollarAmounts.Count);

            this.PopulateBriefcases(randomIndexesToAccessBriefcaseDollarAmounts, this.briefCaseDollarAmounts);
            this.IsSelectingStartingCase = true;
            this.PlayerSelectedStartingCase = InitialPlayerSelectedStartingCase;
        }

        #endregion

        #region Methods

        private IList<int> getRandomIndexesToAccessDollarValues(int numberOfIndexesToGenerate,
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
            var bankerOffer = this.Banker.CalculateOffer(this.theBriefcases, this.RoundManager.CasesLeftForCurrentRound);
            return bankerOffer;
        }

        /// <summary>
        ///     Moves to next round by incrementing Round property and setting
        ///     initial number of cases for that round
        ///     Precondition: None
        ///     Postcondition: None
        /// </summary>
        public void MoveToNextRound()
        {
            this.RoundManager.MoveToNextRound();
        }

        #endregion
    }
}