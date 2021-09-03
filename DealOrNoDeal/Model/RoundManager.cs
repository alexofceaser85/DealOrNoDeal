using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DealOrNoDeal.ErrorMessages;

namespace DealOrNoDeal.Model
{
    /// <summary>
    ///     Handles the management of the game rounds
    ///     Author: Alex DeCesare
    ///     Version: 03-September-2021
    /// </summary>
    public class RoundManager
    {
        private const int InitialCurrentRound = 1;

        private int indexOfAvailableCasesForNextRound = 1;

        private int currentRound;
        private int casesLeftForCurrentRound;

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
        public IList<int> CasesAvailableForEachRound { get; }

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
        /// Precondition: None
        /// Postcondition:
        ///     this.CasesAvailableForEachRound == casesAvailableForEachRound
        ///     this.CasesAvailableForNextRound == this.CasesAvailableForEachRound[this.indexOfAvailableCasesForNextRound]
        ///     AND this.CurrentRound == InitialCurrentRound
        ///     AND this.CasesAvailableForCurrentRound == this.CasesAvailableForEachRound[0]
        ///     AND this.CasesLeftForCurrentRound == this.CasesAvailableForEachRound[0]
        ///
        ///     OR IF ArgumentOutOfRangeException THEN
        ///     this.CasesAvailableForNextRound = 0;
        ///     this.CurrentRound = InitialCurrentRound;
        ///     this.CasesAvailableForCurrentRound = 0;
        ///     this.CasesLeftForCurrentRound = 0;
        ///     
        /// </summary>
        /// <param name="casesAvailableForEachRound">The cases available for each round of the game</param>
        public RoundManager(IList<int> casesAvailableForEachRound)
        {
            if (casesAvailableForEachRound == null)
            {
                throw new ArgumentException(RoundManagerErrorMessages.ShouldNotAllowNullCasesAvailableForEachRound);
            }

            try
            {
                this.CasesAvailableForEachRound = casesAvailableForEachRound;
                this.CasesAvailableForNextRound = this.CasesAvailableForEachRound[this.indexOfAvailableCasesForNextRound];
                this.CurrentRound = InitialCurrentRound;
                this.CasesAvailableForCurrentRound = this.CasesAvailableForEachRound[0];
                this.CasesLeftForCurrentRound = this.CasesAvailableForEachRound[0];
            }
            catch (ArgumentOutOfRangeException)
            {
                this.CasesAvailableForNextRound = 0;
                this.CurrentRound = InitialCurrentRound;
                this.CasesAvailableForCurrentRound = 0;
                this.CasesLeftForCurrentRound = 0;
            }
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
            if (this.indexOfAvailableCasesForNextRound < this.CasesAvailableForEachRound.Count - 1)
            {
                this.indexOfAvailableCasesForNextRound += 1;
                this.CasesAvailableForNextRound = this.CasesAvailableForEachRound[this.indexOfAvailableCasesForNextRound];
            }
            this.CurrentRound++;
            if (this.CasesAvailableForCurrentRound > 1)
            {
                this.CasesAvailableForCurrentRound--;
            }

            this.CasesLeftForCurrentRound = this.CasesAvailableForCurrentRound;
        }
    }
}
