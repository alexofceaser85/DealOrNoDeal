using System;
using DealOrNoDeal.ErrorMessages;

namespace DealOrNoDeal.Model
{
    /// <summary>
    ///     Holds the data for each briefcase
    /// </summary>
    public class Briefcase
    {
        private int briefcaseId;
        private int dollarAmount;

        /// <summary>
        ///     The briefcase identifier.
        /// </summary>
        public int BriefcaseId
        {
            get => briefcaseId;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(BriefcaseErrorMessages
                        .CannotSetBriefcaseIdToLessThanZero);
                }
                briefcaseId = value;
            }
        }

        /// <summary>
        ///     The dollar amount
        /// </summary>
        public int DollarAmount
        {
            get => dollarAmount;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        BriefcaseErrorMessages.CannotSetDollarAmountToLessThanZero);
                }

                dollarAmount = value;
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Briefcase" /> class.
        /// </summary>
        /// <precondition>
        ///     briefcaseId &gt;= 0
        ///     dollarAmount &gt;= 0
        /// </precondition>
        /// <postcondition>
        ///     this.BriefcaseId == briefcaseId
        ///     this.DollarAmount == dollarAmount
        /// </postcondition>
        /// <param name="briefcaseId">The briefcase identifier.</param>
        /// <param name="dollarAmount">The dollar amount.</param>
        public Briefcase(int briefcaseId, int dollarAmount)
        {
            if (briefcaseId < 0) throw new ArgumentException(BriefcaseErrorMessages.BriefCaseIdCannotBeLessThanZero);

            if (dollarAmount < 0) throw new ArgumentException(BriefcaseErrorMessages.DollarAmountCannotBeLessThanZero);

            BriefcaseId = briefcaseId;
            DollarAmount = dollarAmount;
        }
    }
}