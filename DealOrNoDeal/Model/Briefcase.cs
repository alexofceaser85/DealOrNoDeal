using System;

namespace DealOrNoDeal.Model
{
    /// <summary>
    /// Holds the data for each briefcase
    /// </summary>
    public class Briefcase
    {
        /// <summary>
        /// The briefcase identifier.
        /// </summary>
        public int BriefcaseId { get; set; }

        /// <summary>
        /// The dollar amount
        /// </summary>
        public int DollarAmount { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Briefcase"/> class.
        /// </summary>
        ///
        /// <precondition>
        /// briefcaseId &>= 0
        /// dollarAmount &>= 0 
        /// </precondition>
        ///
        /// <postcondition>
        /// this.BriefcaseId == briefcaseId
        /// this.DollarAmount == dollarAmount
        /// </postcondition>
        /// 
        /// <param name="briefcaseId">The briefcase identifier.</param>
        /// <param name="dollarAmount">The dollar amount.</param>
        public Briefcase(int briefcaseId, int dollarAmount)
        {
            if (briefcaseId < 0)
            {
                throw new ArgumentException(ErrorMessages.BriefcaseErrorMessages.BriefCaseIdCannotBeZeroOrLess);
            }

            if (dollarAmount < 0)
            {
                throw new ArgumentException(ErrorMessages.BriefcaseErrorMessages.DollarAmountCannotBeLessThanZero);
            }

            this.BriefcaseId = briefcaseId;
            this.DollarAmount = dollarAmount;
        }
    }
}