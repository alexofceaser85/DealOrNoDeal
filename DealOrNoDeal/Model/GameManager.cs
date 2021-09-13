using System;
using System.Collections.Generic;
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

        private int playerSelectedStartingCase;
        private int playerSelectedStartingCaseDollarAmount;
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

        /// <summary>
        /// The briefcase manager for the game
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        public BriefcaseManager BriefcaseManager { get; }

        #endregion
        /// <summary>
        /// The case that is selected by the player at the start of the game
        /// Precondition:
        /// value >= InitialPlayerSelectedStartingCase
        /// Postcondition:
        /// this.playerSelectedStartingCase == value
        /// </summary>
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
        /// The dollar amount of the case that is selected by the player at the start of the game
        /// Precondition:
        /// value >= InitialPlayerSelectedStartingCaseDollarAmount
        /// Postcondition:
        /// this.playerSelectedStartingCaseDollarAmount == value
        /// </summary>
        /// <value>The dollar amount of the case selected by the player at the start of the game</value>
        public int PlayerSelectedStartingCaseDollarAmount
        {
            get => this.playerSelectedStartingCaseDollarAmount;
            set
            {
                if (value < 0)
                {

                }

                this.playerSelectedStartingCaseDollarAmount = value;
            }
        }

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GameManager" /> class.
        /// Precondition:
        /// casesToOpenForEachRound != null
        /// dollarAmountsForEachRound != null
        /// Postcondition:
        /// this.RoundManager = new RoundManager(casesToOpenForEachRound)
        /// AND this.BriefcaseManager = new BriefcaseManager(briefcaseDollarAmounts)
        /// AND this.Banker == new Banker()
        /// AND this.IsSelectingStartingCase = true
        /// AND this.PlayerSelectedStartingCase == InitialPlayerSelectedStartingCase;
        /// </summary>
        /// <param name="casesToOpenForEachRound">The cases than can be opened for each round</param>
        /// <param name="dollarAmountsForEachRound">The dollar amounts of the cases</param>
        public GameManager(IList<int> casesToOpenForEachRound, IList<int> dollarAmountsForEachRound)
        {
            if (casesToOpenForEachRound == null)
            {
                throw new ArgumentException(GameManagerErrorMessages.ShouldNotAllowNullCasesToOpenForEachRound);
            }
            if (dollarAmountsForEachRound == null)
            {
                throw new ArgumentException(GameManagerErrorMessages.ShouldNotAllowNullDollarAmountsForEachRound);
            }
            this.RoundManager = new RoundManager(casesToOpenForEachRound);
            this.BriefcaseManager = new BriefcaseManager(dollarAmountsForEachRound);
            this.Banker = new Banker();

            this.IsSelectingStartingCase = true;
            this.PlayerSelectedStartingCase = InitialPlayerSelectedStartingCase;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Removes the specified briefcase from play.
        /// Precondition: None
        /// Postcondition:
        /// this.BriefcaseManager.Count == this.BriefcaseManager.Count@prev - 1
        /// AND this.RoundManager == this.RoundManager@prev - 1
        /// </summary>
        /// <param name="id">The id of the briefcase to remove from play.</param>
        /// <returns>Dollar amount stored in the case, or -1 if case not found.</returns>
        public int RemoveBriefcaseFromPlay(int id)
        {
            var removedBriefcaseDollarAmount = this.BriefcaseManager.RemoveBriefcase(id);
            this.RoundManager.DecrementCasesLeftForCurrentRound();

            return removedBriefcaseDollarAmount;
        }

        /// <summary>
        /// Gets the banker offer
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <returns>The current banker offer</returns>
        public double GetOffer()
        {
            return this.Banker.CalculateOffers(this.BriefcaseManager.Briefcases, this.RoundManager.CasesAvailableForNextRound);
        }
        #endregion
    }
}