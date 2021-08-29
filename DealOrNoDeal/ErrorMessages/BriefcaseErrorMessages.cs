namespace DealOrNoDeal.ErrorMessages
{
    /// <summary>
    /// Holds the error messages for the Briefcase class.
    ///
    /// Author: Alex DeCesare
    /// Version: 31-August-2021
    /// </summary>
    public static class BriefcaseErrorMessages
    {
        /// <summary>
        ///     The brief case identifier cannot be zero or less
        /// </summary>
        public const string BriefCaseIdCannotBeLessThanZero = "The brief case Id cannot be less than zero";

        /// <summary>
        ///     The dollar amount cannot be less than zero
        /// </summary>
        public const string DollarAmountCannotBeLessThanZero = "The dollar amount cannot be less than zero";

        /// <summary>
        /// The cannot set briefcase identifier to less than zero
        /// </summary>
        public const string CannotSetBriefcaseIdToLessThanZero =
            "The briefcase Id cannot be set to a value less than zero";

        /// <summary>
        /// The cannot set dollar amount to less than zero
        /// </summary>
        public const string CannotSetDollarAmountToLessThanZero =
            "The dollar amount for a briefcase cannot be set to a value less than zero";
    }
}