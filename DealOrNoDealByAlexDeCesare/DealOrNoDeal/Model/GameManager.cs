using System;
using System.Collections.Generic;
using System.Linq;

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

        private readonly IList<Briefcase> theBriefcases;

        private const int InitialCurrentRound = 1;
        private const int InitialCasesLeftForCurrentRound = 6;
        private const int InitialPlayerSelectedStartingCase = 1;
        private const int InitialBankerCurrentOffer = 0;
        private const int InitialBankerMinimumOffer = int.MaxValue;
        private const int InitialBankerMaximumOffer = int.MinValue;

        /// <summary>
        ///     Gets or sets the current round.
        /// </summary>
        /// <value>The current round.</value>
        public int CurrentRound { get; set; }

        /// <summary>
        ///     Gets or sets the cases left for current round.
        /// </summary>
        /// <value>The cases left for current round.</value>
        public int CasesLeftForCurrentRound { get; set; }

        /// <summary>
        ///     Gets or sets the player selected starting case.
        /// </summary>
        /// <value>The player selected starting case.</value>
        public int PlayerSelectedStartingCase { get; set; }

        /// <summary>
        ///     Gets or sets the banker current offer.
        /// </summary>
        /// <value>The banker current offer.</value>
        public int BankerCurrentOffer { get; set; }

        /// <summary>
        ///     Gets or sets the minimum banker offer.
        /// </summary>
        /// <value>The minimum banker offer.</value>
        public int MinimumBankerOffer { get; set; }

        /// <summary>
        ///     Gets or sets the maximum banker offer.
        /// </summary>
        /// <value>The maximum banker offer.</value>
        public int MaximumBankerOffer { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameManager" /> class.
        /// </summary>
        /// <precondition>
        ///     None
        /// </precondition>
        /// <postcondition>
        ///     this.theBriefcases.Length == 26
        ///     this.CurrentRound == this.InitialCurrentRound;
        ///     this.CasesLeftForCurrentRound == this.InitialCasesLeftForCurrentRound;
        ///     this.PlayerSelectedStartingCase == this.InitialPlayerSelectedStartingCase;
        ///     this.BankerCurrentOffer == this.InitialBankerCurrentOffer;
        ///     this.MinimumBankerOffer == this.InitialBankerMinimumOffer;
        ///     this.MaximumBankerOffer == this.InitialBankerMaximumOffer;
        /// </postcondition>
        public GameManager()
        {
            theBriefcases = new List<Briefcase>();
            PopulateBriefcases(GetRandomIndexesToAccessDollarValues(briefCaseDollarAmounts.Count, 0,
                briefCaseDollarAmounts.Count));
            CurrentRound = InitialCurrentRound;
            CasesLeftForCurrentRound = InitialCasesLeftForCurrentRound;
            PlayerSelectedStartingCase = InitialPlayerSelectedStartingCase;
            BankerCurrentOffer = InitialBankerCurrentOffer;
            MinimumBankerOffer = InitialBankerMinimumOffer;
            MaximumBankerOffer = InitialBankerMaximumOffer;
        }

        /// <summary>
        /// Populates the briefcases
        /// </summary>
        ///
        /// <precondition>
        /// none
        /// </precondition>
        ///
        /// <postcondition>
        /// this.theBriefcases.Count == this.indexesOfDollarValuesToPopulate.Length
        /// </postcondition>
        /// <param name="indexesOfDollarValuesToPopulate">The index of the array element from the briefCaseDollarAmounts to associate with the briefcase</param>
        public void PopulateBriefcases(IList<int> indexesOfDollarValuesToPopulate)
        {
            for (var counter = 0; counter < indexesOfDollarValuesToPopulate.Count; counter++)
            {
                var currentDollarAmountIndex = indexesOfDollarValuesToPopulate[counter];
                var newBriefcase = new Briefcase(counter, briefCaseDollarAmounts[currentDollarAmountIndex]);
                theBriefcases.Add(newBriefcase);
            }
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

            if (theSelectedBriefcase != null) return theSelectedBriefcase.DollarAmount;

            return -1;
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

            theBriefcases.Remove(GetBriefcaseById(id));
            return briefcaseToRemove.DollarAmount;
        }

        /// <summary>
        ///     TODO Complete method specification
        /// </summary>
        /// <returns></returns>
        public int GetOffer()
        {
            // TODO Collaborates with the banker class to get and return the amount of the offer after the round has completed.
            //      Note: You will need to figure out the number of cases to open in the next round and once you have
            //
            return -1;
        }

        /// <summary>
        ///     Moves to next round by incrementing Round property and setting
        ///     initial number of cases for that round
        ///     Precondition: None
        ///     Postcondition: Round == Round@prev + 1 AND CasesRemainingInRound == (number of cases to open in the next round)
        /// </summary>
        public void MoveToNextRound()
        {
            // TODO Complete this method according to its specification
        }

        /// <summary>
        /// Returns the string representation of the game manager
        /// </summary>
        ///
        /// <precondition>
        /// none
        /// </precondition>
        /// <postcondition>
        /// none
        /// </postcondition>
        /// 
        /// <returns>The string representation of the game manager</returns>
        public override string ToString()
        {
            var gameManagerString = $"A game manager with the following information:\n"
                                       + $"current round: {CurrentRound}\n"
                                       + $"cases left for current round: {CasesLeftForCurrentRound}\n"
                                       + $"player selected starting case: {PlayerSelectedStartingCase}\n"
                                       + $"banker current offer: {BankerCurrentOffer}\n"
                                       + $"minimum banker offer: {MinimumBankerOffer}\n"
                                       + $"maximum banker offer: {MaximumBankerOffer}\n"
                                       + $"---And the following briefcases---";

            foreach (var briefcase in this.theBriefcases)
            {
                gameManagerString +=
                    $"A briefcase with an ID: {briefcase.BriefcaseId} and dollar amount {briefcase.DollarAmount}\n";
            }

            return gameManagerString;
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