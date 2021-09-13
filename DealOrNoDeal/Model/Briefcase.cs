using System;
using DealOrNoDeal.ErrorMessages;

namespace DealOrNoDeal.Model
{
    /// <summary>
    /// Holds the data for each briefcase
    ///
    /// Author: Alex DeCesare
    /// Version: 31-August-2021
    /// </summary>
    public class Briefcase
    {
        private int briefcaseId;
        private int dollarAmount;

        /// <summary>
        /// The briefcase identifier.
        ///
        /// Precondition: value >= 0
        /// Postcondition: this.briefcaseId == value
        /// </summary>
        /// <value>The briefcase Id</value>
        public int BriefcaseId
        {
            get => this.briefcaseId;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(BriefcaseErrorMessages
                        .CannotSetBriefcaseIdToLessThanZero);
                }
                this.briefcaseId = value;
            }
        }

        /// <summary>
        /// The dollar amount
        ///
        /// Precondition: value >= 0
        /// Postcondition: this.dollarAmount == value
        /// </summary>
        /// <value>The dollar amount</value>
        public int DollarAmount
        {
            get => this.dollarAmount;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        BriefcaseErrorMessages.CannotSetDollarAmountToLessThanZero);
                }

                this.dollarAmount = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Briefcase" /> class.
        /// </summary>
        /// <precondition>
        /// briefcaseId &gt; 0
        /// dollarAmount &gt; 0
        /// </precondition>
        /// <postcondition>
        /// this.BriefcaseId == briefcaseId
        /// this.DollarAmount == dollarAmount
        /// </postcondition>
        /// <param name="briefcaseId">The briefcase identifier.</param>
        /// <param name="dollarAmount">The dollar amount.</param>
        public Briefcase(int briefcaseId, int dollarAmount)
        {
            if (briefcaseId < 0)
            {
                throw new ArgumentException(BriefcaseErrorMessages.BriefCaseIdCannotBeLessThanZero);
            }

            if (dollarAmount < 0)
            {
                throw new ArgumentException(BriefcaseErrorMessages.DollarAmountCannotBeLessThanZero);
            }

            this.BriefcaseId = briefcaseId;
            this.DollarAmount = dollarAmount;
        }
    }
}