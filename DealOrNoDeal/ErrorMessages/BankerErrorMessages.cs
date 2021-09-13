namespace DealOrNoDeal.ErrorMessages
{
    /// <summary>
    /// Holds the error messages for the banker
    ///
    /// Author: Alex DeCesare
    /// Version: 03-September-2021
    /// </summary>
    public static class BankerErrorMessages
    {
        /// <summary>
        /// The error messages that tells the user that the banker should not calculate the banker offer if the briefcases still in play are null
        /// </summary>
        public static string CannotCalculateBankerOfferIfBriefcasesStillInPlayAreNull = "Cannot calculate the banker offer if the briefcases still in play are null";

        /// <summary>
        /// The error messages that tells the user that the banker should not calculate the banker offer if the number of cases to open is less than or equal to zero
        /// </summary>
        public static string CannotCalculateBankerOfferIfNumberOfCasesToOpenIsLessThanOrEqualToZero =
            "Cannot calculate the banker offer if the briefcases still in play are less than or equal to zero";

        /// <summary>
        /// The error message that tells the user that the banker should not calculate the banker offer if the briefcases still in play are empty
        /// </summary>
        public static string CannotCalculateBankerOfferIfBriefcasesStillInPlayAreEmpty =
            "Cannot calculate the banker offer if the briefcases still in play are empty";

        /// <summary>
        /// The error message that tells the user that they should not set the banker current offer to less than zero
        /// </summary>
        public const string ShouldNotSetCurrentOfferToLessThanZero =
            "Cannot set the current banker offer to a value less than zero";

        /// <summary>
        /// The error  message that tells the user that they should not set the banker average offer to a value less than zero
        /// </summary>
        public const string ShouldNotSetAverageOfferToLessThanZero =
            "Cannot set the average offer to a value less than zero";

        /// <summary>
        /// The error message that tells the user that they should not set banker minimum offer to less than zero
        /// </summary>
        public const string ShouldNotSetMinimumOfferToLessThanZero =
            "Cannot set the minimum banker offer to less than zero";

        /// <summary>
        /// The error message that tells the user that they should not set banker minimum offer to more than maximum offer
        /// </summary>
        public const string ShouldNotSetMinimumOfferToMoreThanMaximumOffer =
            "Cannot set the minimum banker offer to more than the maximum banker offer";

        /// <summary>
        /// The error message that tells the user that they should not set banker maximum offer to less than zero
        /// </summary>
        public const string ShouldNotSetMaximumOfferToLessThanZero =
            "Cannot set the maximum banker offer to less than zero";

        /// <summary>
        /// The error message that tells the user that they should not set banker maximum offer to less than minimum offer
        /// </summary>
        public const string ShouldNotSetMaximumOfferToLessThanMinimumOffer =
            "Cannot set the maximum banker offer to less than the minimum banker offer";
    }
}
