using System;
using System.Collections.Generic;
using DealOrNoDeal.ErrorMessages;

namespace DealOrNoDeal.Model
{
    /// <summary>
    /// Handles the management of the game rounds
    /// Author: Alex DeCesare
    /// Version: 03-September-2021
    /// </summary>
    public class RoundManager
    {
        private const int InitialCurrentRound = 1;

        private int indexOfAvailableCasesForNextRound;
        private int currentRound;
        private int casesLeftForCurrentRound;

        /// <summary>
        /// The final round for the game
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        private int FinalRound { get; }

        /// <summary>
        /// The cases for the next round of the game
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        public int CasesAvailableForNextRound { get; private set; }

        /// <summary>
        ///     The number of cases that are available for selection by the player for each new round
        ///     Precondition: None
        ///     Postcondition: None
        /// </summary>
        public int CasesAvailableForCurrentRound { get; private set; }

        /// <summary>
        /// The cases available for each round
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        public IList<int> CasesAvailableForEachRound { get; set; }

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
                        RoundManagerErrorMessages.ShouldNotSetCurrentRoundToLessThanOne);
                }

                this.currentRound = value;
            }
        }

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
                    throw new ArgumentException(RoundManagerErrorMessages
                        .ShouldNotSetCasesLeftForCurrentRoundToLessThanZero);
                }

                this.casesLeftForCurrentRound = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoundManager" /> class.
        ///
        /// Precondition:
        /// casesAvailableForEachRound != null
        /// casesAvailableForEachRound.Count != 0
        /// Postcondition:
        /// this.CasesAvailableForEachRound == casesAvailableForEachRound
        /// AND this.CasesAvailableForNextRound == this.CasesAvailableForEachRound[this.indexOfAvailableCasesForNextRound]
        /// AND this.CurrentRound == InitialCurrentRound
        /// AND this.CasesAvailableForCurrentRound == this.CasesAvailableForEachRound[0]
        /// AND this.CasesLeftForCurrentRound == this.CasesAvailableForEachRound[0]
        /// AND this.FinalRound = casesAvailableForEachRound.Count + 1
        /// </summary>
        /// <param name="casesAvailableForEachRound">The cases available for each round of the game</param>
        public RoundManager(IList<int> casesAvailableForEachRound)
        {
            if (casesAvailableForEachRound == null)
            {
                throw new ArgumentException(RoundManagerErrorMessages.ShouldNotAllowNullCasesAvailableForEachRound);
            }

            if (casesAvailableForEachRound.Count <= 1)
            {
                throw new ArgumentException(RoundManagerErrorMessages.ShouldNotAllowEmptyCasesAvailableForEachRound);
            }

            this.indexOfAvailableCasesForNextRound = 1;
            this.CasesAvailableForEachRound = casesAvailableForEachRound;
            this.CasesAvailableForNextRound = this.CasesAvailableForEachRound[this.indexOfAvailableCasesForNextRound];
            this.CurrentRound = InitialCurrentRound;
            this.CasesAvailableForCurrentRound = this.CasesAvailableForEachRound[0];
            this.CasesLeftForCurrentRound = this.CasesAvailableForEachRound[0];
            this.FinalRound = casesAvailableForEachRound.Count + 1;
        }

        /// <summary>
        ///     Moves to next round by incrementing Round property and setting
        ///     initial number of cases for that round
        ///     Precondition: None
        ///     Postcondition:
        ///     Round == Round@prev + 1
        ///     AND this.indexOfAvailableCasesForNextRound += 1 IF LESS THAN this.CasesAvailableForEachRound.Count - 1
        ///     AND CasesRemainingInRound == (number of cases to open in the next round)
        /// </summary>
        public void MoveToNextRound()
        {
            this.updateCurrentRoundBriefcaseInformation();
            this.updateNextRoundBriefcaseInformation();

            this.CurrentRound++;
        }

        private void updateCurrentRoundBriefcaseInformation()
        {
            if (this.CasesAvailableForCurrentRound > 1)
            {
                this.CasesAvailableForCurrentRound = this.CasesAvailableForEachRound[this.indexOfAvailableCasesForNextRound];
            }

            this.CasesLeftForCurrentRound = this.CasesAvailableForCurrentRound;
        }

        private void updateNextRoundBriefcaseInformation()
        {
            if (this.indexOfAvailableCasesForNextRound >= this.CasesAvailableForEachRound.Count - 1)
            {
                return;
            }
            this.indexOfAvailableCasesForNextRound += 1;
            this.CasesAvailableForNextRound = this.CasesAvailableForEachRound[this.indexOfAvailableCasesForNextRound];
        }

        /// <summary>
        /// Decrements the current round by one
        ///
        /// Precondition: None
        /// Postcondition: this.currentRound == this.currentRound@prev - 1
        /// </summary>
        /// <return>Zero if the current round is one or less and current one minus one otherwise</return>
        public void DecrementCasesLeftForCurrentRound()
        {
            if (this.CasesLeftForCurrentRound > 0)
            {
                this.CasesLeftForCurrentRound--;
            }
        }

        /// <summary>
        /// Determines if the game is on the final round
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <returns>True if the game is on the final round, false otherwise</returns>
        public bool IsOnFinalRound()
        {
            return this.CurrentRound == this.FinalRound;
        }
    }
}
